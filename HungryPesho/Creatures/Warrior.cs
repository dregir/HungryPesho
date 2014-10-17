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

        private Warrior(string description, int level, int attack, int health, int energy, int initiative, int agility, int strength, int intellect)
            : base(description, level, attack, health, energy, initiative, agility, strength, intellect)
        {
        }


        public Character CreateNewWarrior()
        {
            //return new Warrior(WarriorDescription, Level, Health, Energy, Agility, Strength, Intellect);
        }
    }
}