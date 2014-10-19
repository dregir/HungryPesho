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
                if(value < 0 || value > 100)
                {
                    throw  new HungryPeshoException("Negative health cannot be gained!");
                }
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
                if (value < 0 || value > 100)
                {
                    throw new HungryPeshoException("Negative energy cannot be gained!");
                }
                this.energyGained = value;
            }
        }
    }
}