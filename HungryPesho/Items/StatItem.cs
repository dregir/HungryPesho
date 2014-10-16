namespace HungryPesho.Items
{
    using System.Collections;
    using HungryPesho.Creatures;

    public abstract class StatItem : Item, IStatable
    {
        private int stamina;
        private int agility;
        private int strength;
        private int intellect;

        public StatItem(int stamina, int agility, int strength, int intellect)
        {
            this.Stamina = stamina;
            this.Agility = agility;
            this.Strength = strength;
            this.Intellect = intellect;
        }

        #region Properties
        // TODO: Validate
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