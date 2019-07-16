using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    class FitnessHistory
    {
        public int ID;
        public int ChromosomeID;
        public int POPSupplyingID;
        public double FitnessPorts;
        public double FitnessShips;
        public double FitnessChromosome;
        public int stage; //1.Allocation (GA); 2.Re-Allocation(CoEA)
    }
}
