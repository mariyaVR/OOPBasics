using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract void MakeSound();

        public abstract void Eat(IFood food);
    }
}
