namespace HungryPesho.Engine
{
    using System;
    using HungryPesho.Abilities;
    using HungryPesho.Creatures;
    using HungryPesho.UI;
    using HungryPesho.Interfaces;
    using System.Threading;
    using System.Collections.Generic;

    public class Engine
    {
        public static Character Pesho;

        public static void StartEngine()
        {
            // Initialize player - TODO: Player's choice
            Pesho = new Mage();

            //I guess we need Ability and Enemy factory for those as well, hardcoding `em for now.
            //Todo create ability and enemy factory.

            // TODO: Initialize all ingame enemies here
            var enemies = new Creature[]
            {
                new Enemy()
            };

            // TODO: Initialize all enemy abilities
            var enemyAbilities = new Ability[]
            {
                new Ability("KebapShot", "Throws Kebap to you", AbilityEffects.DirectDamage, 5)
            };

            foreach (var enemy in enemies)
            {
                enemy.AddAbilities(enemyAbilities);
            }

            foreach (var monster in enemies) // Play with stats to test 'em here. - TODO: Generate monster accordingly player's level
            {
                monster.Attack = 3;
                monster.Energy = 12;
                monster.Health = 50;
                monster.Initiative = 2;
                monster.Name = "Angry Doner Kebap Chef";
            }

            Console.Clear();
            DrawHelper.DrawGameWindow();
            DrawHelper.ReloadStats(); // Show stats screen

            var random = new Random();

            // TODO: Battle states engine
            //ar combatEngine = new CombatEngine();

            var currentEnemy = enemies[random.Next(0, enemies.Length)]; // TODO: Player's choice ??
            var awardXp = currentEnemy.Health / 2;
            var startingRows = 35;
            var currentPlayer = (Pesho.Initiative >= currentEnemy.Initiative + 1) ? Pesho : currentEnemy;

            Console.SetCursorPosition(0, startingRows++);
            Console.WriteLine(
                DrawHelper.Color("You wake up and suddenly from no-where a giant fucking", ConsoleColor.DarkRed),
                DrawHelper.Color(currentEnemy.Name, ConsoleColor.Cyan),
                DrawHelper.Color("apeared infront of you and quickly attacks!", ConsoleColor.DarkRed));
            startingRows++;

            while (Pesho.Health > 0 && currentEnemy.Health > 0)
            {


                // Chance to miss 10% / Agility


                var damageDone = random.Next(1, currentPlayer.Attack + 1); // apply attack modifiers here.

                if (currentPlayer is Character)
                {
                    DrawHelper.TextAtPosition("What is your move?\r\n", 15, 25, ConsoleColor.White);

                    // Draw all abilities
                    var count = 1;

                    foreach (var ability in Pesho.Abilities)
                    {
                        Console.WriteLine("\r\n(  {0} -=[ {1} ]  )═════> {2} =-", count, ability.Name, ability.Description);
                        count++;
                    }

                    //Todo implement ability/action choice logic here
                    var playerChoice = Console.ReadKey(true);

                    Console.SetCursorPosition(0, startingRows);

                        try
                        {
                            Pesho.Action(currentEnemy, playerChoice); //if no exception we do the changes
                            DrawHelper.ReloadStats();
                            currentPlayer = currentEnemy;
                            startingRows++;
                        }

                        catch (ArgumentException e)
                        {
                            DrawHelper.TextAtPosition(e.Message, 0, 33, ConsoleColor.DarkGray);
                        }             
                }

                else
                {
                    var result = random.Next(0, 11);
                    Console.SetCursorPosition(0, startingRows++);

                    if (result > 1)
                    {
                        currentEnemy.Action(currentPlayer);  // Enemy does its thing - cast spell or attack
                    }

                    else
                    {
                        Console.WriteLine(result == 1 ? 
                            DrawHelper.Color(currentEnemy.Name + " missed you.", ConsoleColor.White) :
                            DrawHelper.Color("You evaded!", ConsoleColor.White));
                    }

                    DrawHelper.ReloadStats();
                    currentPlayer = Pesho;
                }
            }

            if (Pesho.Health > currentEnemy.Health)
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