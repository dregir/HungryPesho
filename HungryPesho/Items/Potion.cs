namespace HungryPesho.Items
{
    using System.Collections;

    private enum FoodTypes
    {
        HELTH,
        MANA,
        REJUVENATION
    }

    public class Food : EffectItem
    {
        private FoodTypes potionType;

        public Food(int id, string name, string description, FoodTypes potionType)
            : base(id, name, description)
        {
            this.PotionType = potionType;
        }

        public FoodTypes PotionType
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

        public void CreateFood()
        {

        }
    }
}