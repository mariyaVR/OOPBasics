using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanckConstant
{
    public class Calculation
    {
        public static double PI = 3.14159;
        public static double PLANCK = 6.62606896e-34;

        public static double ReducePlank()
        {
            return PLANCK / (2 * PI);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculation.ReducePlank());
        }
    }
}
