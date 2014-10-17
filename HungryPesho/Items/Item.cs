namespace HungryPesho.Items
{
    using System;
    using HungryPesho.Interfaces;

    public enum ItemTypes// delete
    {
        EQUIPMENT,
        WEAPON,
        ARMOR,
        SCROLL,
        POTION
    }

    public abstract class Item : GameObject, ICollectible
    {
        private string name;
        private ItemTypes itemType;

        #region Properties
        // TODO: Validate
        public ItemTypes ItemType
        {
            get
            {
                return this.itemType;
            }

            set
            {
                this.itemType = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        #endregion
    }
}