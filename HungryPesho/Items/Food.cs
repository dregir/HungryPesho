namespace HungryPesho.Items
{
    public class Food : EffectItem
    {
        private FoodTypes foodType;

        public Food()
        {
            this.FoodType = this.foodType;
        }

        public FoodTypes FoodType
        {
            get
            {
                return this.foodType;
            }

            set
            {
                this.foodType = value;
            }
        }

        public void CreateFood()
        {

        }
    }
}
