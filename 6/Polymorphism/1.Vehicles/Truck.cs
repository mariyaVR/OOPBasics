using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles
{
    public class Truck : Automobile
    {
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += 1.6;
        }

        public override void Drive(double distance) //it's better the method Drive not to write on the console, the method which calls it should know when to drive and wehn to write on the console
        {
            if (distance * this.FuelConsumption <= FuelQuantity)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                this.FuelQuantity -= distance * FuelConsumption;
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
            }
        }

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * 0.95;
        }
    }
}