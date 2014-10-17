namespace HungryPesho.Items
{
    using HungryPesho.Interfaces;

    public abstract class EffectItem : Item, IEffectable
    {
        public EffectItem()
        {

        }

        public int HealthGain
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int EnergyGain
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}