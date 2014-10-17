using System;
using HungryPesho.Abilities;
using HungryPesho.Creatures;
using HungryPesho.UI;

namespace HungryPesho.Engine
{
    public class TestEngine
    {
        public static void StartEngine()
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
    .-'   \\. \\
   `-'       \\`-'    
              \|
");

            Console.WriteLine(@"                 
                                                                           
          
                                                          ");

            //I guess we need Ability and Enemy factory for those as well, hardcoding `em for now.
            var kebap = new Ability("KebapShot", "Throws Kebap to you", AbilityEffects.DirectDamage, 10);
            var peshaka = Mage.CreateNewMage();
            var monsters = new Creature[]
            {
                new Enemy{Ability = kebap},
                new Enemy{Ability = kebap},
                new Enemy{Ability = kebap},
                new Enemy{Ability = kebap},
            };

            foreach (var monster in monsters) //Play with stats to test 'em here.
            {
                monster.Attack = 1;
                monster.Energy = 10;
                monster.Health = 5;
                monster.Initiative = 3;
                monster.Name = "Angry Chef";

            }

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
                var currentPlayer = (peshaka.Initiative >= enemy.Initiative + 1) ? peshaka : enemy; // we can check for initiative modifiers (items scrolls etc. here)

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
                                Color.ColorMe("You raise your weapon and with a swift move deal", ConsoleColor.White),
                                Color.ColorMe(damageDone.ToString(), ConsoleColor.Green),
                                Color.ColorMe("damage to the poor", ConsoleColor.White),
                                Color.ColorMe(enemy.Name, ConsoleColor.Cyan) + ".");

                            currentPlayer = enemy;
                        }
                        else
                        {
                            enemy.Action(peshaka);
                            currentPlayer = peshaka;
                        }

                    }
                    else // picks result
                    {
                        if (currentPlayer == peshaka)
                        {
                            Console.WriteLine(result == 0 ? Color.ColorMe("You missed.", ConsoleColor.Gray) :
                                Color.ColorMe(enemy.Name + " evaded your strike!", ConsoleColor.DarkGray));
                            currentPlayer = enemy;
                        }
                        else if (currentPlayer == enemy)
                        {
                            Console.WriteLine(result == 1 ? Color.ColorMe(enemy.Name + " missed you.", ConsoleColor.White) :
                                Color.ColorMe("You evaded!", ConsoleColor.White));
                            currentPlayer = peshaka;
                        }

                    }
                }
                Console.WriteLine((peshaka.Health > enemy.Health) ? Color.ColorMe("Your enemy fall dead on the ground.\nYou won!", ConsoleColor.Green) :
                   Color.ColorMe("You Lost!", ConsoleColor.Red));

                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Current HP: {0}, XP GAIN: {1}", peshaka.Health, awardXp);
            }
        }
    }
}