﻿namespace HungryPesho.Creatures
{
    using System.Collections;

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
        }
    }
}