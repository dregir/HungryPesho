namespace HungryPesho.Items
{
    using System.Collections;

    public enum WeaponTypes
    {
        SWORD,
        STAFF,
        DAGGER,
        BOW,
        SHIELD
    }

    public class Weapon : StatItem
    {
        private int weaponDamage;
        private WeaponTypes weaponType;

        public Weapon(int id, string name, string description, int stamina, int agility, int strength, int intellect, int damage)
            : base(id, name, description, stamina, agility, strength, intellect)
        {
            this.WeaponDamage = damage;
        }

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
    }
}