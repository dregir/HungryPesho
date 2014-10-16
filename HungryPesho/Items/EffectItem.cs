namespace HungryPesho.Items
{
    using System;
    using HungryPesho.Interfaces;

    public abstract class EffectItem : Item, IEffectable
    {
        public EffectItem(int id, string name, string description)
            : base(id, name, description)
        {
        }
    }
}