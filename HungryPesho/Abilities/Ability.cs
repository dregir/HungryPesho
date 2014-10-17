﻿namespace HungryPesho.Abilities
{
    using HungryPesho.Interfaces;

    public class Ability : IAbility
    {
        private string name;
        private string description;
        private AbilityEffects abilityEffect;
        private int energyCost;

        public Ability(string name, string description, AbilityEffects abilityEffect, int energyCost)
        {
            this.EnergyCost = energyCost;
            this.Name = name;
            this.EnergyCost = energyCost;
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

        public int EnergyCost { get; set; }

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
