namespace HungryPesho.Creatures
{
    using System.Collections;

    public abstract class Character : Creature, IStatable
    {
        private int agility;
        private int strength;
        private int intellect;

        public Character(string description, int level, int attack, int health, int energy, int initiative, int agility, int strength, int intellect)
            : base(description, level, attack, health, energy, initiative)
        {
            this.Agility = agility;
            this.Strength = strength;
            this.Intellect = intellect;
        }

        #region Properties
        // TODO: Validate
        public int Agility
        {
            get
            {
                return this.agility;
            }

            set
            {
                this.agility = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }

            set
            {
                this.strength = value;
            }
        }

        public int Intellect
        {
            get
            {
                return this.intellect;
            }

            set
            {
                this.intellect = value;
            }
        }
        #endregion
    }
}