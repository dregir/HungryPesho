namespace HungryPesho.Items
{
    using System.Text;
    using HungryPesho.ExceptionClasses;

    public class Weapon : StatItem
    {
        private int weaponDamage;

        public int WeaponDamage
        {
            get
            {
                return this.weaponDamage;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ApplicationException("Damage should be a positive value!");
                }
                this.weaponDamage = value;
            }
        }

        public WeaponTypes WeaponType { get; set; }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("{0} - {1} \r\nStats \r\nDamage: {2}",
                this.WeaponType, this.Description, this.WeaponDamage);

            print.Append(base.ToString());

            return print.ToString();
        }
    }
}