namespace HungryPesho.Engine
{
    using System;
    using System.IO;
    using System.Media;
    using System.Threading;
    using HungryPesho.UI;

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

        private static void SaveGame() // Save current game
        {
            try
            {
                var writer = new StreamWriter("saves.hup");

                using (writer)
                {
                    // TODO: Save current state
                }
            }
            catch (Exception)
            {
                Console.SetCursorPosition(Console.WindowWidth - 40, (Console.WindowHeight / 2) - 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SAVE GAME FAILED!");
                Thread.Sleep(2000);
                Console.Clear();
                GameMenu.LoadStartMenu();
            }
        }

        private static void LoadGame() // Load currnet game
        {
            try
            {
                StreamReader reader = new StreamReader("SavedGames.ast");

                using (reader)
                {
                    // TODO: Load currnet state
                }
            }
            catch (Exception)
            {
                Console.SetCursorPosition(Console.WindowWidth - 33, (Console.WindowHeight / 2) - 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("LOAD GAME FAILED!");
                Thread.Sleep(2000);
                Console.Clear();
                GameMenu.LoadStartMenu();
            }
        }
    }
}