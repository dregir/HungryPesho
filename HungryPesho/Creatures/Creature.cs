namespace HungryPesho.Creatures
{
    using System;

    public abstract class Creature : ICreature
    {
        private string name;
        private string description;

        public Creature(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        #region Properties
        // TODO: Validate
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
        #endregion
    }
}