namespace HungryPesho.Items
{
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
        public Armor CreateArmor()
        {
            return new Armor(); // TODO: Implement
        }
    }
}