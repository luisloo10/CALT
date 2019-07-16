using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CoEVO
{
    class CoEvolution
    {
        public POPDemanding[] Ships;
        public VesselType[] VesselTypes;
        public VesselSizes[] VesselSizes;
        public POPSupplying[] Ports;
        public POPSupplyingRelations[] PortsRelations;
        public POPSupplyingTimes[] PortTimes;
        public Rates[] Rates;
        public QueueService[] Queue;

        public Utils Utilities;
        public int IniPOPSize;
        public int Hours;
        public int CompareType; //1=Ships; 2=Ports; 3=All

        Random rnd = new Random();

        /*Pseudocode
          
         For each POP in POPULATIONS do
             Initialize POP
             Select EVALUATORS from (POPULATIONS - POP)
             Evaluate INDIVIDUALS from POP by interacting with EVALUATORS
         End For

         While not DONE do
             For each POP in POPULATIONS do
                Select PARENTS from POP
                Produce CHILDREN from PARENTS via variation
                Select EVALUATORS from (POPULATION - POP)
                Evaluate INDIVIDUALS from CHILDREN by interacting with EVALUATORS
                Select SURVIVORS for next generation
             End For
         End While
         return SOLUTION
        */

        public void IniPOP(POPDemanding[] ships, VesselType[] vesselsType, VesselSizes[] vesselSizes, POPSupplying[] ports, POPSupplyingRelations[] portsRelations, POPSupplyingTimes[] portTimes, Rates[] rates, QueueService[] QueueServiceIni, int iniPOPSize, int compareType)
        {
            Ships = ships;
            VesselTypes = vesselsType;
            VesselSizes = vesselSizes;
            Ports = ports;
            PortsRelations = portsRelations;
            PortTimes = portTimes;
            Rates = rates;
            Queue = QueueServiceIni;
            IniPOPSize = iniPOPSize;
            CompareType = compareType;

            Utilities = new CoEVO.Utils(ships, ports, portsRelations, PortTimes, Rates, vesselsType, VesselSizes, Queue, IniPOPSize);   
            
        }

        public void ExecuteGA(int IterationsGA, double CrossoverRate)
        {
            Utilities.FitnessHistory.Clear();
            
            int cont = 0;
            while(cont<IterationsGA)
            {
                GA(ref Utilities.C, ref Utilities.Children, CrossoverRate);
                SetValuesForChromosomes(ref Utilities.Children);
                CompareChromosomes(ref Utilities.C, ref Utilities.Children, CompareType);
                SaveBestFitness(cont, Utilities.C,1);
                cont++;
            }
        }

        public void GA(ref Chromosome[] CFather, ref Chromosome[] CChildren, double CrossoverRate)
        {
            CChildren = Utilities.CloneChromosomeArray(CFather);
            QueueService Pivot;
            int NewCurrentDock;
            int NewCurrentHour;
            int PivotDock;
            int PivotHour;

            int NextItem = 0;
            int QtyShipsonList = 0;

            for (int CC = 0; CC < CChildren.Count(); CC++) //Recorre los cromosomas
            {
                QtyShipsonList = Convert.ToInt16(Convert.ToDouble(CChildren[CC].QueueList.Count() * CrossoverRate));
                for (int Qs = 0; Qs < QtyShipsonList; Qs++) //recorre los barcos del cromosoma
                {
                    if (CChildren[CC].QueueList.Count() > 1) //que haya +1 barcos asignados al puerto
                    {
                        NextItem = rnd.Next(0, CChildren[CC].QueueList.Count() - 1);
                        while ((NextItem == Qs) || (CChildren[CC].QueueList[Qs].Direction != CChildren[CC].QueueList[NextItem].Direction))
                        {
                            NextItem = rnd.Next(0, CChildren[CC].QueueList.Count() - 1);
                            //VER QUE EL ELEMENTO EN NEXTITEM SEA DE LA MISMA DIRECTION
                        }

                        //Guarda las Dock y Hours antes de ser cambiados los barcos
                        PivotDock = CChildren[CC].QueueList[Qs].CurrentDock;
                        PivotHour = CChildren[CC].QueueList[Qs].CurrentHour;
                        NewCurrentDock = CChildren[CC].QueueList[NextItem].CurrentDock;
                        NewCurrentHour = CChildren[CC].QueueList[NextItem].CurrentHour;

                        Pivot = Utilities.CloneQueueService(CChildren[CC].QueueList[Qs], CChildren[CC].ID1);
                        if (Pivot.Direction == CChildren[CC].QueueList[Qs].Direction)
                        {
                            //Change position of the vessels in the array
                            CChildren[CC].QueueList[Qs] = CChildren[CC].QueueList[NextItem];
                            CChildren[CC].QueueList[NextItem] = Utilities.CloneQueueService(Pivot, CChildren[CC].ID1);

                            //Cambiar de Dock y Hour con el elemento
                            CChildren[CC].QueueList[Qs].CurrentDock = PivotDock;
                            CChildren[CC].QueueList[Qs].CurrentHour = PivotHour;
                            CChildren[CC].QueueList[NextItem].CurrentDock = NewCurrentDock;
                            CChildren[CC].QueueList[NextItem].CurrentHour = NewCurrentHour;
                        }
                    }
                }
            }
        }

        public void ExecuteCoEA(int IterationsCoEA, int IterationsGA, double CrossoverRate, double MutationRate)
        {
            Utilities.FitnessHistory.Clear();

            int cont = 0;
            //while(cont<IterationsCoEA)
            while (cont < 1)
            {
                CoEA(ref Utilities.C, ref Utilities.Children, MutationRate);
                //SetValuesForChromosomes(ref Utilities.Children);
                SetValuesForChromosomes(ref Utilities.C);

                //ExecuteGA(IterationsGA, CrossoverRate);
                ExecuteGA(IterationsCoEA, CrossoverRate);

                //CompareChromosomes(ref Utilities.C, ref Utilities.Children, CompareType);
                //SaveBestFitness(cont, Utilities.C,2);
                cont++;
            }
        }

        public void CoEA(ref Chromosome[] CFather, ref Chromosome[] CChildren, double mutationRate)
        {
            CChildren = Utilities.CloneChromosomeArray(CFather);
            SetQtyVesselsToMove(ref Ports, mutationRate);
            Utilities.SetVesselsToRealocate(ref CFather);
            MoveVessel(ref CFather);
            ClearVesselOvers(ref CFather);
            FixDocksAndHours(ref CFather);

            //Funcion para comparar Chromsomes con nuevos barcos
        }

        public void FixDocksAndHours(ref Chromosome[] CGeral)
        {
            int CurrentHour;
            int CurrentDock;
            double TotalDocks;
            double TotalHours;

            for (int CC = 0; CC < CGeral.Count(); CC++)
            {
                CurrentHour = 0;
                CurrentDock = 0;
                TotalDocks = Utilities.GetPOPSupplyingForPOPID(CGeral[CC].POPID).Docks1.Count();
                TotalHours = Math.Ceiling(CGeral[CC].QueueList.Count() / TotalDocks);

                for (int i = 0; i < CGeral[CC].QueueList.Count(); i++)
                {
                    if ((CGeral[CC].ID1 % 2) == 0) //Ubica en la hora 0 en Dock 1,2,3...; luego hora 1 en Dock 1,2,3
                    {       
                        CGeral[CC].QueueList[i].CurrentDock = CurrentDock;
                        CGeral[CC].QueueList[i].CurrentHour = CurrentHour;
                        CurrentDock++;
                       
                        if(CurrentDock==TotalDocks)
                        {
                            CurrentDock = 0;
                            CurrentHour++;
                        }

                        if (Utilities.GetPOPSupplyingForPOPID(CGeral[CC].POPID).Group1 == 0) //Esta condicion aplica solo para el Canal de Panama
                        {
                            if (i < CGeral[CC].QueueList.Count() - 1) //Hasta el último menos 1, para que no de error
                            {
                                if (CGeral[CC].QueueList[i].Direction != CGeral[CC].QueueList[i + 1].Direction)//Compara La direccion actual versus la dirección del sigueinte barco. Si son diferentes,entonces debe reiniciar la esclusa, porque es del otro lado del oceáno
                                {
                                    CurrentHour = 0;
                                    CurrentDock = 0;
                                }
                            }
                        }
                    }
                    else //Ubica en Dock en Hora 0,1,2,3,4...
                    {
                        CGeral[CC].QueueList[i].CurrentDock = CurrentDock;
                        CGeral[CC].QueueList[i].CurrentHour = CurrentHour;
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

                        if (Utilities.GetPOPSupplyingForPOPID(CGeral[CC].POPID).Group1 == 0) //Esta condicion aplica solo para el Canal de Panama
                        {
                            if ((CurrentHour == ((GetVesselQtyByDirectionAndPOPID_InChromosome(CGeral[CC], CGeral[CC].QueueList[i].Direction, CGeral[CC].QueueList[i].POPSupplyingID)) + 1) / 2) && Utilities.GetPOPSupplyingForPOPID(CGeral[CC].QueueList[i].POPSupplyingID).Docks1.Count() > 1)
                            {
                                CurrentHour = 0;
                                CurrentDock++;
                            }

                            if (i < CGeral[CC].QueueList.Count() - 1) //Hasta el último menos 1, para que no de error
                            {
                                if (CGeral[CC].QueueList[i].Direction != CGeral[CC].QueueList[i + 1].Direction)//Compara La direccion actual versus la dirección del sigueinte barco. Si son diferentes,entonces debe reiniciar la esclusa, porque es del otro lado del oceáno
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

        public int GetVesselQtyByDirectionAndPOPID_InChromosome(Chromosome Cr, int Direction, int POPID)
        {
            int Qty = 0;
            foreach(QueueService Q in Cr.QueueList)
            {
                if (Q.Direction == Direction && Q.POPSupplyingID == POPID)
                {
                    
                    Qty++;
                }
            }
            return Qty;
        }

        public void SetQtyVesselsToMove(ref POPSupplying[] ports, double mutationRate)
        {
            foreach (POPSupplying P in ports) //Establece en cada Dock la cantidad de barcos que debe re-allocar
            {
                if (P.Group1 == 0)
                {
                    foreach (Dock D in P.Docks1)
                    {
                        D.QtyVesselsToMove = Convert.ToInt16(D.TotalShips * mutationRate);
                    }
                }
            }
        }

        public void MoveVessel(ref Chromosome[] CGeral)
        {
            for(int CC=0;CC<CGeral.Count();CC++)
            {
                for(int i=0;i<CGeral[CC].QueueList.Count();i++)
                {
                    if(CGeral[CC].QueueList[i].ForReAllocate>0)
                    {
                        switch(CGeral[CC].QueueList[i].ForReAllocate)
                        {
                            case 1:
                                if ((CGeral[CC].QueueList[i].ChromosomeID == 4)||(CGeral[CC].QueueList[i].ChromosomeID == 6))
                                {
                                    CGeral[0].QueueList.Add(ChangeVessel(ref CGeral,CC, i, 0, 1));
                                    CGeral[1].QueueList.Add(ChangeVessel(ref CGeral, CC,i, 1, 1));
                                }
                                break;
                            case 2:
                                if ((CGeral[CC].QueueList[i].ChromosomeID == 4) || (CGeral[CC].QueueList[i].ChromosomeID == 6))
                                {
                                    CGeral[2].QueueList.Add(ChangeVessel(ref CGeral, CC, i, 2, 2));
                                    CGeral[3].QueueList.Add(ChangeVessel(ref CGeral, CC, i, 3, 2));
                                }
                                break;
                        }
                    }
                }
            }
        }

        public QueueService ChangeVessel(ref Chromosome[] CGeral, int CC, int i, int ChromosomeID, int POPID)
        {
            QueueService Q = Utilities.CloneQueueService(CGeral[CC].QueueList[i], CGeral[CC].QueueList[i].ChromosomeID);
            Q.OldPOPSupplyingID = Q.POPSupplyingID;
            Q.OldDirection = Q.Direction;
            Q.OldDock = Q.CurrentDock;
            Q.OldHour = Q.CurrentHour;
            Q.OldFitness = Q.Fitness;
            Q.Cost = 0;
            Q.FixedCost = 0;
            Q.VariableCost = 0;

            Q.ChromosomeID = ChromosomeID;
            Q.POPSupplyingID = POPID;
            Q.Direction = POPID;
            Q.ArrivalTime = Q.OldArrivalTime;
            Q.DepartureTime = Q.OldDepartureTime;

            return Q;
        }

        public void ClearVesselOvers(ref Chromosome[] CGeral)
        {
            for (int CC = 0; CC < CGeral.Count(); CC++)
            {
                for (int i = 0; i < CGeral[CC].QueueList.Count(); i++)
                {
                    if (CGeral[CC].QueueList[i].ForReAllocate > 0)
                    {
                        CGeral[CC].QueueList.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        public void SetValuesForChromosomes(ref Chromosome[] CChildren)
        {
            Utilities.CleanChromosomes(ref CChildren);
            Utilities.SetTimes(ref CChildren);
            Utilities.SetCosts(ref CChildren);
            Utilities.CalculateArrivalTimesErrors(ref CChildren);
            Utilities.FitnessFunctionForAllCromosomes(ref CChildren);
            Utilities.SetFitnessToSupplyingPOP(ref CChildren, ref Ports);

            foreach(Chromosome Cr in CChildren)
            {
                Utilities.SetFinalFitnessForChromosomes(ref CChildren, Cr.POPID);
            }
        }

        public void CompareChromosomes(ref Chromosome[] CFather, ref Chromosome[] CChildren, int CompareType)
        {
            Chromosome Pivot;
            for (int Cf = 0; Cf < CFather.Count(); Cf++)
            {
                for (int Cc = 0; Cc < CChildren.Count(); Cc++)
                {
                    if (CFather[Cf].POPID == CChildren[Cc].POPID)
                    {
                        switch (CompareType)
                        {
                            case 1: //FitnessShip
                                if (CChildren[Cc].FitnessShips > CFather[Cf].FitnessShips)
                                {
                                    Pivot = Utilities.CloneChromosome(CFather[Cf], CFather[Cf].ID1);
                                    CFather[Cf] = Utilities.CloneChromosome(CChildren[Cc], CFather[Cf].ID1);
                                    CChildren[Cc] = Utilities.CloneChromosome(Pivot, CFather[Cf].ID1);
                                }
                                break;

                            case 2: //FitnessPort
                                if (CChildren[Cc].FitnessPorts > CFather[Cf].FitnessPorts)
                                {
                                    Pivot = Utilities.CloneChromosome(CFather[Cf], CFather[Cf].ID1);
                                    CFather[Cf] = Utilities.CloneChromosome(CChildren[Cc], CFather[Cf].ID1);
                                    CChildren[Cc] = Utilities.CloneChromosome(Pivot, CFather[Cf].ID1);
                                }
                                break;
                            case 3://FitnessChromosome
                                if (CChildren[Cc].Fitness > CFather[Cf].Fitness)
                                {
                                    Pivot = Utilities.CloneChromosome(CFather[Cf], CFather[Cf].ID1);
                                    CFather[Cf] = Utilities.CloneChromosome(CChildren[Cc], CFather[Cf].ID1);
                                    CChildren[Cc] = Utilities.CloneChromosome(Pivot, CFather[Cf].ID1);
                                }
                                break;
                        }
                    }
                }
            }
            //Console.WriteLine(Utilities.C[0].QueueList.Count() + ":" + Utilities.C[1].QueueList.Count());
        }

        public void SaveBestFitness(int Iteration, Chromosome[] C, int Stage)
        {
            int cont = 0;
            foreach (Chromosome Cr in C)
            {
                FitnessHistory F = new CoEVO.FitnessHistory();
                F.ID = Iteration;
                F.ChromosomeID = Cr.ID1;
                F.POPSupplyingID = Cr.POPID;
                F.FitnessPorts = Cr.FitnessPorts;
                F.FitnessShips=Cr.FitnessShips;
                F.FitnessChromosome = Cr.Fitness;
                F.stage = Stage;
                Utilities.FitnessHistory.Add(F);
                cont++;
            }
        }

        public double NextDouble(double minValue, double maxValue)
        {
            return rnd.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
