namespace HungryPesho
{
    using System;
    using System.Collections;
    using HungryPesho.Creatures;
    using HungryPesho.Items;
    using HungryPesho.Engine;
    using HungryPesho.UI;

    // Console test
    public class HungryPeshoTest
    {
        public static void Main()
        {
            // Testing game menu and game info
            GameSettings.LoadGameSettings();
            LoadScreen.LoadStartMenu();

            // Testing character creation
            // Console.WriteLine(Mage.CreateNewMage());
            // Console.WriteLine(Warrior.CreateNewWarrior());

            // Testing weapon and armor creation
            // Console.WriteLine(ItemsFactory.CreateItem().GetType());

            // Testing Engine
            // Engine.StartEngine();
        }
    }
}