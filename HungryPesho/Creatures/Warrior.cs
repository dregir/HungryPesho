namespace HungryPesho.Creatures
{
    using System.Collections;

    public class Warrior : Character
    {
        private const string WarriorDescription = "Strong and powerful character who slay his opponents with brute force!";

        private const int StartingLevel = 1;
        private const int StartingHealth = 6;
        private const int StartingEnergy = 15;
        private const int StartingAgility = 7;
        private const int StartingStrength = 5;
        private const int StartingIntellect = 15;

        //private Warrior(string description, int level, int attack, int health, int energy, int initiative, int agility, int strength, int intellect)
        //    : base(description, level, attack, health, energy, initiative, agility, strength, intellect)
        //{
        //}

        public static Warrior CreateNewWarrior()
        {
            var warrior = new Warrior();

            warrior.Level = StartingLevel;
            warrior.Health = StartingHealth;
            warrior.Energy = StartingEnergy;
            warrior.Agility = StartingAgility;
            warrior.Strength = StartingStrength;
            warrior.Intellect = StartingIntellect;

            return warrior;
        }
    }
}