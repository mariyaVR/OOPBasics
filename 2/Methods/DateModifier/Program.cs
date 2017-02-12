using System;
using System.Globalization;

namespace DateModifier
{
    public class DateModifier
    {
        public static double CalculateDifference(string firstDate, string secondDate)
        {
            DateTime first = DateTime.Parse(firstDate.Trim(), CultureInfo.InvariantCulture);

            DateTime second = DateTime.Parse(secondDate.Trim(), CultureInfo.InvariantCulture);

            double totalDays = (first - second).TotalDays;
            return Math.Abs(totalDays);
        }
    }

    class Program
    {
        static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            double difference = DateModifier.CalculateDifference(firstDate, secondDate);
            Console.WriteLine(difference);
        }
    }
}