﻿namespace HungryPesho.Items
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

        public Weapon(string name, string description, int stamina, int agility, int strength, int intellect, int damage)
            : base(stamina, agility, strength, intellect)
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

        public void CreateNewWeapon()
        {

        }
    }
}