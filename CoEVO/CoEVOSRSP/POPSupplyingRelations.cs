using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    class POPSupplyingRelations
    {
        int POPID;
        int Relation;

        public POPSupplyingRelations(int pOPID, int relation)
        {
            POPID = pOPID;
            Relation = relation;
        }

        public int POPID1
        {
            get
            {
                return POPID;
            }

            set
            {
                POPID = value;
            }
        }

        public int Relation1
        {
            get
            {
                return Relation;
            }

            set
            {
                Relation = value;
            }
        }
    }
}
