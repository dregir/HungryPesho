﻿namespace HungryPesho.Creatures
{
    using System.Collections.Generic;
    using HungryPesho.Abilities;
    using HungryPesho.Interfaces;

    public class Warrior : Character
    {
        private const string WarriorName = "Warrior";
        private const string WarriorDescription = "Strong and powerful character who slay his opponents with brute force!";

        private const int StartingLevel = 1;
        private const int StartingHealth = 6;
        private const int StartingEnergy = 15;
        private const int StartingAgility = 7;
        private const int StartingStrength = 5;
        private const int StartingIntellect = 15;
        private const int StartingAttack = 5;
        private const int StartingInitiative = 3;

        public Warrior()
        {
            this.Name = WarriorName;
            this.Description = WarriorDescription;

            this.Level = StartingLevel;
            this.Health = StartingHealth;
            this.Energy = StartingEnergy;
            this.Agility = StartingAgility;
            this.Strength = StartingStrength;
            this.Intellect = StartingIntellect;
            this.Attack = StartingAttack;
            this.Initiative = StartingInitiative;

            // Starting warrior abilities
            this.Abilities.Add(new Ability("Basic Attack", "Just a hit with your weapon", AbilityEffects.DirectDamage, 0));
            this.Abilities.Add(new Ability("Slam", "Slam your opponent with powerfull attack", AbilityEffects.DirectDamage, 5));
        }
    }
}