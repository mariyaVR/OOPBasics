using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles
{
    public class Vehicles
    {
        public static void Main()
        {
            string[] firstLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(firstLine[1]);
            double carFuelConsumtion = double.Parse(firstLine[2]);
            string[] secondLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(secondLine[1]);
            double truckFuelConsumption = double.Parse(secondLine[2]);

            Automobile car = new Car(carFuelQuantity, carFuelConsumtion);
            Automobile truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                double support = double.Parse(command[2]); //support refers to distance or litres

                if (command[1].Equals("Car"))
                {
                    if (command[0].Equals("Drive"))
                    {
                        car.Drive(support);
                    }
                    else if (command[0].Equals("Refuel"))
                    {
                        car.Refuel(support);
                    }
                }
                else if (command[1].Equals("Truck"))
                {
                    if (command[0].Equals("Drive"))
                    {
                        truck.Drive(support);
                    }
                    else if (command[0].Equals("Refuel"))
                    {
                        truck.Refuel(support);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
