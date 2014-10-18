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
        
        public int Stamina
        {
            get
            {
                return this.stamina;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ApplicationException("Stamina should be positive!");
                }
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
                if (value < 0 || value > 100)
                {
                    throw new ApplicationException("Agility should be positive!");
                }
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
                if (value < 0 || value > 100)
                {
                    throw new ApplicationException("Strength should be positive!");
                }
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
                if (value < 0 || value > 100)
                {
                    throw new ApplicationException("Intellect should be positive!");
                }
                this.intellect = value;
            }
        }
       

        public override string ToString()
        {
            return string.Format("\r\nStamina: {0} \r\nAgility: {1} \r\nStrength: {2} \r\nIntellect: {3}",
                 this.Stamina, this.Agility, this.Strength, this.Intellect);
        }
    }
}