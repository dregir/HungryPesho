namespace HungryPesho.UI
{
    using System;
    using System.Collections.Generic;
    using HungryPesho.Creatures;
    using HungryPesho.Engine;

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
            return string.Empty;
        }

        public static void ReloadStats()
        {
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
        }

        public static void TextAtPosition(string text, int col, int row, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
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

        public static void DrawAsciiClasses()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"

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
                                           (________mrf\____.dBBBb.________)____)



");
            Console.SetCursorPosition(0, 1);
            Console.ResetColor();
            Console.Write(@"

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
              \|");
        }
        #endregion
    }
}