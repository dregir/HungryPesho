namespace HungryPesho.Items
{
    using System.Collections;

    public class Armor : StatItem
    {
        private int armorProtection;

        public Armor(int id, string name, string description, int stamina, int agility, int strength, int intellect, int protection)
            : base(id, name, description, stamina, agility, strength, intellect)
        {
            this.ArmorProtection = protection;
        }

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

        public void CreareNewArmor()
        {

        }
    }
}