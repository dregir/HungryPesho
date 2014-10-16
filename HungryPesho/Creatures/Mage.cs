namespace HungryPesho.Creatures
{
    using System.Collections;

    public class Mage : Character
    {
        private const string MageName = "Mage";
        private const string MageDescription = "Using magic to slay his opponents.";

        private const int stamina = 6;
        private const int agility = 7;
        private const int strength = 5;
        private const int intellect = 15;


        public Mage(string name, string description, int stamina, int agility, int strength, int intellect)
            : base(name, description, stamina, agility, strength, intellect)
        {
            base.Name = MageName;
            base.Description = MageDescription;

            base.Stamina = stamina;
            base.Agility = agility;
            base.Strength = strength;
            base.Intellect = intellect;
        }
    }
}