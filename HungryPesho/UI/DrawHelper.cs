using System;
using HungryPesho.Creatures;
using HungryPesho.Engine;

namespace HungryPesho.UI
{
    public static class DrawHelper
    {
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
                    TestEngine.Pesho.Health,
                    TestEngine.Pesho.Energy,
                    TestEngine.Pesho.Initiative,
                    TestEngine.Pesho.Attack
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
                    Console.SetCursorPosition(103, startPos + i);
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
        public static void DrawStatsWindow()
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