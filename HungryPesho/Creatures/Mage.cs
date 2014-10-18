namespace HungryPesho.Creatures
{
    using System.Collections.Generic;
    using HungryPesho.Abilities;
    using HungryPesho.Interfaces;

    public class Mage : Character
    {
        private const string MageDescription = "Using magic to slay his opponents.";

        private const int StartingLevel = 1;
        private const int StartingHealth = 6;
        private const int StartingEnergy = 30;
        private const int StartingAgility = 7;
        private const int StartingStrength = 5;
        private const int StartingIntellect = 15;
        private const int StartingAttack = 2;
        private const int StartingInitiative = 4;

        public Mage()
        {
            this.Level = StartingLevel;
            this.Health = StartingHealth;
            this.Energy = StartingEnergy;
            this.Agility = StartingAgility;
            this.Strength = StartingStrength;
            this.Intellect = StartingIntellect;
            this.Attack = StartingAttack;
            this.Initiative = StartingInitiative;

            // Starting mage abilities
            this.Abilities.Add(new Ability("Basic Attack", "Just a hit with your magic", AbilityEffects.DirectDamage, 0));
            this.Abilities.Add(new Ability("Freeze", "Freeze your opponent missing one turn", AbilityEffects.Freeze, 5));
        }
    }
}