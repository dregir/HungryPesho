namespace HungryPesho.Interfaces
{
    using HungryPesho.Creatures;

    public interface IEffectable
    {
        int HealthGained { get; set; }

        int EnergyGained { get; set; }
    }
}