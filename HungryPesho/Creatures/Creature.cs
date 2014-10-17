namespace HungryPesho.Creatures
{
    public abstract class Creature : GameObject, ICreature
    {
        private int level;
        private int attack;
        private int health;
        private int energy;
        private int initiative;

        //public Creature(string description, int level, int attack, int health, int energy, int initiative)
        //    : base(description)
        //{
        //    this.Level = level;
        //    this.Attack = attack;
        //    this.Health = health;
        //    this.Energy = energy;
        //    this.Initiative = initiative;
        //}

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

        public int Attack
        {
            get
            {
                return this.attack;
            }

            set
            {
                this.attack = value;
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

        public int Initiative
        {
            get
            {
                return this.Initiative;
            }

            set
            {
                this.initiative = value;
            }
        }

        #endregion
    }
}