namespace HungryPesho.UI
{
    using HungryPesho.Engine;
    using System;
    using System.Media;

    public static class LoadScreen
    {
        public static void LoadStartMenu()
        {
            Console.WriteLine(@"


                                                ██╗██
                                  ██╗        ███╗██╗██╗█╗
                                  ╚██╗       ██╔╝██╔╝╚██║╚█║
                                  ╚██╗█████╗██║█████╗█████╗█
                                  ╚██╔╝╚════╝██║ ██║  ██║ █║
                                  ██╔╝       ███╗██╗██║█║
                                                ██╗██



 ██╗  ██╗██╗   ██╗███╗   ██╗ ██████╗ ██████╗ ██╗   ██╗    ██████╗ ███████╗███████╗██╗  ██╗ ██████╗ 
 ██║  ██║██║   ██║████╗  ██║██╔════╝ ██╔══██╗╚██╗ ██╔╝    ██╔══██╗██╔════╝██╔════╝██║  ██║██╔═══██╗
 ███████║██║   ██║██╔██╗ ██║██║  ███╗██████╔╝ ╚████╔╝     ██████╔╝█████╗  ███████╗███████║██║   ██║
 ██╔══██║██║   ██║██║╚██╗██║██║   ██║██╔══██╗  ╚██╔╝      ██╔═══╝ ██╔══╝  ╚════██║██╔══██║██║   ██║
 ██║  ██║╚██████╔╝██║ ╚████║╚██████╔╝██║  ██║   ██║       ██║     ███████╗███████║██║  ██║╚██████╔╝
 ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝       ╚═╝     ╚══════╝╚══════╝╚═╝  ╚═╝ ╚═════╝ 

                                  MORE HUNGRY THAN EVER BEFORE!!

                      ");

            var menuChoices = new[]
            {
                "   START  ",
                "HOW TO PLAY",
                "  OPTIONS  ",
                "  CREDITS  ",
                "   EXIT   "
            };

            Console.ForegroundColor = ConsoleColor.White;

            int cursorPos = 25;
            foreach (var choices in menuChoices)
            {
                Console.SetCursorPosition(45, cursorPos);
                Console.WriteLine(choices);
                cursorPos += 2;
            }

            cursorPos = 25;

            // Menu Logic                  
            int selection = 0;

            Func<int> check = delegate
            {
                if (selection > menuChoices.Length - 1)
                {
                    cursorPos = 25;
                    selection = 0;
                }

                else if (selection < 0)
                {
                    selection = menuChoices.Length - 1;
                    cursorPos = 25 + (menuChoices.Length - 1) * 2;
                }

                return selection;
            };

            Action<ConsoleColor, string> consoleAction = (color, text) =>
            {
                Console.SetCursorPosition(45, cursorPos);
                Console.BackgroundColor = color;
                Console.Write(text);
                Console.BackgroundColor = ConsoleColor.Black;
            };

            consoleAction(ConsoleColor.Blue, menuChoices[0]);

            while (true)
            {
                var input = Console.ReadKey();

                if (input.Key.Equals(ConsoleKey.DownArrow))
                {
                    consoleAction(ConsoleColor.Black, menuChoices[selection++]);
                    cursorPos += 2;
                    selection = check();
                    consoleAction(ConsoleColor.Blue, menuChoices[selection]);
                    continue;
                }

                if (input.Key.Equals(ConsoleKey.UpArrow))
                {
                    consoleAction(ConsoleColor.Black, menuChoices[selection--]);
                    cursorPos -= 2;
                    selection = check();
                    consoleAction(ConsoleColor.Blue, menuChoices[selection]);
                    continue;
                }

                if (input.Key.Equals(ConsoleKey.Enter))
                {
                    Console.Clear();

                    switch (selection)
                    {
                        case 0: Console.WriteLine("START"); break;
                        case 1: Console.WriteLine("HOW TO PLAY"); break;
                        case 2: Console.WriteLine("OPTIONS"); break;
                        case 3: GameSettings.LoadGameInfo(); break;
                        case 4: Console.WriteLine("EXIT"); break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void LoadPlayerMenu()
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