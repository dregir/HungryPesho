namespace HungryPesho.Interfaces
{
    using HungryPesho.Abilities;

    interface IAbility
    {
        string Name { get; set; }

        double ManaCost { get; set; }

        AbilityEffects AbilityEffect { get; set; }
    }
}