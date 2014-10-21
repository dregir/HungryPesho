using HungryPesho.Creatures;

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
                var input = Console.ReadKey(true); // true prevents player from typing in console.

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

        public static void TextAtPosition(string text, int col, int row, ConsoleColor color = ConsoleColor.Green,
            ConsoleColor bgColor = ConsoleColor.Black)
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

        public static void ReloadStats(Creature enemy)
        {
            string charClass = Engine.Pesho.GetType().Name;
            int level = Engine.Pesho.Level;
            const int startPos = 7;
            var peshoStats = new[]
            {
               new { stat = Engine.Pesho.Health, color = ConsoleColor.Magenta },
               new { stat = Engine.Pesho.Energy, color = ConsoleColor.Cyan },
               new { stat = Engine.Pesho.Initiative, color = ConsoleColor.DarkGreen },
               new { stat = Engine.Pesho.Attack, color = ConsoleColor.Red },             
            };

            var enemyStats = new[]
            {
                new {stat = enemy.Health, color = ConsoleColor.Magenta},
                new {stat = enemy.Energy, color = ConsoleColor.Cyan},
                new {stat = enemy.Initiative, color = ConsoleColor.DarkGreen},
                new {stat = enemy.Attack, color = ConsoleColor.Red},
            };

            for (int i = 0; i < peshoStats.Length; i++)
            {
                Console.SetCursorPosition(100, startPos + i);
                Console.Write(Color(peshoStats[i].stat.ToString(), peshoStats[i].color));
                Console.SetCursorPosition(25, startPos + i);
                Console.Write(Color(enemyStats[i].stat.ToString(), enemyStats[i].color));
            }

            var classColor = charClass == "Mage" ? ConsoleColor.Blue : ConsoleColor.DarkRed;

            TextAtPosition(level + " lvl", 94, 5, ConsoleColor.Yellow);
            TextAtPosition(charClass + "  ", 101, 5, classColor);

            if (enemy.Name.Length > 10)
            {
                TextAtPosition(enemy.Name, 17, 5, ConsoleColor.DarkCyan);
            }
            else if (enemy.Name.Length > 6)
            {
                TextAtPosition(enemy.Name, 19, 5, ConsoleColor.DarkCyan);
            }
            else
            {
                TextAtPosition(enemy.Name, 21, 5, ConsoleColor.DarkCyan);
            }

        }

        public static void BlockInputAndWaitFor(int seconds)
        {
            var startTime = DateTime.Now;
            while (startTime.AddSeconds(seconds) > DateTime.Now) // Prevents from key spamming while waiting!
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

                                              |\                     /)
                                            /\_\\__               (_//               ╔════════════════════════╗
                                           |   `>\-`     _._       //`)              ║                        ║
                                            \ /` \\  _.-`:::`-._  //                 ║  Pesho                 ║
                                             `    \|`    :::    `|/                  ║                        ║
                                                   |     :::     |                   ║       Life:            ║
                                                   |.....:::.....|                   ║     Energy:            ║       
                                                   |:::::::::::::|                   ║ Initiative:            ║
                                                   |     :::     |                   ║     Attack:            ║
                                                   |     :::     |                   ║                        ║
                                                   |     :::     |                   ╚════════════════════════╝
                                                   |     :::     |
                                                   \     :::     /
                                                    \    :::    / 
                                                     `-. ::: .-' 
                                                      //`:::`\\
                                                     //   '   \\
                                                    |/         \|   
");
                                                                

            TextAtPosition(@"
          ╔════════════════════════╗ 
          ║                        ║
          ║                        ║
          ║                        ║
          ║       Life:            ║
          ║     Energy:            ║
          ║ Initiative:            ║
          ║     Attack:            ║
          ║                        ║
          ╚════════════════════════╝ 


", 0, 2, ConsoleColor.Red);
        }
    }
}
