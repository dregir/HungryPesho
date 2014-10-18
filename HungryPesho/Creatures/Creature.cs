namespace HungryPesho.Creatures
{
    using System;
    using System.Collections.Generic;
    using HungryPesho.Abilities;
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

        public void AddAbilities(Ability[] _abilities)
        {
            foreach (var ability in _abilities)
            {
                abilities.Add(ability);
            }
        }
    }
}