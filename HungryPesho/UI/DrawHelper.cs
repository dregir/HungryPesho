namespace HungryPesho.UI
{
    using System;
    using HungryPesho.Engine;
    using System.Collections.Generic;

    public static class DrawHelper
    {
        public static void CreateMenu(string[] menuChoices, List<Action> methods, int cursorPos)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int initialPosition = cursorPos;

            foreach (var choices in menuChoices)
            {
                Console.SetCursorPosition(45, cursorPos);
                Console.WriteLine(choices);
                cursorPos += 2;
            }

            cursorPos = initialPosition;

            // Menu Logic                  
            int selection = 0;

            Func<int> check = delegate
            {
                if (selection > menuChoices.Length - 1)
                {
                    cursorPos = initialPosition;
                    selection = 0;
                }

                else if (selection < 0)
                {
                    selection = menuChoices.Length - 1;
                    cursorPos = initialPosition + (menuChoices.Length - 1) * 2;
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
                var input = Console.ReadKey(true);   // true prevents player from typing in console.

                if (input.Key.Equals(ConsoleKey.DownArrow))
                {
                    MediaPlayer.Play(Sound.Click);
                    consoleAction(ConsoleColor.Black, menuChoices[selection++]);
                    cursorPos += 2;
                    selection = check();
                    consoleAction(ConsoleColor.Blue, menuChoices[selection]);
                    continue;
                }

                if (input.Key.Equals(ConsoleKey.UpArrow))
                {
                    MediaPlayer.Play(Sound.Click);
                    consoleAction(ConsoleColor.Black, menuChoices[selection--]);
                    cursorPos -= 2;
                    selection = check();
                    consoleAction(ConsoleColor.Blue, menuChoices[selection]);
                    continue;
                }

                if (input.Key.Equals(ConsoleKey.Enter))
                {
                    MediaPlayer.Play(Sound.Enter);
                    Console.Clear();
                    methods[selection]();
                }

                if (input.Key.Equals(ConsoleKey.Escape))
                {
                    LoadScreen.LoadStartMenu();
                }
            }
        }

        public static void TextAtPosition(string text, int col, int row, ConsoleColor color = ConsoleColor.Green, ConsoleColor bgColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = bgColor;
            Console.SetCursorPosition(col, row);
            Console.Write(text);
            Console.ResetColor();
        }

        public static string Color(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text + " ");
            Console.ResetColor();
            return "";
        }

        public static void ReloadStats()
        {
            string charClass = Engine.Pesho.GetType().Name;
            int level = Engine.Pesho.Level;
            const int StartPos = 4;
            var peshoStats = new[]
                {
                    Engine.Pesho.Health,
                    Engine.Pesho.Energy,
                    Engine.Pesho.Initiative,
                    Engine.Pesho.Attack
                };

            var peshoColors = new[]
                {
                    ConsoleColor.Magenta,
                    ConsoleColor.Cyan,
                    ConsoleColor.DarkGreen,
                    ConsoleColor.Red,
                };

            for (int i = 0; i < peshoStats.Length; i++)
            {
                Console.SetCursorPosition(100, StartPos + i);
                Console.Write(Color(peshoStats[i].ToString(), peshoColors[i]));
            }

            var classColor = charClass == "Mage" ? ConsoleColor.Blue : ConsoleColor.DarkRed;

            TextAtPosition(level + " lvl", 94, 3, ConsoleColor.Yellow);
            TextAtPosition(charClass + "  ", 101, 3, classColor);
        }

        public static void BlockInputAndWaitFor(int seconds)
        {
            var startTime = DateTime.Now;
            while (startTime.AddSeconds(seconds) > DateTime.Now)           //prevents from key spamming while waiting!
            {
                while (Console.KeyAvailable) Console.ReadKey(true);
            }
        }

        public static void DrawGameWindow()
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
        }

        public static void DrawStatsWindow()
        {
            Console.Write(@"
                                                                                      ╔════════════════════════╗
                                                                                      ║                        ║
                                                                                      ║ Pesho                  ║
                                                                                      ║       Life:            ║
                                                                                      ║     Energy:            ║       
                                                                                      ║ Initiative:            ║
                                                                                      ║     Attack:            ║
                                                                                      ║                        ║
                                                                                      ╚════════════════════════╝");
        }
    }
}