using System.Security.Cryptography.X509Certificates;

namespace HungryPesho.UI
{
    using System;
    using HungryPesho.Creatures;
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
                    methods[selection]();
                }

                if (input.Key.Equals(ConsoleKey.Escape))
                {
                    LoadScreen.LoadStartMenu();
                }
            }
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
            const int startPos = 4;
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
                Console.SetCursorPosition(100, startPos + i);
                Console.Write(Color(peshoStats[i].ToString(), peshoColors[i]));
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

        #region ASCII Drawnings

        public static void DrawStartingWindow()
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

        public static void DrawGameWindow()
        {
            Console.Write(@"
                                                                                      +-----------------------+
                                                                                      |                       |
                                                                                      |  Pesho 1 Lvl Class    |
                                                                                      |       Life:           |
                                                                                      |     Energy:           |       
                                                                                      | Initiative:           |
                                                                                      |     Attack:           |
                                                                                      |                       |
                                                                                      +-----------------------+

");
        }

        public static Character SelectCharacter()
        {
            DrawHelper.Color(@"
                    ____    __        __                             __           
                   / __/__ / /__ ____/ /_  __ _____  __ ______  ____/ /__ ____ ___
                  _\ \/ -_) / -_) __/ __/ / // / _ \/ // / __/ / __/ / _ `(_-<(_-<
                 /___/\__/_/\__/\__/\__/  \_, /\___/\_,_/_/    \__/_/\_,_/___/___/
                                         /___/                                    
",
 ConsoleColor.Blue);

            TextAtPosition("Warrior", 15, 38, ConsoleColor.White, ConsoleColor.DarkRed);
            TextAtPosition("Mage", 70, 38, ConsoleColor.White);
            var selection = 0;

            Action<int> switchClass = (pos) =>
            {
                ConsoleColor warColor;
                ConsoleColor mageColor;

                if (pos == 0)
                {
                    warColor = ConsoleColor.White;
                    mageColor = ConsoleColor.DarkGray;
                }

                else
                {
                    warColor = ConsoleColor.DarkGray;
                    mageColor = ConsoleColor.White;
                }

                TextAtPosition(@"
                                                                        ____
                                                                      .'* *.'
                                                                   __/_*_*(_
                                                                  / _______ \
                                                                 _\_)/___\(_/_
                                                                / _((\- -/))_ \
                                                                \ \())(-)(()/ /
                                                                 ' \(((()))/ '
                                                                / ' \)).))/ ' \
                                                               / _ \ - | - /_  \
                                                              (   ( .;''';. .'  )
                                                              _\ __ /    )\ __ /_
                                                                \/  \   ' /  \/
                                                                 .'  '...' ' )
                                                                  / /  |  \ \
                                                                 / .   .   . \
                                                                /   .     .   \
                                                               /   /   |   \   \
                                                             .'   /    b    '.  '.
                                                         _.-'    /     Bb     '-. '-._
                                                      .-'       |      BBb       '-.  '-.
                                                     (________mrf\____.dBBBb.________)____)", 0, 10, mageColor);



                TextAtPosition
                (@"
                  .I.
                 / : \
                 |===|
                 >._.<
             .=-<     >-=.
            /.'`(`-+-')'`.\
          _/`.__/  :  \__.'\_
         ( `._/\`. : .'/\_.' )
          >-(_) \ `:' / (_)-<
          | |  / \___/ \  | |
          )^( | .' : `. | )^(
         |  _\|`-._:_.-'| \  |
          -<\)| :  |  : |  '-'
           (\\| : / \ : |
             \\-:-| |-:-')
              \\:_/ \_:_/
              |\\_| |_:_|
              (;\\/ \__;)
              |: \\  | :|
              \: /\\ \ :/
              |==| \\|==|
             /v-'(  \\`-v\
            /  .-'   \\. \\
            `-'       \\`-'    
                       \|"
                    , 0, 10, warColor);
            };
        #endregion

            switchClass(selection);

            while (true)
            {
                var input = Console.ReadKey(true);

                if (input.Key.Equals(ConsoleKey.LeftArrow) ||
                    input.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (selection == 0)
                    {
                        TextAtPosition("Warrior", 15, 38, ConsoleColor.White);
                        TextAtPosition("Mage", 70, 38, ConsoleColor.White, ConsoleColor.Blue);
                        selection++;
                    }
                    else
                    {
                        TextAtPosition("Warrior", 15, 38, ConsoleColor.White, ConsoleColor.DarkRed);
                        TextAtPosition("Mage", 70, 38, ConsoleColor.White);
                        selection--;
                    }
                    switchClass(selection);
                    continue;
                }


                if (input.Key.Equals(ConsoleKey.Enter))
                {
                    Console.Clear();
                    return selection == 1 ? new Mage() : (Character)new Warrior();
                }

                if (input.Key.Equals(ConsoleKey.Escape))
                {
                    LoadScreen.LoadStartMenu();
                }
            }
        }
    }
}
