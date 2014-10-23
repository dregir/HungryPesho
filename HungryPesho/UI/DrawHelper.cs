namespace HungryPesho.UI
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using HungryPesho.Creatures;
    using HungryPesho.Engine;
    using HungryPesho.Items;

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
                    cursorPos = initialPosition + ((menuChoices.Length - 1) * 2);
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
                var input = Console.ReadKey(true); 

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

        public static void TextAtPosition(string text, int col, int row, ConsoleColor color = ConsoleColor.Green, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = backgroundColor;
            Console.SetCursorPosition(col, row);
            Console.Write(text);
            Console.ResetColor();
        }

        public static void ScrollingText(string text, bool pressedKey = false)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);

                if (pressedKey)
                {
                    Console.WriteLine(text);
                    break;
                }

                Thread.Sleep(30);
            }
        }

        public static string Color(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text + " ");
            Console.ResetColor();

            return string.Empty;
        }

        public static void ReloadStats(Creature enemy)
        {
            string charClass = Player.Pesho.GetType().Name;
            int level = Player.Pesho.Level;
            const int StartPos = 7;

            var peshoStats = new[]
            {
               new { stat = Player.Pesho.Health, color = ConsoleColor.Magenta },
               new { stat = Player.Pesho.Energy, color = ConsoleColor.Cyan },
               new { stat = Player.Pesho.Initiative, color = ConsoleColor.DarkGreen },
               new { stat = Player.Pesho.Attack, color = ConsoleColor.Red },             
            };

            var enemyStats = new[]
            {
                new { stat = enemy.Health, color = ConsoleColor.Magenta },
                new { stat = enemy.Energy, color = ConsoleColor.Cyan },
                new { stat = enemy.Initiative, color = ConsoleColor.DarkGreen },
                new { stat = enemy.Attack, color = ConsoleColor.Red },
            };

            for (int i = 0; i < peshoStats.Length; i++)
            {
                Console.SetCursorPosition(100, StartPos + i);
                Console.Write(Color(peshoStats[i].stat.ToString(), peshoStats[i].color));
                Console.SetCursorPosition(25, StartPos + i);
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

            while (startTime.AddSeconds(seconds) > DateTime.Now)
            { // Prevents from key spamming while waiting!

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
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
            string statsWindows = @"
          ╔════════════════════════╗ 
          ║                        ║
          ║                        ║
          ║                        ║
          ║       Life:            ║
          ║     Energy:            ║
          ║ Initiative:            ║
          ║     Attack:            ║
          ║                        ║
          ╚════════════════════════╝";

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
                                                    |/         \|");
            TextAtPosition(statsWindows, 0, 2, ConsoleColor.Red);
        }

        public static void DisplayItemDialog(Item item, int rowToDisplay)
        {
            var itemStats = string.Empty;
            string option1 = "1. Take and equip the " + item.Name;
            string option2 = "2. Leave the " + item.Name + " on the ground.";

            if (item is Armor)
            {
                itemStats = (item as Armor).ToString();
            }
            else if (item is Weapon)
            {
                itemStats = (item as Weapon).ToString();
            }
            else
            {
                option1 = "1. Take and consume the " + item.Name;
            }

            DrawHelper.TextAtPosition(option1, 44, rowToDisplay + 3, ConsoleColor.White);
            DrawHelper.TextAtPosition(option2, 44, rowToDisplay + 4, ConsoleColor.White);
            DrawHelper.TextAtPosition("--------------\n" + itemStats, 0, rowToDisplay + 4, ConsoleColor.DarkYellow);

            while (true)
            {
                var action = Console.ReadKey(true);

                if (!action.Key.Equals(ConsoleKey.D1) && !action.Key.Equals(ConsoleKey.D2))
                {
                    TextAtPosition("Invalid key option!", 0, 33, ConsoleColor.DarkGray);
                }
                else
                {
                    if (action.Key.Equals(ConsoleKey.D1))
                    {
                        Player.Pesho.AddItem(item);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}