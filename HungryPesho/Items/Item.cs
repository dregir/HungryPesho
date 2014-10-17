namespace HungryPesho.Items
{
    using System;
    using HungryPesho.Interfaces;

    public enum ItemTypes
    {
        EQUIPMENT,
        WEAPON,
        ARMOR,
        SCROLL,
        POTION
    }

    public abstract class Item : GameObject, ICollectible
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

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}