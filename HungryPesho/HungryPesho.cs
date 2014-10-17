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
            GameSettings.LoadGameSettings();

            // Testing game menu and game info
            //GameSettings.LoadGameInfo();
            //LoadMenu.LoadStartMenu();


            // Testing character creation
            //Console.WriteLine(Mage.CreateNewMage());
            //Console.WriteLine(Warrior.CreateNewWarrior());


            // Testing weapon and armor creation
            Console.WriteLine(Weapon.CreateNewWeapon());

        }
    }
}