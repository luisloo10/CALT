using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoEVO
{
    public static class Globals
    {
        public static int IterationsGA { get; set; }
        public static int IterationsCoEA;
        public static int IniPOPSize;
        public static double CrossoverRate;
        public static double MutationRate;
        public static int CompareType; //1=Ships; 2=Ports; 3=All

        //public static DateTime From;
        //public static DateTime To;
        public static string From;
        public static string To;
    }
}
