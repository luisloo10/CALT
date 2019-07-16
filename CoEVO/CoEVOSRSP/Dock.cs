using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    class Dock
    {
        private int ID;
        private string Description;
        private int UnitCapacity;
        private double UnitCost;
        private int MaterialType;
        private double Performance;
        //private int QueueQuantity;
        public int TotalShips;
        public int TotalHours;
        private int POPSupplyingID;
        public int QtyVesselsToMove=0;

        public Dock(int iD, string description, int unitCapacity, double unitCost, int materialType, double performance, int totalShips, int pOPSupplyingID)
        {
            ID = iD;
            Description = description;
            UnitCapacity = unitCapacity;
            UnitCost = unitCost;
            MaterialType = materialType;
            Performance = performance;
            //QueueQuantity = queueQuantity;
            TotalShips = totalShips;
            POPSupplyingID = pOPSupplyingID;
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

        public int UnitCapacity1
        {
            get
            {
                return UnitCapacity;
            }

            set
            {
                UnitCapacity = value;
            }
        }

        public double UnitCost1
        {
            get
            {
                return UnitCost;
            }

            set
            {
                UnitCost = value;
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

        public int POPSupplyingID1
        {
            get
            {
                return POPSupplyingID;
            }

            set
            {
                POPSupplyingID = value;
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

        public int MaterialType1
        {
            get
            {
                return MaterialType;
            }

            set
            {
                MaterialType = value;
            }
        }

        public double Performance1
        {
            get
            {
                return Performance;
            }

            set
            {
                Performance = value;
            }
        }
    }
}
