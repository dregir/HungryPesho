namespace HungryPesho
{
    using System;
    using HungryPesho.Interfaces;

    public abstract class GameObject : IDescription
    {
        private string description;

        public GameObject(string description = "")
        {
            this.Description = description;
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
            }
        }
    }
}