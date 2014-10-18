namespace HungryPesho.Items
{
    using HungryPesho.Interfaces;

    public abstract class EffectItem : Item, IEffectable
    {
        private int healthGained;
        private int energyGained;

        public EffectItem()
        {
        }

        public int HealthGained
        {
            get
            {
                return this.healthGained;
            }
            set
            {
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
                this.energyGained = value;
            }
        }
    }
}