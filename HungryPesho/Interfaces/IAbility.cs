namespace HungryPesho.Abilities
{
    interface IAbility
    {
        string Name { get; set; }

        string Description { get; set; }

        AbilityEffects AbilityEffect { get; set; }
    }
}