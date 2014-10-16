namespace HungryPesho
{
    using System.Collections.Generic;
    using HungryPesho.Creatures;

    using System;
    using System.Collections;
    using HungryPesho.Characters;
    using HungryPesho.Items;

    // Console test
    public class HungryPeshoTest
    {
        public static void Main()
        {
            // Characters
            Character mage = new Mage();
            Character warrior = new Warrior();





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
            Console.SetCursorPosition(20, 5);
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
   // .-'   \\. \\
   `-'       \\`-'    
              \|
");

            Console.WriteLine(@"                 
                                                                           |
          

                                                         ");


            var peshaka = new Mage { Health = 50, Attack = 2 };

            var monsters = new Creature[]
            {
                new FireLizzard(),
                new OgreMage(),
                new FireLizzard(),
                new OgreMage()
            };


            //Automate Game Simulation Test;
            var inp = Console.ReadLine();

            if (inp == "start")
                Console.Clear();
            {
                //Encounter Random enemy 
                var random = new Random();
                var enemy = monsters[random.Next(0, monsters.Length)];
                var awardXp = enemy.Health / 2;
                Console.WriteLine("You wake up and suddenly from no-where (ye absolutely nowhere) a giant fucking {0} aparead infront of you " +
                                  "and quickly attacks you! [BATTLE START]", enemy.Name);  //We can implement a class with different scenarios for theese.

                // Game compares initiative and picks who attacks first, since your enemy attacked you, and not the opposite, the enemy have 1 bonus initiative;
                var currentPlayer = (peshaka.Initiative >= enemy.Initiative + 1) ? (ILiving)peshaka : enemy; // we can check for initiative modifiers (items scrolls etc. here)

                //Game lasts until one of the opponents health reaches 0;
                while (peshaka.Health > 0 && enemy.Health > 0)
                {
                    //Calculate the odds and print result.
                    // There is 10 % chance to miss and 10 % chance to evade.
                    var result = random.Next(0, 11);

                    if (result > 1) // a hit is land.
                    {
                        var damageDone = random.Next(1, (int)currentPlayer.Attack + 1); // apply attack modifiers here.

                        if (currentPlayer == peshaka)  //Currenlty auto play, no implementation of actions to pick from 
                        {
                            enemy.Health -= damageDone;

                            Console.WriteLine(
                                ColorMe.Color("You raise your weapon and with a swift move deal", ConsoleColor.White),
                                ColorMe.Color(damageDone.ToString(), ConsoleColor.Green),
                                ColorMe.Color("damage to the poor", ConsoleColor.White),
                                ColorMe.Color(enemy.Name, ConsoleColor.Cyan) + ".");

                            currentPlayer = enemy;
                        }
                        else
                        {
                            var chanceToUseAbility = random.Next(0, 4);

                            if (chanceToUseAbility == 2)
                            {
                                if (enemy.Abilities.Count > 0)
                                {
                                    enemy.Abilities[random.Next(0, enemy.Abilities.Count)].Effect(enemy, peshaka);
                                }
                            }

                            else
                            {
                                peshaka.Health -= damageDone;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(
                                "The nasty {0} inflicts {1} damage to your skinny body.",
                                                                             enemy.Name,
                                                                             damageDone);
                                Console.ResetColor();
                            }

                            currentPlayer = peshaka;
                        }

                    }
                    else // picks result
                    {
                        if (currentPlayer == peshaka)
                        {
                            Console.WriteLine(result == 0 ? ColorMe.Color("You missed.", ConsoleColor.Gray) :
                                ColorMe.Color(enemy.Name + " evaded your strike!", ConsoleColor.DarkGray));
                            currentPlayer = enemy;
                        }
                        else if (currentPlayer == enemy)
                        {
                            Console.WriteLine(result == 1 ? ColorMe.Color(enemy.Name + " missed you.", ConsoleColor.White) :
                                ColorMe.Color("You evaded!", ConsoleColor.White));
                            currentPlayer = peshaka;
                        }

                    }
                }
                Console.WriteLine((peshaka.Health > enemy.Health) ? ColorMe.Color("Your enemy fall dead on the ground.\nYou won!", ConsoleColor.Green) :
                   ColorMe.Color("You Lost!", ConsoleColor.Red));

                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Current HP: {0}, XP GAIN: {1}", peshaka.Health, awardXp);
            }
        }
    }
}