using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    class VesselSizes
    {
        int Generation;
        int Year;
        int TEU;
        int LOA;
        int BOA;
        int Draft;

        public int Generation1
        {
            get
            {
                return Generation;
            }

            set
            {
                Generation = value;
            }
        }

        public int Year1
        {
            get
            {
                return Year;
            }

            set
            {
                Year = value;
            }
        }

        public int TEU1
        {
            get
            {
                return TEU;
            }

            set
            {
                TEU = value;
            }
        }

        public int LOA1
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

        public int BOA1
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

        public int Draft1
        {
            get
            {
                return Draft;
            }

            set
            {
                Draft = value;
            }
        }

        public VesselSizes(int generation, int year, int tEU, int lOA, int bOA, int draft)
        {
            Generation = generation;
            Year = year;
            TEU = tEU;
            LOA = lOA;
            BOA = bOA;
            Draft = draft;
        }
    }
}
