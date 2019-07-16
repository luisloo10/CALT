using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CoEVO
{
    class QueueService
    {
        private static int currentID;
        public int ID { get; set; }
        public int ChromosomeID;

        public int VesselID;
        public string VCategory;
        public int Direction;
        public int POPSupplyingID;
        public int Units;
        public int MOV;
        public double Cost;
        public double FixedCost;
        public double VariableCost;

        public int Status; //1. Fuera de Ventana, 2. Em Ventana, 3. Carga General, 4. Granel, 5. Pasajeros, 
        public int ToUse; //0. Not crossing; 1. Simple crossing; 2.Liquid cargo; 3.Bulk cargo; 4.Container
        public int QueueType; //1:RealShip; 2:VirtualShip
        public int ReAllocatedTime=0; //1: Fue realocado por choque en la hora de llegada/salida; 0:NO fue re-alocado
        public int ReAllocatedDock=0; //1: Fue alocado en otra compuerta; 0:NO fue re-alocado

        public DateTime ArrivalTime;
        public DateTime DepartureTime;
        public int CurrentDock;
        public int CurrentHour;

        public int TimeInPort; //AwaitingTime + CrossTime + WorkTime
        //public int ExtraTime;
        public int AwaitingTime; //AwaitingTime + Dispatching Time
        public long DelayTime;
        public int CrossTime;

        public DateTime OldArrivalTime;
        public DateTime OldDepartureTime;
        public int OldDock;
        public int OldHour;
        public int OldDirection=0;
        public int OldPOPSupplyingID=0;
        public int ForReAllocate = 0;

        public double Fitness;
        public double OldFitness;

        static QueueService()
        {
            currentID = 0;
        }
        protected int GetNextID()
        {
            return ++currentID;
        }
        public QueueService(int FirstLoad, int vesselID, string vCategory, int direction, DateTime arrivalTime, int awaitingTime, int mOV, int status, int toUse)
        {
            VesselID = vesselID;
            VCategory = vCategory;
            Direction = direction;
            ArrivalTime = arrivalTime;
            OldArrivalTime = ArrivalTime; //Se hace así para poder reiniciar los valores. (El valor original se guarda en OldArrivalTime siempre)
            AwaitingTime = awaitingTime;
            MOV = mOV;
            Status = status;
            ToUse = toUse;
            CurrentDock = -1;
            OldDock = -1;
            QueueType = 1; //1=RealShip,2=VirtualShip (Que es de otra POP en ese Puerto)
            
            if(FirstLoad==0) //Si es la primera carga, entonces se genera el ID automáticamente (i.e. ++currentID)
            {
                this.ID = GetNextID();
            }
            else
            {
                this.ID = FirstLoad; //Si no es la primera carga (i.e. cloneQueueService) entonces toma el ID que ya tiene
            }

            //Console.WriteLine(currentID + ":" + ID + ":" + vesselID);
        }

        public int GetID
        {
            get
            {
                return this.ID;
            }
        }

        public void SetID(int iD)
        {
            this.ID = iD;
        }

        public void RestartID()
        {
            this.ID = 1;
            currentID = 1;
        }
    }
}
