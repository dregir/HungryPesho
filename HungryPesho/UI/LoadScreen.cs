namespace HungryPesho.UI
{
    using HungryPesho.Engine;
    using System;
    using System.IO;
    using System.Media;

    public static class LoadScreen
    {
        public static void LoadGameScreen()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public static void LoadCreditsScreen() // Game credits Screen
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

            //Console.SetCursorPosition(Console.WindowWidth - 49, Console.WindowHeight - 1);
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Press Space to go back");
        }

        public static void LoadGameInfoScreen()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        private static void LoadGameOverScreen(int score) // Gave Over screen
        {
            var music = new SoundPlayer(@"gameover.wav");
            music.Play();

            Console.Clear();
            Console.Title = "Hugry pesho!  -=-  You LOOSE!";
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Enter your nickname: ");

            Console.ReadLine();

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

            //GetScore(score);
        }

        private static void LoadWinScreen() // Win Game screen
        {
            var music = new SoundPlayer(@"Win.wav");
            music.Play();
            Console.Clear();
            Console.Title = "Hungry Pesho!  -=-  You WIN!";
            Console.WriteLine("YOU WIN");
            Console.WriteLine("Your score: ");
            Console.WriteLine("Enter your nickname: ");
            Console.WriteLine(@"




             ╔╗╔╗╔╗╔╗
             ║╚╝╚╝║╠╣╔═╦╗╔═╦╗╔═╗╔╦╗
             ╚╗╔╗╔╝║║║║║║║║║║║╩╣║╔╝
              ╚╝╚╝ ╚╝╚╩═╝╚╩═╝╚═╝╚╝
");


            //GetScore(score);
        }

        private static void CurrentHighScores() // Show current high score
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
            //Console.WriteLine("Press Space to go back");
        }
    }
}