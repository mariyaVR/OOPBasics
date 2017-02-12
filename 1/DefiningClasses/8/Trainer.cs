using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Trainer
{
    public string name;
    public int badges;
    public List<Pokemon> pokemon;

    public Trainer(string name, int badges, List<Pokemon> pokemon)
    {
        this.name = name;
        badges = 0;
        this.pokemon = pokemon;
    }
}

