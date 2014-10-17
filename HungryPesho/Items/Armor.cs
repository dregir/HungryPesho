namespace HungryPesho.Items
{
    using System.Text;

    public class Armor : StatItem
    {
        private int armorProtection;

        private ArmorTypes armorType;

        // TODO: Validate
        public int ArmorProtection
        {
            get
            {
                return armorProtection;
            }

            set
            {
                armorProtection = value;
            }
        }

        public ArmorTypes ArmorType
        {
            get
            {
                return armorType;
            }

            set
            {
                armorType = value;
            }
        }

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