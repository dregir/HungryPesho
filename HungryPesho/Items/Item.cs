namespace HungryPesho.Items
{
    using System;

    public enum ItemTypes
    {
        EQUIPMENT,
        WEAPON,
        ARMOR,
        SCROLL,
        POTION
    }

    public abstract class Item : ICollectible
    {
        private int itemId;
        private string itemName;
        private string itemDescription;
        private ItemTypes itemType;

        public Item(int id, string name, string description)
        {
            this.ItemId = id;
            this.ItemName = name;
            this.ItemDescription = description;
        }

        #region Properties
        // TODO: Validate
        public int ItemId
        {
            get
            {
                return this.itemId;
            }

            set
            {
                this.itemId = value;
            }
        }

        public string ItemName
        {
            get
            {
                return this.itemName;
            }

            set
            {
                this.itemName = value;
            }
        }

        public string ItemDescription
        {
            get
            {
                return this.itemDescription;
            }

            set
            {
                this.itemDescription = value;
            }
        }

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
        #endregion
    }
}