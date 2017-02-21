using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }
    }
}
