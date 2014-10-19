namespace HungryPesho
{
    using System;
    using HungryPesho.ExceptionClasses;
    using HungryPesho.Interfaces;

    public abstract class GameObject : IDescribable
    {
        private string name;
        private string description;

        public GameObject(string name = "", string description = "")
        {
            this.Name = name;
            this.Description = description;
        }

        #region Properties

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                ApplicationValidator.ValidateStringValue(value);
                this.name = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                ApplicationValidator.ValidateStringValue(value);
                this.description = value;
            }
        }
        #endregion
    }
}