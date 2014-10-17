namespace HungryPesho.Interfaces
{
    using HungryPesho.Creatures;
    using System.Collections.Generic;

    interface IEffectable
    {
        int HealthGain { get; set; }

        int EnergyGain { get; set; }
    }
}