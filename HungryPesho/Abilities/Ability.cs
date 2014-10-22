namespace HungryPesho.Abilities
{
    using HungryPesho.ExceptionClasses;
    using HungryPesho.Interfaces;

    public class Ability : GameObject, IAbility
    {
        private int energyCost;
        private AbilityEffects abilityEffect;

        public Ability(string name, string description, AbilityEffects abilityEffect, int energyCost)
            : base(name, description)
        {
            this.EnergyCost = energyCost;
            this.AbilityEffect = abilityEffect;
        }

        #region Properties
        public int EnergyCost
        {
            get
            {
                return this.energyCost;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, name: "EnergyCost");
                this.energyCost = value;
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