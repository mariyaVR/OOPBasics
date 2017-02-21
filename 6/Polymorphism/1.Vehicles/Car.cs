using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles
{
    public class Car : Automobile
    {
        public Car(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += 0.9;
        }

        public override void Drive(double distance)
        {
            if (distance * this.FuelConsumption <= this.FuelQuantity)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= distance * FuelConsumption;
            }
            else
            {
                Console.WriteLine($"Car needs refueling"); //it's better the method Drive not to write on the console, the method which calls it should know when to drive and wehn to write on the console
            }
        }

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }
    }
}
