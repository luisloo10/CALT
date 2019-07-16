using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    class VesselType
    {
        private int ID;
        private string AISVesselTypeDescription;
        private string VesselTypeCategory;
        private int ToUse;

        public VesselType(int iD, string aISVesselTypeDescription, string vesselTypeCategory, int toUse)
        {
            ID = iD;
            AISVesselTypeDescription = aISVesselTypeDescription;
            VesselTypeCategory = vesselTypeCategory;
            ToUse = toUse;
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

        public string AISVesselTypeDescription1
        {
            get
            {
                return AISVesselTypeDescription;
            }

            set
            {
                AISVesselTypeDescription = value;
            }
        }

        public string VesselTypeCategory1
        {
            get
            {
                return VesselTypeCategory;
            }

            set
            {
                VesselTypeCategory = value;
            }
        }

        public int ToUse1
        {
            get
            {
                return ToUse;
            }

            set
            {
                ToUse = value;
            }
        }
    }
}
