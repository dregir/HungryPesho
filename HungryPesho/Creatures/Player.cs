namespace HungryPesho.Creatures
{
    using System;

    public class Player : Creature, IPlayer
    {
        private int playerLevel;
        private Character playerCharacter;

        public Player(string name, string description, int level, Character character) : base(name, description)
        {
            this.PlayerLevel = level;
            this.PlayerCharacter = character;
        }

        public int PlayerLevel
        {
            get
            {
                return this.playerLevel;
            }
            set
            {
                this.playerLevel = value;
            }
        }

        public Character PlayerCharacter
        {
            get
            {
                return this.playerCharacter;
            }
            set
            {
                this.playerCharacter = value;
            }
        }
    }
}