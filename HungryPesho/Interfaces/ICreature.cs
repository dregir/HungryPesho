namespace HungryPesho.Interfaces
{
    using System;

    interface ICreature
    {
        int Attack { get; set; }

        int Health { get; set; }

        int Energy { get; set; }

        int Initiative { get; set; }
    }
}
