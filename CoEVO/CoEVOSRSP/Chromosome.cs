using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoEVO
{
    class Chromosome
    {
        private static int currentID;
        public int POPID;
        public int[,] Schedule; //x=Docks/ y=ID de QuequeService (barcos que deben pasar por ese lugar)
        public List<QueueService> QueueList = new List<QueueService>();
        public List<POPSupplying> PortsList = new List<POPSupplying>();
        public DataGrid GridSchedule;
        public ListBox ListBox;

        public int VesselsQty;
        public int Units;
        public int Movements;

        public int AwaitingTime;
        public int TimeInPort;
        public int CrossTime;
        //public int ExtraTime;
        public long DelayTime;
        public long IdleTime;
        public long TotalPortTime; //Difference between LastArrivalTime - FirstArrivalTime

        public double ShipsCost;
        public double PortCost; //Reducir BarcosPequeños
        public double FixedCost;
        public double VariableCost;

        public double Fitness;
        public double FitnessPorts;
        public double FitnessShips;

        public Chromosome(int POP_ID,int [,] schedule)
        {
            POPID = POP_ID;
            Schedule = schedule;
            this.ID = GetNextID();
            
        }

        public void RestartValues()
        {
            VesselsQty = 0;
            Units = 0;
            Movements = 0;
            AwaitingTime = 0;
            CrossTime = 0;
            DelayTime = 0;
            TimeInPort = 0;
            ShipsCost = 0;
            PortCost = 0;
            FixedCost = 0;
            VariableCost = 0;
            FitnessPorts = 0;
            FitnessShips = 0;
            Fitness = 0;
        }

        public void SetFitness()
        {
            Fitness = 1;
        }

        static Chromosome()
        {
            currentID = -1;
        }
        protected int ID { get; set; }

        public static int CurrentID
        {
            get
            {
                return currentID;
            }

            set
            {
                currentID = value;
            }
        }

        public int ID1
        {
            get
            {
                return this.ID;
            }
        }

        protected int GetNextID()
        {
            return ++currentID;
        }

        public void RestartID()
        {
            //this.ID = 0;
            CurrentID = -1;
        }

        public void SetID(int iD)
        {
            this.ID = iD;
        }
    }
}
