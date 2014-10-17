namespace HungryPesho.Abilities
{
    using System;
    using HungryPesho.Interfaces;

    public enum AbilityEffects
    {
        DOUBLEDAMAGE,
        FREEZE,
        DODGE,
        SPEED
    }

    public class Ability : IAbility
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

        public double ManaCost { get; set; }

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
