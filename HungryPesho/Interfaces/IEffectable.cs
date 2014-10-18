namespace HungryPesho.Interfaces
{
    using HungryPesho.Creatures;

    interface IEffectable
    {
        int HealthGained { get; set; }

        int EnergyGained { get; set; }
    }
}