namespace HungryPesho.UI
{
    using HungryPesho.Engine;
    using System;
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
    }
}