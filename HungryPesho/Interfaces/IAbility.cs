namespace HungryPesho.Interfaces
{
    using HungryPesho.Abilities;

    interface IAbility
    {
        string Name { get; set; }

        int EnergyCost { get; set; }

        AbilityEffects AbilityEffect { get; set; }
    }
}