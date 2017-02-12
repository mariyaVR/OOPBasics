using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberInReversedOrder
{
    public class Number
    {
        private decimal num;

        public decimal Num => this.num;

        public Number(decimal num)
        {
            this.num = num;
        }


        public string Reverse()
        {
            string stringNumber = this.num.ToString();
            char[] charArray = stringNumber.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
    class Startup
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());
            Number numberForReverse = new Number(number);
            Console.WriteLine(numberForReverse.Reverse());
        }
    }
}
