using System;

namespace HungryPesho.Creatures
{
    interface ICreature
    {
        string Name { get; set; }

        double Attack { get; set; }

        double Health { get; set; }

        double Mana { get; set; }

        double Initiative { get; set; }
    }
}
