namespace HungryPesho.Creatures
{
    using System;
    using System.Collections.Generic;
    using HungryPesho.Abilities;
    using HungryPesho.ExceptionClasses;
    using HungryPesho.Interfaces;

    public abstract class Creature : GameObject, ICreature
    {
        private int level;
        private int attack;
        private int health;
        private int energy;
        private int initiative;
        private List<Ability> abilities;

        public Creature()
        {
            this.abilities = new List<Ability>();
        }

        #region Properties

        public int Level
        {
            get
            {
                return this.level;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 10, "Level");
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
                ApplicationValidator.ValidateNumberValue(value, 0, 1000, "Health");
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
                ApplicationValidator.ValidateNumberValue(value, 1, 10000, "Attack");
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
                ApplicationValidator.ValidateNumberValue(value, 0, 1000, "Energy");
                this.energy = value;
            }
        }

        public int Initiative
        {
            get
            {
                return this.initiative;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 0, 10, "Initiative");
                this.initiative = value;
            }
        }

        public List<Ability> Abilities
        {
            get
            {
                return this.abilities;
            }

            set
            {
                this.abilities = value;
            }
        }
        #endregion

        public virtual void Action(Creature target)
        {
        }

        public void AddAbilities(Ability[] abilities)
        {
            foreach (var ability in abilities)
            {
                this.abilities.Add(ability);
            }
        }
    }
}