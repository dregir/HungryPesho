namespace HungryPesho.Creatures
{
    using System;
    using System.Collections.Generic;

    public class Player : Creature, IPlayer
    {
        private List<Character> characters;

        public Player(string name, string description, Character character)
            : base(name, description)
        {
            this.characters.Add(character);
        }
    }
}