using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; protected set; }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override void Eat(IFood food)
        {
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            string result = string.Format("{0}[{1}, {2}, {3}, {4}, {5}]",
                this.GetType().Name,
                this.Name,
                this.Breed,
                this.Weight,
                this.LivingRegion,
                this.FoodEaten);

            return result;
        }
    }
}