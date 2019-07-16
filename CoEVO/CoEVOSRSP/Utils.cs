using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    class Utils
    {
        public POPDemanding[] Ships;
        public POPSupplying[] Ports;
        public POPSupplyingRelations[] PortsRelations;
        public POPSupplyingTimes[] PortTimes;
        public Rates[] POPRates;
        public VesselType[] VesselType;
        public VesselSizes[] VesselSizes;
        public QueueService[] Queue;
        public Chromosome[] C;
        public Chromosome[] Children;

        public int INI_POPSize; //Tamaño Pop Inicial (i.e. primeros individuos que serán los padres) | IniPopSize=2 individups iniciales
        public int[] QCont; //Array que almazena o tamanho da QuequeList for each Direction

        //Variables para calcular tiempos y costos de los barcos según el puerto
        private int _ShipMovements;
        private int _Cranes;
        private double _CranesPerformance;
        private int _MovementRate;
        private int _AwaitingTime;
        private int _CrossTime;
        private double _TimeInPort;
        //private double _ExtraTime;
        private double _VesselPriority;
        private double _EnvironmentConstant;
        private double _ShipFitness;

        private DateTime _FirstArrival;
        private DateTime _LastDeparture;

        Random rnd = new Random();
        double TotalDocks;
        double TotalHours;
        double TotalHoursDirections;
        int CurrentDock;
        int CurrentHour;

        public List<Chromosome> HallOfFame;
        public List<FitnessHistory> FitnessHistory = new List<FitnessHistory>();

        public Utils(POPDemanding[] ships, POPSupplying[] ports, POPSupplyingRelations[] portsRelations, POPSupplyingTimes[] portTimes, Rates[] rates, VesselType[] vesselType, VesselSizes[] vesselSizes, QueueService[] queue, int iniPOPSize)
        {
            C = null;
            
            Ships = ships;
            Ports = ports;
            PortsRelations = portsRelations;
            PortTimes = portTimes;
            POPRates = rates;
            VesselType = vesselType;
            VesselSizes = vesselSizes;
            Queue = queue;

            INI_POPSize = iniPOPSize;

            //Seteando valores iniciales del QueueService
            LoadMovements();
            BalancePanamaCanal();
            CreateChromosomes();
            LoadValuesChromosome(ref C,1);

            CleanChromosomes(ref C);
            SetTimes(ref C);
            SetCosts(ref C);
            CalculateArrivalTimesErrors(ref C);
            FitnessFunctionForAllCromosomes(ref C);

            //FitnessForPOPSupplying();
            //FitnessFunctionPOPDemanding();

        }

        public double NextDouble(double minValue, double maxValue)
        {
            return rnd.NextDouble() * (maxValue - minValue) + minValue;
        }

        public void LoadMovements()
        {
            foreach (QueueService Q in Queue)
            {
                if (GetVesselTypebyVesselID(Q.VesselID).ToUse1 > 0)
                {
                    Q.POPSupplyingID = Q.Direction;
                    GetShipIndexByVesselID(Q.VesselID).Units1 = GetVesselSizesForVesselID(Q.VesselID).TEU1;

                    switch (GetPOPSupplyingForPOPID(Q.POPSupplyingID).Group1 == 0) //Group0 es el Canal de Panamá
                    {
                        case true:
                            GetShipIndexByVesselID(Q.VesselID).MOV1 = Convert.ToInt16((NextDouble(0.6, 1.0) * GetShipIndexByVesselID(Q.VesselID).Units1)); //CORREGIR 1->0.6
                            Q.MOV = GetShipIndexByVesselID(Q.VesselID).MOV1;
                            if (GetShipIndexByVesselID(Q.VesselID).Units1 > GetPOPSupplyingForPOPID(Q.POPSupplyingID).Docks1[0].UnitCapacity1) Q.POPSupplyingID++;
                            break;

                        case false:
                            if (GetShipIndexByVesselID(Q.VesselID).MOV1 == 0)
                            {
                                Convert.ToInt16((NextDouble(0.6, 1.0) * GetShipIndexByVesselID(Q.VesselID).Units1));
                            }
                            GetShipIndexByVesselID(Q.VesselID).MOV1 = GetQueueServiceIndexForQueueID(Q.GetID).MOV;
                            break;
                    }
                    Q.Units = GetShipIndexByVesselID(Q.VesselID).Units1;
                }
            }
        }

        public void BalancePanamaCanal()
        {
            int VesselQtyD3 = 0;
            int VesselQtyD4 = 0;
            int Coef = 0;

            foreach (QueueService Qs in Queue)
            {
                if (GetVesselTypebyVesselID(Qs.VesselID).ToUse1 > 0)
                {
                    switch (Qs.Direction)
                    {
                        case 3:
                            VesselQtyD3 = GetvesselsQtyByDirectionAndPOPID(Qs.Direction, 3);
                            VesselQtyD4 = GetvesselsQtyByDirectionAndPOPID(Qs.Direction, 4);
                            Coef = (VesselQtyD3 + VesselQtyD4) / 3; //
                            Coef = Coef * 2;

                            if (VesselQtyD3 > Coef)
                            {
                                Qs.POPSupplyingID = 4;
                            }
                            break;

                        case 4:
                            VesselQtyD3 = GetvesselsQtyByDirectionAndPOPID(Qs.Direction, 3);
                            VesselQtyD4 = GetvesselsQtyByDirectionAndPOPID(Qs.Direction, 4);
                            Coef = (VesselQtyD3 + VesselQtyD4) / 3;
                            Coef = Coef * 2;

                            if (VesselQtyD3 <= Coef)
                            {
                                Qs.POPSupplyingID = 3;
                            }
                            break;
                    }
                }
            }
        }

        public void CreateChromosomes()
        {
            QCont = new int[Ports.Count()]; //crea un arreglo de tamaño de la cantidad de Puertos
            for(int i=0;i<QCont.Count();i++)
            {
                QCont[i] = GetQueQueServiceSizeForPOPID(Ports[i].ID1);
            }

            C = new CoEVO.Chromosome[Ports.Count() * INI_POPSize];

            int cont = 0;
            int ContPop = 1; 
            foreach(POPSupplying P in Ports)
            {
                for(int i=0;i<INI_POPSize;i++)
                {
                    C[cont] = new Chromosome(ContPop, new int[GetPOPSupplyingForPOPID(ContPop).Docks1.Count(), GetQueQueServicePOPRelationsSize(ContPop)]);
                    cont++;
                }
                ContPop++;
            }
            C[0].RestartID(); //Para reiniciar el ID en 0
        }

        public void LoadValuesChromosome(ref Chromosome[] CFather, int FirstLoad)
        {
            foreach (Chromosome Cr in CFather)
            {  
                QueueService[] Q = GetQuequeServiceHistoryForPOPID(Queue, Cr.POPID, QCont[Cr.POPID - 1]);
                QueueService gQ;
                TotalDocks = Cr.Schedule.GetLength(0);
                TotalHours = Math.Ceiling(Q.Count() / TotalDocks);
                
                //TotalHoursDirections = Math.Ceiling(GetvesselsQtyByDirectionAndPOPID(3, Cr.POPID)/TotalDocks);

                CurrentDock = 0;
                CurrentHour = 0;

                for(int i=0;i<Q.Count();i++)
                {
                    if(FirstLoad ==1)
                    {


                    }
                    gQ = CloneQueueService(Q[i],Q[i].ChromosomeID);
                    gQ.SetID(Q[i].ID);

                    gQ.CurrentDock = CurrentDock;
                    gQ.CurrentHour = CurrentHour;
                    gQ.ChromosomeID = Cr.ID1;
                    Cr.QueueList.Add(gQ);

                    if ((Cr.ID1 % 2) == 0) //Ubica en la hora 0 en Dock 1,2,3...; luego hora 1 en Dock 1,2,3
                    {
                        GetPOPSupplyingForPOPID(Cr.POPID).TotalShips++; //Indica cuántos barcos están en el Puerto, en total.
                        GetPOPSupplyingForPOPID(Cr.POPID).Docks1[gQ.CurrentDock].TotalShips++; //Para indicar cuántos barcos están en cada muelle
                        GetPOPSupplyingForPOPID(Cr.POPID).Docks1[gQ.CurrentDock].TotalHours = Convert.ToInt16(TotalHours);

                        CurrentDock++;
                        if (CurrentDock == TotalDocks)
                        {
                            CurrentDock = 0;
                            CurrentHour++;
                        }

                        if (CurrentHour == TotalHours)
                        {
                            CurrentHour = 0;
                        }

                        if(GetPOPSupplyingForPOPID(Q[i].POPSupplyingID).Group1 ==0) //Esta condicion aplica solo para el Canal de Panama
                        {
                            if(i<Q.Count()-1) //Hasta el último menos 1, para que no de error
                            {
                                if(Q[i].Direction != Q[i+1].Direction)//Compara La direccion actual versus la dirección del sigueinte barco. Si son diferentes,entonces debe reiniciar la esclusa, porque es del otro lado del oceáno
                                {
                                    CurrentHour = 0;
                                }
                            }
                        }
                    }
                    else //Ubica en Dock en Hora 0,1,2,3,4...
                    {
                        CurrentHour++;
                        if (CurrentHour == TotalHours)
                        {
                            CurrentHour = 0;
                            CurrentDock++;
                        }
                        if (CurrentDock == TotalDocks)
                        {
                            CurrentDock++;
                        }

                        if (GetPOPSupplyingForPOPID(Q[i].POPSupplyingID).Group1 == 0)
                        {
                            if((CurrentHour==((GetvesselsQtyByDirectionAndPOPID(Q[i].Direction,Q[i].POPSupplyingID))+1)/2)&& GetPOPSupplyingForPOPID(Q[i].POPSupplyingID).Docks1.Count()>1)
                            {
                                CurrentHour = 0;
                                CurrentDock++;
                            }

                            if (i < Q.Count() - 1) //Hasta el último menos 1, para que no de error
                            {
                                if (Q[i].Direction != Q[i + 1].Direction)//Compara La direccion actual versus la dirección del sigueinte barco. Si son diferentes,entonces debe reiniciar la esclusa, porque es del otro lado del oceáno
                                {
                                    CurrentHour = 0;
                                    CurrentDock = 0;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void CleanChromosomes(ref Chromosome[] CGeral)
        {
            foreach (Chromosome Cr in CGeral)
            {
                Cr.RestartValues();

                foreach (QueueService Qs in Cr.QueueList)
                {
                    Qs.AwaitingTime = 0;
                    Qs.CrossTime = 0;
                    Qs.TimeInPort = 0;
                    Qs.DelayTime = 0;
                    Qs.ArrivalTime = GetQueueServiceIndexForQueueID(Qs.ID).ArrivalTime;
                    Qs.DepartureTime = GetQueueServiceIndexForQueueID(Qs.ID).DepartureTime;

                    Qs.FixedCost = 0;
                    Qs.VariableCost = 0;
                    Qs.Cost = 0;

                    Qs.ReAllocatedTime = 0;
                    Qs.ReAllocatedDock = 0;
                }
            }
        }

        //public void SetTimes(int x, int y, ref QueueService Q)
        public void SetTimes(ref Chromosome[] CGeral)
        {
            foreach (Chromosome Cr in CGeral)
            {
                foreach(QueueService Qs in Cr.QueueList)
                {
                    _AwaitingTime = GetTotalTimeForQueueIDandTypeTime(Qs.GetID, 1); //1:[Awaiting+Dispatch]Time; 2: CrossTime
                    Qs.AwaitingTime = _AwaitingTime;
                    _EnvironmentConstant = GetPOPSupplyingForPOPID(Qs.POPSupplyingID).EnvironmentConstant1;

                    _VesselPriority = GetVesselPriority(Qs.Status);
                    //_VesselPriority = 1; //REMOVER

                    switch (GetPOPSupplyingForPOPID(Qs.POPSupplyingID).Group1)
                    {
                        case 0:
                            _CrossTime = GetTotalTimeForQueueIDandTypeTime(Qs.GetID, 2);
                            Qs.CrossTime = _CrossTime;
                            _CranesPerformance = GetPOPSupplyingForPOPID(Qs.POPSupplyingID).Docks1[Qs.CurrentDock].Performance1;
                            //_CranesPerformance = 1; //REMOVER
                            _TimeInPort = (_AwaitingTime + _CrossTime) / (_CranesPerformance * _VesselPriority * _EnvironmentConstant);
                            //Qs.ExtraTime = 0;
                            break;

                        case 1:
                            _ShipMovements = Qs.MOV;
                            _MovementRate = GetPOPSupplyingForPOPID(Qs.POPSupplyingID).MovementRate1; //25
                            _Cranes = GetPOPSupplyingForPOPID(Qs.POPSupplyingID).Crane1;
                            _CranesPerformance = GetPOPSupplyingForPOPID(Qs.POPSupplyingID).Docks1[Qs.CurrentDock].Performance1;
                            //_CranesPerformance = 1; //REMOVER

                            //_ExtraTime = GetTotalTimeForQueueIDandTypeTime(Qs.GetID, 2); //Tiempo en cruzar el territorio, i.e. Canal Seco
                            _CrossTime = GetTotalTimeForQueueIDandTypeTime(Qs.GetID, 2); //Tiempo en cruzar el territorio, i.e. Canal Seco
                            //Qs.ExtraTime = Convert.ToInt16(_ExtraTime);
                            Qs.CrossTime = _CrossTime;
                            _TimeInPort = ((_ShipMovements / (Convert.ToDouble((Convert.ToDecimal((_MovementRate * _Cranes)) / 60)) * _CranesPerformance * _VesselPriority * _EnvironmentConstant) + (_AwaitingTime)));
                            break;
                    }
                    Qs.TimeInPort = Convert.ToInt16(_TimeInPort);
                    Qs.DepartureTime = Qs.ArrivalTime.AddMinutes(_TimeInPort);   
                }
            }
        }

        //public void SetCosts(ref QueueService Q)
        public void SetCosts(ref Chromosome[] CGeral)
        {
            double value = 0;

            foreach (Chromosome Cr in CGeral)
            {
                foreach (QueueService Qs in Cr.QueueList)
                {
                    value = 0;
                    foreach (Rates R in POPRates)
                    {
                        if (R.POPSupplyingID1 == GetQueueServiceIndexForQueueID(Qs.GetID).Direction)
                        {
                            switch (R.BaseRate1)
                            {
                                case 1: //General Payment | One Time
                                    value += R.Rate1;
                                    //GetQueueServiceIndexForQueueID(Qs.GetID).FixedCost += R.Rate1;
                                    Qs.FixedCost += R.Rate1;
                                    break;

                                case 2: //Each MOV Payment | For each MOV
                                        //Si es 0 (Canal de Panamá) los movimientos se calculan según el calado (VesselSize).  Si No es el Canal, los movimientos se obtienen de la tabla History directamente
                                    value += (GetQueueServiceIndexForQueueID(Qs.GetID).MOV * R.Rate1);
                                    //GetQueueServiceIndexForQueueID(Qs.GetID).VariableCost += (GetQueueServiceIndexForQueueID(Qs.GetID).MOV * R.Rate1);
                                    Qs.VariableCost += Qs.MOV * R.Rate1;
                                    break;
                            }
                        }
                    }
                    //GetQueueServiceIndexForQueueID(Qs.GetID).Cost += value;
                    Qs.Cost += value;
                }
            }
        }

        public void CalculateArrivalTimesErrors(ref Chromosome[] CGeral)
        {            
            QueueService Queue1;
            QueueService Queue2;
            QueueService Queue1OtherSide;
            QueueService Queue2OtherSide;

            int cont=0;

            foreach (Chromosome Cr in CGeral)
            {
                //Cr.QueueList.OrderByDescending(i => i.CurrentHour);

                for (int i = 0; i < Cr.QueueList.Count() - 1; i++)
                {
                    Queue1 = Cr.QueueList[i]; //GetQueueServiceIndexForQueueID(Cr.Schedule[x, y]);
                    Queue2 = Cr.QueueList[i + 1]; //GetQueueServiceIndexForQueueID(Cr.Schedule[x, y + 1]);

                    if ((Queue1.CurrentDock == Queue2.CurrentDock)&&(Queue1.Direction==Queue2.Direction))
                    {
                        switch (GetPOPSupplyingForPOPID(Cr.QueueList[i].POPSupplyingID).Group1 == 0)
                        {
                            case true:
                                if (Queue2.ArrivalTime <= Queue1.ArrivalTime.AddMinutes(GetTotalTimeForQueueIDandTypeTime(Queue2.GetID, 3)))
                                {
                                    Queue2.OldArrivalTime = Queue2.ArrivalTime;
                                    Queue2.OldDepartureTime = Queue2.DepartureTime;

                                    Queue2.ArrivalTime = Queue1.ArrivalTime.AddMinutes(GetTotalTimeForQueueIDandTypeTime(Queue2.GetID, 3));
                                    Queue2.DepartureTime = Queue2.ArrivalTime.AddMinutes(Queue2.TimeInPort);

                                    Queue2.DelayTime = Convert.ToInt64((Queue2.ArrivalTime - Queue2.OldArrivalTime).TotalMinutes);
                                    Queue2.ReAllocatedTime = 1;
                                }

                                //Función que regula el paso de barcos de una dirección a otra. 
                                //PENDIENTE

                                break;

                            case false:
                                if (Queue2.ArrivalTime <= Queue1.DepartureTime.AddMinutes(GetTotalTimeForQueueIDandTypeTime(Queue2.GetID, 3))) //Un barco no puede llegar mientras otro esté en el muelle
                                {
                                    Queue2.OldArrivalTime = Queue2.ArrivalTime;
                                    Queue2.OldDepartureTime = Queue2.DepartureTime;

                                    Queue2.ArrivalTime = Queue1.DepartureTime.AddMinutes(GetTotalTimeForQueueIDandTypeTime(Queue2.GetID, 3));
                                    Queue2.DepartureTime = Queue2.ArrivalTime.AddMinutes(Queue2.TimeInPort);

                                    Queue2.DelayTime = Convert.ToInt64((Queue2.ArrivalTime - Queue2.OldArrivalTime).TotalMinutes);
                                    Queue2.ReAllocatedTime = 1;
                                }

                                break;
                        }
                    }
                }
            }

            //foreach (Chromosome Cr in CGeral)
            //{
            //    if (GetPOPSupplyingForPOPID(Cr.POPID).Group1 == 0)
            //    {
            //        //for (int x = 0; x < GetPOPSupplyingForPOPID(Cr.POPID).Docks1.Count() - 1; x++) //Recorre las dock del puerto
            //        //{
            //        //    for (int y = 0; y < GetPOPSupplyingForPOPID(Cr.POPID).Docks1[x].TotalShips - 1; y++) //Recorre la fila del Dock
            //        //    {
            //        //        if (y < GetPOPSupplyingForPOPID(Cr.POPID).Docks1[x].TotalShips - 1) //Revisa que no sea el último barco en la fila
            //        //        {
            //        //            Queue1 = GetQueueServiceByDockAndHour(Cr.QueueList, x, y);
            //        //            Queue2 = GetQueueServiceByDockAndHour(Cr.QueueList, x, y + 1);
            //        //            Console.WriteLine("[" + x + "," + y + "]-" + Queue1.VesselID);
            //        //            Console.WriteLine("[" + x + "," + y+1 + "]-" + Queue1.VesselID);

            //        //            if(Queue1.Direction == Queue2.Direction)
            //        //            {
            //        //                if (Queue2.ArrivalTime <= Queue1.ArrivalTime.AddMinutes(GetTotalTimeForQueueIDandTypeTime(Queue2.GetID, 3)))
            //        //                {
            //        //                    Console.WriteLine("VEssel: " + Queue2.VesselID);
            //        //                    Console.WriteLine(Queue2.ArrivalTime + " < " + Queue1.ArrivalTime);
            //        //                    Queue2.OldArrivalTime = Queue2.ArrivalTime;
            //        //                    Queue2.OldDepartureTime = Queue2.DepartureTime;

            //        //                    Queue2.ArrivalTime = Queue1.ArrivalTime.AddMinutes(GetTotalTimeForQueueIDandTypeTime(Queue2.GetID, 3));

            //        //                    //Revisar DepartureTime
            //        //                    Queue2.DepartureTime = Queue2.ArrivalTime.AddMinutes(Queue2.TimeInPort);

            //        //                    Queue2.DelayTime = Convert.ToInt64((Queue2.ArrivalTime - Queue2.OldArrivalTime).TotalMinutes);
            //        //                    Queue2.ReAllocatedTime = 999;
            //        //                    Console.WriteLine(Queue2.ArrivalTime + " - " + Queue1.ArrivalTime);
            //        //                }
            //        //            }
            //        //        }
            //        //    }
            //        //}
            //    }
            //    else
            //    {
            //        for (int x = 0; x < GetPOPSupplyingForPOPID(Cr.POPID).Docks1.Count() - 1; x++) //Recorre las dock del puerto
            //        {
            //            for (int y = 0; y < GetPOPSupplyingForPOPID(Cr.POPID).Docks1[x].TotalShips - 1; y++) //Recorre la fila del Dock
            //            {
            //                if (y < GetPOPSupplyingForPOPID(Cr.POPID).Docks1[x].TotalShips - 1) //Revisa que no sea el último barco en la fila
            //                {
            //                    Queue1 = GetQueueServiceByDockAndHour(Cr.QueueList, x, y);
            //                    Queue2 = GetQueueServiceByDockAndHour(Cr.QueueList, x, y + 1);

            //                    if (Queue2.ArrivalTime <= Queue1.DepartureTime.AddMinutes(GetTotalTimeForQueueIDandTypeTime(Queue2.GetID, 3)))  //Un barco no puede llegar mientras otro esté en el muelle
            //                    {
            //                        Queue2.OldArrivalTime = Queue2.ArrivalTime;
            //                        Queue2.OldDepartureTime = Queue2.DepartureTime;

            //                        //Queue2.ArrivalTime = Queue1.DepartureTime.AddMinutes((Queue1.DepartureTime.AddMinutes(GetTotalTimeForQueueIDandTypeTime(Queue2.GetID, 3)) - Queue2.ArrivalTime).Minutes);
            //                        Queue2.ArrivalTime = Queue1.DepartureTime.AddMinutes(GetTotalTimeForQueueIDandTypeTime(Queue2.GetID, 3));
            //                        Queue2.DepartureTime = Queue2.ArrivalTime.AddMinutes(Queue2.TimeInPort);

            //                        Queue2.DelayTime = Convert.ToInt64((Queue2.ArrivalTime - Queue2.OldArrivalTime).TotalMinutes);
            //                        Queue2.ReAllocatedTime = 1;

            //                    }
            //                }
            //            }
            //            //GetQueueServiceForDock
            //            //Recorrer cada Hora del Dock para saber si el siguiente está en un período mayor o igual
            //            //Calcular IdleTime (i.e. tiempo de inactividad, si el siguiente barco (+1Hour) está demasiado lejos en tiempo
            //        }
            //    }
            //}
        }

        public QueueService GetQueueServiceByDockAndHour(List<QueueService> QueueList, int Dock, int Hour)
        {
            QueueService Q =  QueueList[0];
            foreach(QueueService Qs in QueueList)
            {
                if(Qs.CurrentDock==Dock && Qs.CurrentHour==Hour)
                {
                    Q = Qs;
                }
            }
            return Q;
        }

        public void FitnessFunctionForAllCromosomes(ref Chromosome[] CGeral)
        {
            foreach(Chromosome Cr in CGeral)
            {
                Cr.RestartValues();

                _ShipMovements = 0;
                _AwaitingTime = 0;
                _CrossTime = 0;
                _TimeInPort = 0;
                //_ExtraTime = 0;

                foreach(QueueService Qs in Cr.QueueList)
                {
                    _ShipMovements = Qs.MOV;
                    _AwaitingTime = Qs.AwaitingTime;
                    _CrossTime = Qs.CrossTime;
                    _TimeInPort = Qs.TimeInPort;
                    //_ExtraTime = Qs.ExtraTime;

                    _ShipFitness = (Convert.ToDouble(Qs.MOV) / ((Convert.ToDouble(Qs.TimeInPort + Qs.DelayTime))+Qs.Cost));
                    Qs.Fitness = _ShipFitness;

                    Cr.VesselsQty++;
                    Cr.Units += Qs.Units;
                    Cr.Movements += Qs.MOV;
                    Cr.AwaitingTime += Qs.AwaitingTime;
                    Cr.TimeInPort += Qs.AwaitingTime;
                    //Cr.ExtraTime += Qs.ExtraTime;
                    Cr.CrossTime += Qs.CrossTime;
                    Cr.DelayTime += Qs.DelayTime;
                    Cr.ShipsCost += Qs.Cost;
                    Cr.FixedCost += Qs.FixedCost;
                    Cr.VariableCost += Qs.VariableCost;
                    Cr.PortCost = Cr.Movements / Cr.VesselsQty;
                    Cr.FitnessShips += Qs.Fitness;
                    //Console.WriteLine(Cr.FitnessShips);
                }

                Cr.Units += Cr.Units;
                Cr.Movements += Cr.Movements;
                Cr.AwaitingTime += Cr.AwaitingTime;
                Cr.TimeInPort += Cr.TimeInPort;
                //Cr.ExtraTime = Cr.ExtraTime / Cr.VesselsQty;
                Cr.CrossTime += Cr.CrossTime;
                Cr.DelayTime += Cr.DelayTime;
                Cr.ShipsCost += Cr.ShipsCost;
                Cr.FixedCost += Cr.FixedCost;
                Cr.VariableCost += Cr.VariableCost;

                GetLastDepartureOFChromosome(Cr, ref _LastDeparture);
                GetFirtsArrivalOFChromosome(Cr, ref _FirstArrival);
                Cr.TotalPortTime = Convert.ToInt64((_LastDeparture - _FirstArrival).TotalHours);

                //QueueService: public int TimeInPort; //AwaitingTime + CrossTime + WorkTime
                //Chromosome: public long TotalPortTime; //Difference between LastArrivalTime - FirstArrivalTime

                Cr.FitnessPorts = (Cr.PortCost) / ((Cr.VesselsQty + Cr.Movements)*Cr.TotalPortTime);

                //Cr.Fitness = Cr.FitnessShips*Cr.FitnessPorts;
            }
        }

        public void SetFinalFitnessForChromosomes(ref Chromosome[] C, int ExceptPOPID)
        {
            foreach(Chromosome Cr in C)
            {
                if(Cr.POPID!=ExceptPOPID)
                {
                    Cr.Fitness = GetFitnessPortsExceptONE(Ports, ExceptPOPID) / (Cr.FitnessShips*Cr.FitnessPorts);
                }
            }
        }

        public void SetFitnessToSupplyingPOP(ref Chromosome[] CGeral, ref POPSupplying[] P)
        {
            foreach(POPSupplying Port in P)
            {
                Port.Fitness1 = 0;

                foreach(Chromosome Cr in CGeral)
                {
                    if(Cr.POPID == Port.ID1)
                    {
                        if(Cr.FitnessPorts > Port.Fitness1)
                        {
                            Port.Fitness1 = Cr.FitnessPorts;
                        }
                    }
                }
            }
        }

        public double GetFitnessPortsExceptONE(POPSupplying[] Port, int ExceptPortID)
        {
            double x=0;
            foreach(POPSupplying P in Port)
            {
                if(P.ID1 != ExceptPortID)
                {
                    x += P.Fitness1;
                }
            }
            return x;
        }

        public void GetLastDepartureOFChromosome(Chromosome Cr, ref DateTime LastDeparture)
        {
            LastDeparture = Cr.QueueList[0].DepartureTime;
            foreach(QueueService Q in Cr.QueueList)
            {
                if(Q.DepartureTime>LastDeparture)
                {
                    LastDeparture = Q.DepartureTime;
                }
            }
        }

        public void GetFirtsArrivalOFChromosome(Chromosome Cr, ref DateTime FirstArrival)
        {
            FirstArrival = Cr.QueueList[0].ArrivalTime;
            foreach(QueueService Q in Cr.QueueList)
            {
                if(Q.ArrivalTime<FirstArrival)
                {
                    FirstArrival = Q.ArrivalTime;
                }
            }
        }

        public QueueService[] GetQuequeServiceHistoryForPOPID(QueueService[] QueueServiceHistory, int POP_ID, int QueueSize)
        {
            QueueService[] Qs = new CoEVO.QueueService[QueueSize];
            int cont = 0;
            foreach (QueueService QL in Queue)
            {
                if (QL.POPSupplyingID == POP_ID)
                {
                    if (GetVesselTypebyVesselID(QL.VesselID).ToUse1 > 0) //Se ToUse es diferente a 0, i.e. Not Crossing
                    {
                        Qs[cont] = QL;
                        cont++;
                    }
                }
            }
            return Qs;
        }

        public QueueService GetQueueServiceIndexForQueueID(int QueueID)
        {
            int cont = -1;
            foreach (QueueService QL in Queue)
            {
                cont++;
                if (QL.GetID == QueueID)
                    break;
            }
            return Queue[cont];
        }

        public POPDemanding GetShipIndexByVesselID(int VesselID)
        {
            int cont = -1;
            foreach (POPDemanding PShips in Ships)
            {
                cont++;
                if (PShips.VesselID1 == VesselID)
                    break;
            }
            return Ships[cont];
        }
        
        public VesselType GetVesselTypebyVesselID(int IDVessel)
        {
            VesselType VT = VesselType[0];
            foreach (VesselType VType in VesselType)
            {

                if (VType.ID1 == GetShipIndexByVesselID(IDVessel).VesselType1) VT = VType;
            }
            return VT;
        }

        public int GetvesselsQtyByDirectionAndPOPID(int Direction, int POPID)
        {
            int Qty = 0;
            foreach (QueueService Q in Queue)
            {
                if (GetVesselTypebyVesselID(Q.VesselID).ToUse1 > 0)
                {
                    if (Q.Direction == Direction && Q.POPSupplyingID == POPID)
                    {
                        Qty++;
                    }
                }
            }
            return Qty;
        }

        public int GetQueQueServiceSizeForPOPID(int POP_ID)
        {
            int x = 0;
            foreach (QueueService QL in Queue)
            {
                if (QL.POPSupplyingID == POP_ID)
                {
                    if (GetVesselTypebyVesselID(QL.VesselID).ToUse1 > 0) //Se ToUse es diferente a 0, i.e. Not Crossing
                    {
                        x++;
                    }
                }
            }
            return x;
        }

        public int GetQueQueServicePOPRelationsSize(int POP_ID)
        {
            int x = GetQueQueServiceSizeForPOPID(POP_ID);
            foreach (POPSupplyingRelations PR in PortsRelations)
            {
                if (PR.POPID1 == POP_ID)
                {
                    x = x + GetQueQueServiceSizeForPOPID(PR.Relation1);
                }
            }
            return x;
        }

        public int GetPOPRelationID(int Direction)
        {
            int x = 0;
            switch (Direction)
            {
                case 3:
                    x = 1;
                    break;
                case 4:
                    x = 2;
                    break;
            }
            return x;
        }
        
        public POPSupplying GetPOPSupplyingForPOPID(int POP_ID)
        {

            int cont = -1;
            foreach (POPSupplying Po in Ports)
            {
                cont++;
                if (Po.ID1 == POP_ID)
                    break;
            }
            return Ports[cont];
        }

        public VesselSizes GetVesselSizesForVesselID(int VesselID)
        {
            VesselSizes V = VesselSizes[0];
            POPDemanding P = GetShipIndexByVesselID(VesselID);

            foreach (VesselSizes Vs in VesselSizes)
            {
                if ((P.LOA1 <= Vs.LOA1) && (P.BOA1 <= Vs.BOA1))
                {
                    V = Vs;
                    break;
                }
            }
            return V;
        }

        public int GetTotalTimeForQueueIDandTypeTime(int QueueID, int tTime)
        {
            int totalTime = 0;

            foreach (POPSupplyingTimes PT in PortTimes)
            {
                if (PT.TypeTime1 == tTime)
                {
                    if (PT.POPSupplyingID1 == GetQueueServiceIndexForQueueID(QueueID).POPSupplyingID)
                    {
                        totalTime += PT.Time1;
                    }
                }
            }
            return totalTime;
        }

        public double GetVesselPriority(int QueueServiceStatus)
        {
            double Priority = 1;
            switch (QueueServiceStatus)
            {
                //1.Fuera de Ventana; 2.En Ventana; 3.Carga General; 4.TEH Granel; 5.Pasajero
                case 1:
                    Priority = 0.96;
                    break;
                case 2:
                    Priority = 1;
                    break;
                case 3:
                    Priority = 0.98;
                    break;
                case 4:
                    Priority = 0.97;
                    break;
                default:
                    Priority = 1;
                    break;
            }
            return Priority;
        }

        public QueueService CloneQueueService(QueueService Q, int FatherChromosomeID)
        {
            QueueService Qs = new CoEVO.QueueService(Q.ID, Q.VesselID, Q.VCategory, Q.Direction, Q.ArrivalTime, Q.AwaitingTime, Q.MOV, Q.Status,Q.ToUse);
            Qs.ID = Q.ID;
            Qs.ArrivalTime = Q.ArrivalTime;
            Qs.AwaitingTime = Q.AwaitingTime;
            //Qs.ChromosomeID = Q.ChromosomeID;
            Qs.ChromosomeID = FatherChromosomeID;
            Qs.Cost = Q.Cost;
            Qs.CrossTime = Q.CrossTime;
            Qs.CurrentDock = Q.CurrentDock;
            Qs.CurrentHour = Q.CurrentHour;
            Qs.DelayTime = Q.DelayTime;
            Qs.DepartureTime = Q.DepartureTime;
            Qs.Direction = Q.Direction;
            Qs.Fitness = Q.Fitness;
            Qs.FixedCost = Q.FixedCost;
            Qs.POPSupplyingID = Q.POPSupplyingID;
            Qs.QueueType = Q.QueueType;
            Qs.TimeInPort = Q.TimeInPort;
            Qs.Units = Q.Units;
            Qs.VariableCost = Q.VariableCost;
            return Qs;
        }

        public void SetVesselsToRealocate(ref Chromosome[] CGeral)
        {
            int OldCPD3Dock0 = Ports[2].Docks1[0].QtyVesselsToMove/2;
            int OldCPD3Dock1 = Ports[2].Docks1[1].QtyVesselsToMove/2;
            int OldCPD4Dock0 = Ports[2].Docks1[0].QtyVesselsToMove/2;
            int OldCPD4Dock1 = Ports[2].Docks1[1].QtyVesselsToMove/2;

            int NewCPD3 = Ports[3].Docks1[0].QtyVesselsToMove/2;
            int NewCPD4 = Ports[3].Docks1[0].QtyVesselsToMove/2;

            for(int CC=0; CC<CGeral.Count();CC++)
            {
                if(GetPOPSupplyingForPOPID(CGeral[CC].POPID).Group1==0)
                {
                    switch(CGeral[CC].POPID)
                    {
                        case 3:
                            VesselToRealocate(ref CGeral[CC], 3, 0, OldCPD3Dock0,1);
                            VesselToRealocate(ref CGeral[CC], 3, 1, OldCPD3Dock1,1);
                            VesselToRealocate(ref CGeral[CC], 4, 0, OldCPD4Dock0,2);
                            VesselToRealocate(ref CGeral[CC], 4, 1, OldCPD4Dock1,2);
                            break;
                        case 4:
                            VesselToRealocate(ref CGeral[CC], 3, 0, NewCPD3,1);
                            VesselToRealocate(ref CGeral[CC], 4, 0, NewCPD4,2);
                            break;
                    }
                }
            }
        }

        public void VesselToRealocate(ref Chromosome Cr, int Direction, int Dock, int QtyVesselsToMove, int NewPOP)
        {
            int QtyVesselsMoved = 0;
            int Pivot;
            
            while (QtyVesselsMoved < QtyVesselsToMove)
            {
                Pivot = 0;
                for (int i = 0; i < Cr.QueueList.Count(); i++)
                {
                    if ((Cr.QueueList[i].Direction == Direction) &&(Cr.QueueList[i].ToUse > 1))
                    {

                        if (Cr.QueueList[i].Units <= Cr.QueueList[Pivot].Units)
                        {
                            if ((Cr.QueueList[i].MOV < Cr.QueueList[Pivot].Units) && (Cr.QueueList[i].ForReAllocate == 0) && (Cr.QueueList[i].CurrentDock == Dock))
                            {
                                Pivot = i;
                            }
                        }
                    }
                }
                Cr.QueueList[Pivot].ForReAllocate = NewPOP;
                QtyVesselsMoved++;
            }
        }

        public Chromosome[] CloneChromosomeArray(Chromosome[] CGeral)
        {
            Chromosome[] Chr = new Chromosome[CGeral.Count()];
            for (int CC = 0; CC < CGeral.Count(); CC++) //Recorre los cromosomas
            {
                Chr[CC] = new Chromosome(CGeral[CC].POPID, CGeral[CC].Schedule);

                Chr[CC].AwaitingTime = CGeral[CC].AwaitingTime;
                Chr[CC].CrossTime = CGeral[CC].CrossTime;
                Chr[CC].DelayTime = CGeral[CC].DelayTime;
                Chr[CC].Fitness = CGeral[CC].Fitness;
                Chr[CC].FitnessPorts = CGeral[CC].FitnessPorts;
                Chr[CC].FitnessShips = CGeral[CC].FitnessShips;
                Chr[CC].FixedCost = CGeral[CC].FixedCost;
                Chr[CC].Movements = CGeral[CC].Movements;
                Chr[CC].POPID = CGeral[CC].POPID;
                Chr[CC].PortCost = CGeral[CC].PortCost;
                Chr[CC].PortsList = CGeral[CC].PortsList;
                Chr[CC].ShipsCost = CGeral[CC].ShipsCost;
                Chr[CC].TimeInPort = CGeral[CC].TimeInPort;
                Chr[CC].TotalPortTime = CGeral[CC].TotalPortTime;
                Chr[CC].Units = CGeral[CC].Units;
                Chr[CC].VariableCost = CGeral[CC].VariableCost;
                Chr[CC].VesselsQty = CGeral[CC].VesselsQty;
                Chr[CC].SetID(CGeral[CC].ID1);
                for (int Qs = 0; Qs < CGeral[CC].QueueList.Count(); Qs++) //recorre los barcos del cromosoma
                {
                    Chr[CC].QueueList.Add(CloneQueueService(CGeral[CC].QueueList[Qs],Chr[CC].ID1));
                }
            }
            return Chr;
        }

        public Chromosome CloneChromosome(Chromosome CGeral, int FatherChromosomeID)
        {
            Chromosome Chr = new Chromosome(CGeral.POPID, CGeral.Schedule);
            Chr.AwaitingTime = CGeral.AwaitingTime;
            Chr.CrossTime = CGeral.CrossTime;
            Chr.DelayTime = CGeral.DelayTime;
            Chr.Fitness = CGeral.Fitness;
            Chr.FitnessPorts = CGeral.FitnessPorts;
            Chr.FitnessShips = CGeral.FitnessShips;
            Chr.FixedCost = CGeral.FixedCost;
            Chr.Movements = CGeral.Movements;
            Chr.POPID = CGeral.POPID;
            Chr.PortCost = CGeral.PortCost;
            Chr.PortsList = CGeral.PortsList;
            Chr.ShipsCost = CGeral.ShipsCost;
            Chr.TimeInPort = CGeral.TimeInPort;
            Chr.TotalPortTime = CGeral.TotalPortTime;
            Chr.Units = CGeral.Units;
            Chr.VariableCost = CGeral.VariableCost;
            Chr.VesselsQty = CGeral.VesselsQty;
            //Chr.SetID(CGeral.ID1);
            Chr.SetID(FatherChromosomeID);
            for (int Qs = 0; Qs < CGeral.QueueList.Count(); Qs++) //recorre los barcos del cromosoma
            {
                Chr.QueueList.Add(CloneQueueService(CGeral.QueueList[Qs], FatherChromosomeID));
            }
            return Chr;
        }
    }
}
