namespace HungryPesho.UI
{
    using System;
    using HungryPesho.UI;

    public class GameMenu
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
                        case 3: LoadScreen.LoadCreditsScreen(); break;
                        case 4: Console.WriteLine("EXIT"); break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}