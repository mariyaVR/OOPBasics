using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                var animal = CreateAnimal(input);
                var food = CreateFood(Console.ReadLine());

                animal.MakeSound();
                animal.Eat(food);
                Console.WriteLine(animal);

                input = Console.ReadLine();
            }
        }

        private static Food CreateFood(string input)
        {
            var foodInfo = SplitInput(input);

            string type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            if (type == "Vegetable")
            {
                return new Vegetable(quantity);
            }

            return new Meat(quantity);
        }

        private static Animal CreateAnimal(string input)
        {
            var animalInfo = SplitInput(input);

            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            string livingRegion = animalInfo[3];

            if (type == "Mouse")
            {
                return new Mouse(name, weight, livingRegion);
            }
            if (type == "Zebra")
            {
                return new Zebra(name, weight, livingRegion);
            }
            if (type == "Tiger")
            {
                return new Tiger(name, weight, livingRegion);
            }

            string breed = animalInfo[4];
            return new Cat(name, weight, livingRegion, breed);
        }

        private static string[] SplitInput(string input)
        {
            return input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}