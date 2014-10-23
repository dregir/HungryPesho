namespace HungryPesho.Engine
{
    using HungryPesho.Creatures;

    public class Player
    {
        private static Character playerClass = null;

        private Player() 
        { 
        }

        public static Character Pesho { get; set; }

        public static Character SetClass(Character character)
        {
            if (playerClass == null)
            {
                playerClass = character;
            }

            return playerClass;
        }
    }
}