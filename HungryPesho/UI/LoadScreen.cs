namespace HungryPesho.UI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Media;
    using HungryPesho.Engine;

    public static class LoadScreen
    {
        public static void LoadStartMenu() // Main menu
        {
            GameSettings.Player = new SoundPlayer(@"../../misc/start.wav");
            GameSettings.Player.Play();

            Console.Clear();
            DrawHelper.DrawStartingWindow();

            var menuChoices = new[]
            {
                "   START   ",
                "HOW TO PLAY",
                "  OPTIONS  ",
                " RANKLIST  ",
                "  CREDITS  ",
                "   EXIT    "
            };

            var startMenuMethods = new List<Action>()
            {
                LoadCharacterSelection,
                LoadGameInfoScreen,
                GameSettings.LoadGameSettings,
                LoadRankList,
                LoadCreditsScreen,
            };

            DrawHelper.CreateMenu(menuChoices, startMenuMethods, 25);
        }

        public static void LoadCharacterSelection()
        {
            Engine.Pesho = DrawHelper.SelectCharacter();
            Engine.StartEngine();
        }

        public static void LoadIngameMenu() // Ingame menu
        {
            GameSettings.Player = new SoundPlayer(@"../../misc/start.wav");
            GameSettings.Player.Play();

            Console.Clear();
            DrawHelper.DrawStartingWindow();

            var menuChoices = new[]
            {
                " CONTINUE  ",
                "   SAVE    ",
                "   LOAD    ",
                "  OPTIONS  ",
                "HOW TO PLAY",
                "   EXIT    "
            };

            var startMenuMethods = new List<Action>()
            {
                Engine.StartEngine,
                GameSettings.SaveGame,
                GameSettings.LoadGame,
                GameSettings.LoadGameSettings,
                LoadGameInfoScreen,
                LoadCreditsScreen
            };

            DrawHelper.CreateMenu(menuChoices, startMenuMethods, 25);
        }

        public static void LoadGameInfoScreen() // How to play screen
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public static void LoadSettingsScreen() // Game options
        {
            Console.WriteLine("Music OFF");
        }

        public static void LoadCreditsScreen() // Game credits Screen
        {
            GameSettings.Player = new SoundPlayer(@"../../misc/credits.wav");
            GameSettings.Player.Play();

            Console.Clear();
            Console.Title = "Hungry Pesho!  -=-  Game Credits";

            Console.Write(@"
                                ____  
               ________         L|eam          __.                              
               \______ \_______   ____   ____ |__|______ 
                |    |  \_  __ \_/ __ \ / ___\|  \_  __ \
                |    `   \  | \/\  ___// /_/  >  ||  | \/
               /_______  /__|    \___  >___  /|__||__|   
                       \/            \/_____/       



                            Pavlin Kostadinov
                            Adrian Bozhankov
                            Nina Markova
                            Mihail Dimitrov
                            Valyu Valev
                            Karim Hristov


                            In Hungry Pesho!

                            Game intro...
                                           Good luck!");

            DrawHelper.TextAtPosition("Press Esc to go back", GameSettings.GameWidth / 2, GameSettings.GameHeight / 2, ConsoleColor.Yellow);
        }

        public static void LoadLooseScreen(int score) // Gave Over screen
        {
            GameSettings.Player = new SoundPlayer(@"../../misc/over.wav");
            GameSettings.Player.Play();

            Console.Clear();
            Console.Title = "Hugry pesho!  -=-  You LOOSE!";

            Console.WriteLine(@"

             _                   _
            ( )                 ( )_
           (_, |      __ __      | _)
             \'\    /  ^  \    /'/
              '\'\,/\      \,/'/'
                '\| []   [] |/'
                  (_  /^\  _)
                    \  ~  /
                    /HHHHH\
                  /'/{^^^}\'\
              _,/'/'  ^^^  '\'\,_
             (_, |           | ,_)
               (_)           (_)
");

            Console.WriteLine("GAME OVER");
            Console.WriteLine("Enter your nickname: ");

            Console.ReadLine();
            // GetScore(score);
        }

        public static void LoadWinScreen() // Win Game screen
        {
            GameSettings.Player = new SoundPlayer(@"../../misc/win.wav");
            GameSettings.Player.Play();

            Console.Clear();
            Console.Title = "Hungry Pesho!  -=-  You WIN!";

            Console.WriteLine(@"

             ╔╗╔╗╔╗╔╗
             ║╚╝╚╝║╠╣╔═╦╗
             ╚╗╔╗╔╝║║║║║║
              ╚╝╚╝ ╚╝╚╩═╝");

            Console.WriteLine("YOU WIN");
            Console.WriteLine("Your score: ");
            Console.WriteLine("Enter your nickname: ");

            // GetScore(score);
        }

        public static void LoadRankList() // Show current high score
        {
            GameSettings.Player = new SoundPlayer(@"../../misc/ranklist.wav");
            GameSettings.Player.Play();

            Console.Clear();
            Console.Title = "Hungry Pesho!  -=-  Ranklist";

            var highScores = File.ReadAllLines("score.hup"); // TODO: Catch exceptions

            for (int i = 0; i < highScores.Length && i <= 10; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 7, (Console.WindowHeight - 23) - (i + 1));
                Console.WriteLine("{0}. {1}", i + 1, highScores[i]);
            }

            DrawHelper.TextAtPosition("Press Esc to go back", GameSettings.GameWidth / 2, GameSettings.GameHeight / 2, ConsoleColor.Yellow);
        }
    }
}