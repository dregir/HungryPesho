namespace HungryPesho.Items
{
    using System.Collections;

    public enum FoodTypes // two types at least  - of Food!! rename potions to food; empty constructor
    {
        HELTH,
        MANA,
        REJUVENATION
    }

    public class Food : EffectItem
    {
        private FoodTypes potionType;

        public Food(int id, string name, string description, FoodTypes potionType)
            : base(name, description)
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