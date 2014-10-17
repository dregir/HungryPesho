namespace HungryPesho
{
    using System;
    using HungryPesho.Interfaces;

    public abstract class GameObject : IDescription
    {
        private string description;

        public GameObject(string description = "")
        {
            this.Descriptin = description;
        }   

        public string Descriptin
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