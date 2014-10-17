namespace HungryPesho.Items
{
    using System;
    using HungryPesho.Interfaces;

    public abstract class EffectItem : Item, IEffectable
    {
        public EffectItem(string name, string description)
        {
        }
    }
}