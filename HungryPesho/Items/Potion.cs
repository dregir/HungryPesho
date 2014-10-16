namespace HungryPesho.Items
{
    using System.Collections;

    public enum PotionTypes
    {
        HELTH,
        MANA,
        REJUVENATION
    }

    public class Food : EffectItem
    {
        private PotionTypes potionType;

        public Food(int id, string name, string description, PotionTypes potionType)
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