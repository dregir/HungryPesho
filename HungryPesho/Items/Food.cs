﻿namespace HungryPesho.Items
{
    public class Food : EffectItem
    {
        private FoodTypes foodType;

        public Food()
        {
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
    }
}
