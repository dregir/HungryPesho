namespace HungryPesho.Creatures
{
    using System.Collections;

    public abstract class Character : Creature, IStatable
    {
        private int level;
        private int stamina;
        private int agility;
        private int strength;
        private int intellect;

        public Character(string name, string description, int level, int stamina, int agility, int strength, int intellect)
            : base(name, description)
        {
            this.Level = level;
            this.Stamina = stamina;
            this.Intellect = intellect;
            this.Agility = agility;
            this.Strength = strength;
            this.Intellect = intellect;
        }

        #region Properties
        // TODO: Validate
        public int Level
        {
            get
            {
                return this.level;
            }

            set
            {
                this.level = value;
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }

            set
            {
                this.stamina = value;
            }
        }

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