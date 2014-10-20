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
                return this.armorProtection;
            }

            set
            {
                ApplicationValidator.ValidateNumberValue(value, 1, 100, "ArmorProtection");
                this.armorProtection = value;
            }
        }

        public ArmorTypes ArmorType { get; set; }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("{0} - {1} \r\nStats \r\nDamage: {2}", this.ArmorType, this.Description, this.ArmorProtection);
            print.Append(base.ToString());

            return print.ToString();
        }
    }
}