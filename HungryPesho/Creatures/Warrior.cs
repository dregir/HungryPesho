namespace HungryPesho.Creatures
{
    using System.Collections;

    public class Warrior : Character
    {
        private const string WarriorDescription = "Strong and powerful character who slay his opponents with brute force!";

        private const int Level = 1;
        private const int Health = 13;
        private const int Energy = 10;
        private const int Agility = 5;
        private const int Strength = 15;
        private const int Intellect = 5;

        private Warrior(string description, int level, int health, int energy, int agility, int strength, int intellect)
            : base(description, level, health, energy, agility, strength, intellect)
        {
        }

        public Character CreateNewWarrior()
        {
            return new Warrior(WarriorDescription, Level, Health, Energy, Agility, Strength, Intellect);
        }
    }
}