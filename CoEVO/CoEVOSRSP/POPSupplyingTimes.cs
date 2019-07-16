using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    class POPSupplyingTimes
    {
        private int ID;
        private string Description;
        private int Time;
        private int TypeTime;
        private int POPSupplyingID;

        public POPSupplyingTimes(int iD, string description, int time, int typeTime, int pOPSupplyingID)
        {
            ID = iD;
            Description = description;
            Time = time;
            TypeTime = typeTime;
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

        public int Time1
        {
            get
            {
                return Time;
            }

            set
            {
                Time = value;
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

        public int TypeTime1
        {
            get
            {
                return TypeTime;
            }

            set
            {
                TypeTime = value;
            }
        }
    }
}
