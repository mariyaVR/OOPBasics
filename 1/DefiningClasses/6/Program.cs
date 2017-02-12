using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Car
{
    public string model;
    public Engine engine;
    public Cargo cargo;
    public Tire[] tires;

    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }
}

public class Engine
{
    public int speed;
    public int power;

    public Engine(int speed, int power)
    {
        this.speed = speed;
        this.power = power;
    }
}

public class Cargo
{
    public int weight;
    public string type;

    public Cargo(int weight, string type)
    {
        this.weight = weight;
        this.type = type;
    }
}

public class Tire
{
    public double pressure;
    public int age;

    public Tire(double pressure, int age)
    {
        this.pressure = pressure;
        this.age = age;
    }
}

public class Startup
{
    static void Main()
    {
        List<Car> cars = new List<Car>();
        StringBuilder result = new StringBuilder();

        int numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string carModel = carArgs[0];

            int engineSpeed = int.Parse(carArgs[1]);
            int enginePower = int.Parse(carArgs[2]);

            int cargoWeight = int.Parse(carArgs[3]);
            string cargoTipe = carArgs[4];

            double firstTirePressure = double.Parse(carArgs[5]);
            int firstTireAge = int.Parse(carArgs[6]);
            double secondTirePressure = double.Parse(carArgs[7]);
            int secondTireAge = int.Parse(carArgs[8]);
            double thirdTirePressure = double.Parse(carArgs[9]);
            int thirdTireAge = int.Parse(carArgs[10]);
            double fourthTirePressure = double.Parse(carArgs[11]);
            int fourthTireAge = int.Parse(carArgs[12]);

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoTipe);
            Tire firstTire = new Tire(firstTirePressure, firstTireAge);
            Tire secondTire = new Tire(secondTirePressure, secondTireAge);
            Tire thirdTire = new Tire(thirdTirePressure, thirdTireAge);
            Tire fourthTire = new Tire(fourthTirePressure, fourthTireAge);
            Tire[] tires = new Tire[]
            {
                firstTire,
                secondTire,
                thirdTire,
                fourthTire
            };

            Car currentCar = new Car(
                carModel,
                engine,
                cargo,
                tires);

            cars.Add(currentCar);
        }

        string command = Console.ReadLine();

        if (command.Equals("fragile"))
        {
            IEnumerable<Car> fragileCars = cars
                .Where(c => c.cargo.type.Equals("fragile") &&
                c.tires.Any(t => t.pressure < 1));

            foreach (Car fragileCar in fragileCars)
            {
                result.AppendLine($"{fragileCar.model}");
            }
        }
        else
        {
            IEnumerable<Car> flamable = cars
                .Where(c => c.cargo.type.Equals("flamable"))
                .Where(c => c.engine.power > 250);

            foreach (Car fragileCar in flamable)
            {
                result.AppendLine($"{fragileCar.model}");
            }
        }

        Console.Write(result);
    }
}