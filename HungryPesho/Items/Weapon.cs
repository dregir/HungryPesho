namespace HungryPesho.Items
{
    using System;
    using System.Collections;
    using System.Text;

    public enum WeaponTypes
    {
        SWORD,
        STAFF,
        DAGGER,
        BOW
    }

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

        public static Weapon CreateNewWeapon()
        {
            var random = new Random();
            var weapon = new Weapon();

            weapon.WeaponDamage = random.Next(1, 100);
            weapon.Stamina = random.Next(1, 11);
            weapon.Agility = random.Next(1, 11);
            weapon.Strength = random.Next(1, 11);
            weapon.Intellect = random.Next(1, 11);

            var weaponType = random.Next(1, 5);

            switch (weaponType)
            {
                case 1: weapon.WeaponType = WeaponTypes.SWORD; weapon.Descriptin = "You can chop off heads now!"; break;
                case 2: weapon.WeaponType = WeaponTypes.STAFF; weapon.Descriptin = "Will make you a bit wiser!"; break;
                case 3: weapon.WeaponType = WeaponTypes.DAGGER; weapon.Descriptin = "You can cook with this one!"; break;
                case 4: weapon.WeaponType = WeaponTypes.BOW; weapon.Descriptin = "You can shoot out in a distance!"; break;

                default:
                    break;
            }

            return weapon;
        }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("{0} - {1} \r\nStats \r\nDamage: {2}",
                this.WeaponType, this.Descriptin, this.WeaponDamage);

            print.Append(base.ToString());

            return print.ToString();
        }
    }
}