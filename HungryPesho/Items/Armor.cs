﻿namespace HungryPesho.Items
{
    public class Armor : StatItem
    {
        private int armorProtection;

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

        public Armor CreareNewArmor()
        {
            return new Armor(); // TODO: Implement
        }
    }
}