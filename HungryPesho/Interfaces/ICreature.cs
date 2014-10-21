namespace HungryPesho.Interfaces
{
    using System;
    using System.Collections.Generic;
    using HungryPesho.Abilities;

    public interface ICreature
    {
        int Attack { get; set; }

        int Health { get; set; }

        int Energy { get; set; }

        int Initiative { get; set; }

        List<Ability> Abilities { get; set; }

        void AddAbilities(Ability[] abilities);
    }
}