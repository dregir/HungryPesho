﻿namespace HungryPesho.Abilities
{
    using System;

    public enum AbilityEffects
    {
        DOUBLEDAMAGE,
        FREEZE,
        DODGE,
        SPEED
    }

    public abstract class Ability : IAbility
    {
        private string name;
        private string description;
        private AbilityEffects abilityEffect;

        public Ability(string name, string description, AbilityEffects abilityEffect)
        {
            this.Name = name;
        }

        #region Properties
        // TODO: Validate
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

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

        public AbilityEffects AbilityEffect
        {
            get
            {
                return this.abilityEffect;
            }

            set
            {
                this.abilityEffect = value;
            }
        }
        #endregion
    }
}