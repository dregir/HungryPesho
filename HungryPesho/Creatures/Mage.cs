namespace HungryPesho.Creatures
{
    using System.Collections;

    public class Mage : Character
    {
        private const string MageDescription = "Using magic to slay his opponents.";

        private const int stamina = 6;
        private const int agility = 7;
        private const int strength = 5;
        private const int intellect = 15;

        public Mage(string description, int level, int health, int energy, int agility, int strength, int intellect)
            : base(description,level,  health, energy, agility, strength, intellect)
        {
            base.Description = MageDescription;

            base.Agility = agility;
            base.Strength = strength;
            base.Intellect = intellect;
        }
    }
}