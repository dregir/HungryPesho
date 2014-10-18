namespace HungryPesho.Creatures
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

        //public Mage(string description, int level, int attack, int health, int energy, int initiative, int agility, int strength, int intellect)
        //    : base(description, level, attack, health, energy, initiative, agility, strength, intellect)
        //{
        //    base.Agility = agility;
        //    base.Strength = strength;
        //    base.Intellect = intellect;
        //}

        public static Mage CreateNewMage()
        {
            var mage = new Mage();

            mage.Level = StartingLevel;
            mage.Health = StartingHealth;
            mage.Energy = StartingEnergy;
            mage.Agility = StartingAgility;
            mage.Strength = StartingStrength;
            mage.Intellect = StartingIntellect;
            mage.Attack = StartingAttack;

            return mage;
        }
    }
}