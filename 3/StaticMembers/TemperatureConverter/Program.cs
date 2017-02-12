using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    class Program
    {
        static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                string[] inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs[1].Equals("Celsius"))
                {
                    ToFahrenheit(double.Parse(inputArgs[0]));
                }
                else
                {
                    ToCelsius(double.Parse(inputArgs[0]));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(result);
        }

        public static void ToFahrenheit(double degrees)
        {
            var converted = degrees * 1.8 + 32;
            result.AppendLine($"{converted:F2} Fahrenheit");
        }

        public static void ToCelsius(double degress)
        {
            var converted = (degress - 32) / 1.8;
            result.AppendLine($"{converted:F2} Celsius");
        }
    }
}