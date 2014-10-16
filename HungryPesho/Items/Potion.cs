namespace HungryPesho.Items
{
    using System.Collections;

    public enum PotionTypes
    {
        HELTH,
        MANA,
        REJUVENATION
    }

    public class Potion : EffectItem
    {
        private PotionTypes potionType;

        public Potion(int id, string name, string description, PotionTypes potionType)
            : base(id, name, description)
        {
            this.PotionType = potionType;
        }

        public PotionTypes PotionType
        {
            get
            {
                return this.potionType;
            }

            set
            {
                this.potionType = value;
            }
        }
    }
     
}