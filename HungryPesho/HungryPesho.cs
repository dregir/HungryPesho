namespace HungryPesho
{
    using System;
    using System.Collections;
    using HungryPesho.Creatures;
    using HungryPesho.Items;
    using HungryPesho.UI;
    using HungryPesho.Engine;

    // Console test
    public class HungryPeshoTest
    {
        public static void Main()
        {
            // Characters
            //Character mage = new Mage();
            //Character warrior = new Warrior();

            //Console.WriteLine(mage.CharacterName);
            //Console.WriteLine(mage.CharacterDescription + Environment.NewLine);

            //Console.WriteLine(warrior.CharacterName);
            //Console.WriteLine(warrior.CharacterDescription + Environment.NewLine);

            GameSettings.LoadGameSettings();
            //GameSettings.LoadGameInfo();
            LoadMenu.LoadStartMenu();
        }
    }
}