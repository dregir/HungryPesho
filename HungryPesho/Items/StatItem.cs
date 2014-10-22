namespace HungryPesho.Items
{
    using HungryPesho.ExceptionClasses;
    using HungryPesho.Interfaces;

    public abstract class StatItem : Item, IStatable
    {
        private int stamina;
        private int agility;
        private int strength;
        private int intellect;

        #region Properties

        public int Stamina
        {
            get
            {
                return this.stamina;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 100, "Stamina");
                this.stamina = value;
            }
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 100, "Agility");
                this.agility = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 100, "Strength");
                this.strength = value;
            }
        }

        public int Intellect
        {
            get
            {
                return this.intellect;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 100, "Intellect");
                this.intellect = value;
            }
        }
        #endregion

        public override string ToString()
        {
            return string.Format("\r\nStamina: {0} \r\nAgility: {1} \r\nStrength: {2} \r\nIntellect: {3}", this.Stamina, this.Agility, this.Strength, this.Intellect);
        }
    }
}