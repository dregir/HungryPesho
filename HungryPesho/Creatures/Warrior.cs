namespace HungryPesho.Creatures
{
    using System.Collections;

    public class Warrior : Character
    {
        private const string WarriorName = "Warrior";
        private const string WarriorDescription = "Strong and powerful character who slay his opponents with brute force!";
        private const int stamina = 13;
        private const int agility = 5;
        private const int strength = 15;
        private const int intellect = 5;

        public Warrior(string name, string description, int level, int stamina, int agility, int strength, int intellect)
            : base(name, description, level, stamina, agility, strength, intellect)
        {
            base.Name = WarriorName;
            base.Stamina = stamina;
            base.Agility = agility;
            base.Strength = strength;
            base.Intellect = intellect;
        }
    }
}
