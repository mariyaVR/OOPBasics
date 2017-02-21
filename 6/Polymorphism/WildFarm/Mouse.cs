using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("SQUEEEAAAK!");
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable)
            {
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine("Mice are not eating that type of food!");
            }
        }
    }
}
