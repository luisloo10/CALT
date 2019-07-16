using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    class Rates
    {
        int OPID;
        int RateID;
        string Operation;
        string Reference;
        int BaseRate; //1:General 2:each MOV
        double Rate;
        int POPSupplyingID;

        public Rates(int opID, int rateID, string operation, string reference, int baseRate, double rate, int pOPSupplyingID)
        {
            OPID = opID;
            RateID = rateID;
            Operation = operation;
            Reference = reference;
            BaseRate = baseRate;
            Rate = rate;
            POPSupplyingID = pOPSupplyingID;
        }

        public string Operation1
        {
            get
            {
                return Operation;
            }

            set
            {
                Operation = value;
            }
        }

        public string Reference1
        {
            get
            {
                return Reference;
            }

            set
            {
                Reference = value;
            }
        }

        public int BaseRate1
        {
            get
            {
                return BaseRate;
            }

            set
            {
                BaseRate = value;
            }
        }

        public double Rate1
        {
            get
            {
                return Rate;
            }

            set
            {
                Rate = value;
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

        public int OPID1
        {
            get
            {
                return OPID;
            }

            set
            {
                OPID = value;
            }
        }

        public int RateID1
        {
            get
            {
                return RateID;
            }

            set
            {
                RateID = value;
            }
        }
    }
}
