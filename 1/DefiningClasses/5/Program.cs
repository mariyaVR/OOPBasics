using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Car
    {
        public string model;
        public double fuel;
        public double fuelConsumption;
        public double distanceTraveled;

        public Car(string model, double fuel, double fuelConsumption)
        {
            this.model = model;
            this.fuel = fuel;
            this.fuelConsumption = fuelConsumption;
            this.distanceTraveled = 0; //works without it too
        }

        public void Drive(int amountOfKilometers)
        {
            if (amountOfKilometers <= this.fuel / this.fuelConsumption)
            {
                this.distanceTraveled += amountOfKilometers;
                this.fuel -= this.fuelConsumption * amountOfKilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuel = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car car = new Car(model, fuel, fuelConsumption);
                cars.Add(car);
            }

            string driveCommand = Console.ReadLine();
            while (driveCommand != "End")
            {
                string[] driveCommandArgs = driveCommand.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                string carModel = driveCommandArgs[1];
                int amountOfKilometers = int.Parse(driveCommandArgs[2]);
                Car carToDrive = cars.First(c => c.model == carModel);
                carToDrive.Drive(amountOfKilometers);
                driveCommand = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine("{0} {1:F2} {2}", car.model, car.fuel, car.distanceTraveled);
            }
        }
    }
}