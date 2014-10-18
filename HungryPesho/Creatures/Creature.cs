using HungryPesho.Interfaces;

namespace HungryPesho.Creatures
{
    public abstract class Creature : GameObject, ICreature
    {
        private int level;
        private int attack;
        private int health;
        private int energy;
        private int initiative;

        public Creature()
        {
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
                return this.initiative; //Previously recursive
            }

            set
            {
                this.initiative = value;
            }
        }

        public virtual string Name { get; set; } // Need this for the Enemy Class

        #endregion

        public virtual void Action(Creature target)
        {
            //Todo Impelment some actions
        }
    }
}