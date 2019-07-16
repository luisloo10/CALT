using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    class POPDemanding
    {
        private static int currentID;

        private int VesselID;
        private string ShipName;
        private string IMO;
        private int VesselType;
        private int Direction; //{1,2} {Atlantico, Pacifico}
        private int Units;
        private int MOV;
        private double LOA;
        private double BOA;

        //private int POPSupplying; //POP where was ubicated {1,2,3,4} {PtoCortes,SanLorenzo,OldLock,NewLock

        private double Priority; //0.0 to 1.0 Priority Tax = QueueService.Status
        private double Fitness;
        
        public POPDemanding(int vesselID, string shipName, string iMO, int vesselType, int direction, int units, int mOV, double lOA, double bOA, int pOPSupplying, int awaitingTime, int crossTime, double cost, double priority)
        {
            VesselID = vesselID;
            ShipName = shipName;
            IMO = iMO;
            VesselType = vesselType;
            Direction = direction;
            Units = units;
            MOV = mOV;
            LOA = lOA;
            BOA = bOA;
            Priority = priority;
        }

        static POPDemanding()
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
        public int VesselID1
        {
            get
            {
                return VesselID;
            }

            set
            {
                VesselID = value;
            }
        }
        public string ShipName1
        {
            get
            {
                return ShipName;
            }

            set
            {
                ShipName = value;
            }
        }

        public string IMO1
        {
            get
            {
                return IMO;
            }

            set
            {
                IMO = value;
            }
        }

        public int VesselType1
        {
            get
            {
                return VesselType;
            }

            set
            {
                VesselType = value;
            }
        }

        public int Direction1
        {
            get
            {
                return Direction;
            }

            set
            {
                Direction = value;
            }
        }

        public int Units1
        {
            get
            {
                return Units;
            }

            set
            {
                Units = value;
            }
        }

        public int MOV1
        {
            get
            {
                return MOV;
            }

            set
            {
                MOV = value;
            }
        }

        public double LOA1
        {
            get
            {
                return LOA;
            }

            set
            {
                LOA = value;
            }
        }

        public double BOA1
        {
            get
            {
                return BOA;
            }

            set
            {
                BOA = value;
            }
        }

        public double Priority1
        {
            get
            {
                return Priority;
            }

            set
            {
                Priority = value;
            }
        }

        public double Fitness1
        {
            get
            {
                return Fitness;
            }

            set
            {
                Fitness = value;
            }
        }
    }
}
