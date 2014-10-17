using System;

namespace HungryPesho.Creatures
{
    interface ICreature
    {
        int Attack { get; set; }

        int Health { get; set; }

        int Energy { get; set; }

        int Initiative { get; set; }
    }
}
