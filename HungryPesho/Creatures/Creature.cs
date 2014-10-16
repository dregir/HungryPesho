namespace HungryPesho.Creatures
{
    public abstract class Creature : ICreature
    {
        private string name;
        private double attack;
        private double health;
        private double mana;
        private double initiative;

        protected Creature(string name,double attack, double health, double mana, double initiative)
        {
            this.Name = name;
            this.Attack = attack;
            this.Health = health;
            this.Mana = mana;
            this.Initiative = initiative;
        }

        #region Properties
        // TODO: Validate
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public double Attack { get; set; }
        public double Health { get; set; }
        public double Mana { get; set; }
        public double Initiative { get; set; }

        #endregion
    }
}
