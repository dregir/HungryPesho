namespace HungryPesho.Items
{
    public abstract class Item : GameObject
    {
        private string weapon;
        private string armor;

        public Item()
        {
        }

        public string Weapon
        {
            get { return this.weapon; }
            set { this.weapon = value; }
        }

        public string Armor
        {
            get { return this.armor; }
            set { this.armor = value; }
        }
    }
}