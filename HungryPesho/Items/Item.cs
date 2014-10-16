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
        #endregion
    }
}