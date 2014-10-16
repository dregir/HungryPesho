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

        public static void LoadGameInfo() // Game info and credits
        {
            Console.Title = "Hungry Pesho  -=-  Game Credits";

            Console.Write(@"
Team Dregir:

Pavlin Kostadinov
Adrian Bozhankov
Nina Markova
Mihail Dimitrov
Valyu Valev
Karim Hristov


In Hungry Pesho!

Game intro...
               Good luck!");

            Console.SetCursorPosition(Console.WindowWidth - 49, Console.WindowHeight - 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press Space to go back");
        }


        public static void SaveGameSettings()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}