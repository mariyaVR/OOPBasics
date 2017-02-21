using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine("Tigers are not eating that type of food!");
            }
        }
    }
}
