namespace HungryPesho.Creatures
{
    using System.Collections.Generic;
    using HungryPesho.Abilities;
    using HungryPesho.Interfaces;

    public class Warrior : Character
    {
        private const string WarriorDescription = "Strong and powerful character who slay his opponents with brute force!";

        private const int StartingLevel = 1;
        private const int StartingHealth = 6;
        private const int StartingEnergy = 15;
        private const int StartingAgility = 7;
        private const int StartingStrength = 5;
        private const int StartingIntellect = 15;

        private Warrior()
        {
            this.Level = StartingLevel;
            this.Health = StartingHealth;
            this.Energy = StartingEnergy;
            this.Agility = StartingAgility;
            this.Strength = StartingStrength;
            this.Intellect = StartingIntellect;

            // All warrior abilities
            this.Abilities = new List<Ability>()
            {
                new Ability("Basic Attack", "Just a hit with your weapon", AbilityEffects.DirectDamage, 0),
                new Ability("Slam", "Slam your opponent with powerfull attack", AbilityEffects.DirectDamage, 5)
            };
        }
    }
}