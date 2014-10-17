using System;

namespace HungryPesho.UI
{
    public class Color
    {
        public static string ColorMe(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text + " ");
            Console.ResetColor();
            return "";
        }
    }
}
