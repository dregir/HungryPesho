namespace HungryPesho.UI
{
    using HungryPesho.Engine;
    using System;
    using System.IO;
    using System.Media;

    public static class LoadScreen
    {
        public static void LoadStartMenu() // Main menu
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
                "   START   ",
                "HOW TO PLAY",
                "  OPTIONS  ",
                "  RANKLIST ",
                "  CREDITS  ",
                "   EXIT    "
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
                        case 0: TestEngine.StartEngine(); break;
                        case 1: LoadGameInfoScreen(); break;
                        case 2: GameSettings.LoadGameSettings(); break;
                        case 3: LoadRankList(); break;
                        case 4: LoadCreditsScreen(); break;
                        case 5: Environment.Exit(0); break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void LoadGameInfoScreen() // How to play screen
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public static void LoadSettingsScreen() // Game options
        {
            Console.WriteLine("Music");
            Console.WriteLine("OFF");
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
            //Console.WriteLine("Press Space to go back");
        }
    }
}