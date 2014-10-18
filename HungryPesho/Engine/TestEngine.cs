using System;
using HungryPesho.Abilities;
using HungryPesho.Creatures;
using HungryPesho.UI;

namespace HungryPesho.Engine
{
    public class TestEngine
    {
        public static Character Pesho;

        public static void StartEngine()
        {

            Pesho = Mage.CreateNewMage();
            Pesho.Initiative = 4;

            //I guess we need Ability and Enemy factory for those as well, hardcoding `em for now.
            //Todo create ability and enemy factory.
            var kebap = new Ability("KebapShot", "Throws Kebap to you", AbilityEffects.DirectDamage, 5);
            var monsters = new Creature[]
            {
                new Enemy{Ability = kebap},
                new Enemy{Ability = kebap},
                new Enemy{Ability = kebap},
                new Enemy{Ability = kebap},
            };

            foreach (var monster in monsters) //Play with stats to test 'em here.
            {
                monster.Attack = 3;
                monster.Energy = 12;
                monster.Health = 5;
                monster.Initiative = 2;
                monster.Name = "Angry Doner Kebap Chef";
            }

            Console.Clear();
            DrawHelper.DrawStatsWindow();
            DrawHelper.ReloadStats();      //show stats screen

            var random = new Random();
            var choiceIsMade = true;
            var enemy = monsters[random.Next(0, monsters.Length)];
            var awardXp = enemy.Health / 2;
            var startingRows = 35;
            var currentPlayer = (Pesho.Initiative >= enemy.Initiative + 1) ? Pesho : enemy;

            Console.SetCursorPosition(0, startingRows++);
            Console.WriteLine(
                DrawHelper.Color("You wake up and suddenly from no-where a giant fucking", ConsoleColor.DarkRed),
                DrawHelper.Color(enemy.Name, ConsoleColor.Cyan),
                DrawHelper.Color("apeared infront of you and quickly attacks!", ConsoleColor.DarkRed));
            startingRows++;

            while (Pesho.Health > 0 && enemy.Health > 0)
            {
                //Calculate the odds and print result.
                // There is 10 % chance to miss and 10 % chance to evade.
                var result = random.Next(0, 11);

                if (result > 1 ) // a hit is land.
                {
                    var damageDone = random.Next(1, currentPlayer.Attack + 1); // apply attack modifiers here.

                    if (currentPlayer == Pesho)
                    {
                        DrawHelper.TextAtPosition("What is your move?", 15, 25, ConsoleColor.White);
                        DrawHelper.TextAtPosition("-=[ 1 ]  )=={═════> SIMPLE WEAPON ATTACK =-", 5, 27, ConsoleColor.Green);
                        DrawHelper.TextAtPosition("1", 9, 27, ConsoleColor.Yellow);
                        var playerChoice = Console.ReadKey(true);

                        if (playerChoice.Key.Equals(ConsoleKey.D1))
                        {
                            //Todo implement ability/action choice logic here

                            enemy.Health -= damageDone;
                            DrawHelper.ReloadStats();
                            Console.SetCursorPosition(0, startingRows++);
                            Console.WriteLine
                                (
                                    DrawHelper.Color("You raise your weapon and with a swift move deal",
                                        ConsoleColor.White),
                                    DrawHelper.Color(damageDone.ToString(), ConsoleColor.Green),
                                    DrawHelper.Color("damage to the poor", ConsoleColor.White),
                                    DrawHelper.Color(enemy.Name, ConsoleColor.Cyan));

                            currentPlayer = enemy;
                        }
                        else
                        {
                            choiceIsMade = false;
                        }
                    }

                    else
                    {
                        Console.SetCursorPosition(0, startingRows++);
                        enemy.Action(Pesho);  //Enemy does its thing - cast spell or attack
                        DrawHelper.ReloadStats();
                        currentPlayer = Pesho;
                    }
                }

                else if (choiceIsMade)
                {
                    Console.SetCursorPosition(0, startingRows++);
                    if (currentPlayer == Pesho)
                    {
                        Console.WriteLine(result == 0 ? DrawHelper.Color("You missed.", ConsoleColor.Gray) :
                            DrawHelper.Color(enemy.Name + " evaded your strike!", ConsoleColor.DarkGray));
                        currentPlayer = enemy;
                    }

                    else if (currentPlayer == enemy)
                    {
                        Console.WriteLine(result == 1 ? DrawHelper.Color(enemy.Name + " missed you.", ConsoleColor.White) :
                            DrawHelper.Color("You evaded!", ConsoleColor.White));
                        currentPlayer = Pesho;
                    }
                }
            }

            if (Pesho.Health > enemy.Health)
            {
                DrawHelper.Color("Your enemy fall dead on the ground.\nYou won!", ConsoleColor.Green);

                //Thread.Sleep(2000);
                //LoadScreen.LoadWinScreen(); // Show win screen
            }

            else
            {
                DrawHelper.TextAtPosition("You Lost!", 0, startingRows, ConsoleColor.Red);
                LoadScreen.LoadLooseScreen(Pesho.Level); // Show game over screen
            }

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine(DrawHelper.Color("\nYou gained " + awardXp + " experience!", ConsoleColor.Yellow));
            Console.ResetColor();
        }
    }
}
