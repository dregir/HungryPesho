namespace HungryPesho.Creatures
{
    using System;

    public abstract class Creature : ICreature
    {
        private string description;
        private int level;
        private int health;
        private int energy;

        public Creature(string description, int level, int health, int energy)
        {
            this.Description = description;
            this.Level = level;
            this.Health = health;
            this.Energy = energy;
        }

        #region Properties
        // TODO: Validate
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

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

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }

            set
            {
                this.energy = value;
            }
        }
        #endregion
    }
}