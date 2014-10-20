namespace HungryPesho.Items
{
    using HungryPesho.ExceptionClasses;
    using HungryPesho.Interfaces;

    public abstract class EffectItem : Item, IEffectable
    {
        private int healthGained;
        private int energyGained;

        public int HealthGained
        {
            get
            {
                return this.healthGained;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 500, "HealthGained");
                this.healthGained = value;
            }
        }

        public int EnergyGained
        {
            get
            {
                return this.energyGained; 
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 500, "EnergyGained");
                this.energyGained = value;
            }
        }
    }
}