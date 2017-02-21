using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; protected set; }

        public override string ToString()
        {
            string result = string.Format("{0}[{1}, {2}, {3}, {4}]",
                this.GetType().Name,
                this.Name,
                this.Weight,
                this.LivingRegion,
                this.FoodEaten);

            return result;
        }
    }
}
