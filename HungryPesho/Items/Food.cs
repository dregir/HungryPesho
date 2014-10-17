namespace HungryPesho.Items
{
    public class Food : EffectItem
    {
        private FoodTypes foodType;

        private int foodCalories;

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



        public int Gain { get; set; }

        public int HealtGain { get; set; }
    }
}
