namespace HungryPesho.Engine
{
    using HungryPesho.Creatures;

    public class Player
    {
        private static Character PlayerClass = null;

        private Player() { }

        public static Character SetClass(Character character)
        {
            if (PlayerClass == null)
            {
                PlayerClass = character; 
            }

            return PlayerClass;
        }

        public static Character Pesho { get; set; }
    }
}