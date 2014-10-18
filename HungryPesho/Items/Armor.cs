namespace HungryPesho.Items
{
    using System.Text;
    using HungryPesho.ExceptionClasses;

    public class Armor : StatItem
    {
        private int armorProtection;
        
        public int ArmorProtection
        {
            get
            {
                return armorProtection;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ApplicationException("Protection should be positive!");
                }
                armorProtection = value;
            }
        }

        public ArmorTypes ArmorType { get; set; }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("{0} - {1} \r\nStats \r\nDamage: {2}",
                this.ArmorType, this.Description, this.ArmorProtection);

            print.Append(base.ToString());

            return print.ToString();
        }
    }
}