using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    class POPSupplying
    {
        private int ID;
        private string Description;
        private int Group;
        private Dock[] Docks;
        private double AwaitingTime;
        public double DelayTime;
        private double Earn;
        private int MovementRate;
        private int Crane;
        private double EnvironmentConstant; //0.0 to 1.0 where 0.0 free pass and 1.0 imposibility to pass
        //private int QueueQuantity;
        public int TotalShips;
        public int TotalUnits;
        public int TotalMovs;
        private double Fitness;

        public POPSupplying(int iD, string description, Dock[] docks, double earn, int movementRate, int crane, double environmentConstant, int group)
        {
            ID = iD;
            Description = description;
            Docks = docks;
            Earn = earn;
            MovementRate = movementRate;
            Crane = crane;
            EnvironmentConstant = environmentConstant;
            Group = group;
        }

        public void RestartValues()
        {
            AwaitingTime1 = 0;
            DelayTime = 0;
            Earn = 0;
            TotalShips = 0;
            TotalUnits = 0;
            TotalMovs = 0;
        }
        public int ID1
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        internal Dock[] Docks1
        {
            get
            {
                return Docks;
            }

            set
            {
                Docks = value;
            }
        }

        public double AwaitingTime1
        {
            get
            {
                return AwaitingTime;
            }

            set
            {
                AwaitingTime = value;
            }
        }

        public double Earn1
        {
            get
            {
                return Earn;
            }

            set
            {
                Earn = value;
            }
        }

        public double EnvironmentConstant1
        {
            get
            {
                return EnvironmentConstant;
            }

            set
            {
                EnvironmentConstant = value;
            }
        }

        public int Group1
        {
            get
            {
                return Group;
            }

            set
            {
                Group = value;
            }
        }

        //public int QueueQuantity1
        //{
        //    get
        //    {
        //        return QueueQuantity;
        //    }

        //    set
        //    {
        //        QueueQuantity = value;
        //    }
        //}

        public int TotalShips1
        {
            get
            {
                return TotalShips;
            }

            set
            {
                TotalShips = value;
            }
        }

        public string Description1
        {
            get
            {
                return Description;
            }

            set
            {
                Description = value;
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

        public int MovementRate1
        {
            get
            {
                return MovementRate;
            }

            set
            {
                MovementRate = value;
            }
        }

        public int Crane1
        {
            get
            {
                return Crane;
            }

            set
            {
                Crane = value;
            }
        }

        public double AwaitingTime2
        {
            get
            {
                return AwaitingTime;
            }

            set
            {
                AwaitingTime = value;
            }
        }
    }
}
