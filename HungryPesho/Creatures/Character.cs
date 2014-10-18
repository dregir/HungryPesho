namespace HungryPesho.Creatures
{
    using System.Collections;
    using System.Collections.Generic;
    using HungryPesho.Interfaces;

    public abstract class Character : Creature, IStatable
    {
        private int agility;
        private int strength;
        private int intellect;

        public Character()
        {
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

        public override string ToString()
        {
            return string.Format("{0} - Level: {1} \r\nHealth: {2} \r\nEnergy: {3} \r\nAgility: {4} \r\nStrength: {5} \r\nIntellect: {6}",
                this.GetType().Name, this.Level, this.Health, this.Energy, this.Agility, this.Strength, this.Intellect);
        }
    }
}