namespace HungryPesho.Engine
{
    using System;
    using System.Media;

    public static class GameSettings
    {
        public static void LoadGameSettings()
        {
            // Creating and initializing game window;
            Console.Title = "Hungry Pesho";
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 50);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        


        public static void SaveGameSettings()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}