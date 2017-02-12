using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChecker
{
    public class Number
    {
        private int numb;
        private bool isPrime;
        public int Numb => this.numb;
        public bool IsPrime => this.isPrime;

        public Number(int number)
        {
            this.numb = number;
            this.isPrime = IsPrimeCheck(number);
        }
        public int NextPrime()
        {
            for (int i = this.numb + 1; i < 2 * i; i++)
            {
                if (IsPrimeCheck(i))
                {
                    return i;
                }
            }

            return 0;
        }
        static bool IsPrimeCheck(int num)
        {
            var maxDivider = Math.Sqrt(num);

            for (int divider = 2; divider <= maxDivider; divider++)
            {
                if (num % divider == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
    class Startup
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Number newNumb = new Number(number);

            int nextPrime = newNumb.NextPrime();

            Console.WriteLine($"{nextPrime}, {newNumb.IsPrime.ToString().ToLower()}");
        }
    }
}
