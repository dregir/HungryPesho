namespace HungryPesho.Items
{
    using System.Text;

    public class Weapon : StatItem
    {
        private int weaponDamage;
        private WeaponTypes weaponType;

        #region Properties
        // TODO: Validate
        public int WeaponDamage
        {
            get
            {
                return this.weaponDamage;
            }

            set
            {
                this.weaponDamage = value;
            }
        }

        public WeaponTypes WeaponType
        {
            get
            {
                return this.weaponType;
            }

            set
            {
                this.weaponType = value;
            }
        }
        #endregion


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