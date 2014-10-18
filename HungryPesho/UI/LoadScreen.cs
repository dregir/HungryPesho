namespace HungryPesho.UI
{
    using System;
    using System.IO;
    using System.Media;
    using HungryPesho.Engine;
    using System.Collections.Generic;

    public static class LoadScreen
    {
        public static void LoadStartMenu() // Main menu
        {
            Console.Clear();
            DrawHelper.DrawStartingWindow();

            var menuChoices = new[]
            {
                "   START   ",
                "HOW TO PLAY",
                "  OPTIONS  ",
                " RANKLIST ",
                "  CREDITS  ",
                "   EXIT    "
            };

            var startMenuMethods = new List<Action>()
            {
                Engine.StartEngine,
                LoadGameInfoScreen,
                GameSettings.LoadGameSettings,
                LoadRankList,
                LoadCreditsScreen,
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
            Console.Title = "Hungry Pesho  -=-  Game Credits";

            Console.Write(@"Team Dregir:

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
            Console.WriteLine("Press Esc to go back");
        }

        public static void LoadLooseScreen(int score) // Gave Over screen
        {
            //var music = new SoundPlayer(@"gameover.wav");
            //music.Play();

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
            //GetScore(score);
        }

        public static void LoadWinScreen() // Win Game screen
        {
            //var music = new SoundPlayer(@"win.wav");
            //music.Play();

            Console.Title = "Hungry Pesho!  -=-  You WIN!";
            Console.Clear();

            Console.WriteLine(@"

             ╔╗╔╗╔╗╔╗
             ║╚╝╚╝║╠╣╔═╦╗
             ╚╗╔╗╔╝║║║║║║
              ╚╝╚╝ ╚╝╚╩═╝");


            Console.WriteLine("YOU WIN");
            Console.WriteLine("Your score: ");
            Console.WriteLine("Enter your nickname: ");

            //GetScore(score);
        }

        public static void LoadRankList() // Show current high score
        {
            Console.Title = "Hungry Pesho!  -=-  Ranklist";
            var highScores = File.ReadAllLines("score.hup");

            for (int i = 0; i < highScores.Length && i <= 10; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 7, (Console.WindowHeight - 23) - (i + 1));
                Console.WriteLine("{0}. {1}", i + 1, highScores[i]);
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 12, Console.WindowHeight - 2);
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Press Esc to go back");
        }
    }
}