﻿namespace HungryPesho.Creatures
{
    using HungryPesho.Abilities;

    public class Mage : Character
    {
        private const string MageName = "Mage";
        private const string MageDescription = "Using magic to slay his opponents.";
        private const int StartingLevel = 1;
        private const int StartingHealth = 6;
        private const int StartingEnergy = 10;
        private const int StartingAgility = 5;
        private const int StartingStrength = 5;
        private const int StartingIntellect = 8;
        private const int StartingAttack = 3;
        private const int StartingInitiative = 3;
        private const int StartingExperience = 0;

        public Mage()
        {
            this.Name = MageName;
            this.Description = MageDescription;

            this.Level = StartingLevel;
            this.Experience = StartingExperience; 
            this.Health = StartingHealth;
            this.Energy = StartingEnergy;
            this.Agility = StartingAgility;
            this.Strength = StartingStrength;
            this.Intellect = StartingIntellect;
            this.Attack = StartingAttack;
            this.Initiative = StartingInitiative;
         
            LoadAbilities();
        }

        public void LoadAbilities()
        {
            // Starting mage abilities
            this.Abilities.Add(new Ability("Basic Attack", "Normal weapon attack.", AbilityEffects.DirectDamage, 0));
            this.Abilities.Add(new Ability("Frostbolt", "Damages and freezes your opponent for one turn.", AbilityEffects.Freeze, 5));
            this.Abilities.Add(new Ability("Meteor", "Inflicts massive damage to your enemy.", AbilityEffects.DirectDamage, 15));
            // Ultimates
            if (Level == 5)
            {
                this.Abilities.Add(new Ability("Energy Burn", "Burns all your's and your opponent's energy and deal damage equal to his current energy.",
              AbilityEffects.Ultimate, 1));
            }
        }
    }
}
