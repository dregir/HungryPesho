namespace HungryPesho.Engine
{
    using System;
    using System.Threading;
    using HungryPesho.Abilities;
    using HungryPesho.Creatures;
    using HungryPesho.ExceptionClasses;
    using HungryPesho.UI;

    public class Engine
    {
        public static Character Pesho;

        public static void StartGame()
        {
            GameSettings.LoadGameSettings();
            LoadScreen.LoadStartMenu();
        }

        public static void StartEngine()
        {
            Console.Clear();

            // TODO: create ability and enemy factory.
            // TODO: validate player / enemy health for negative numbers

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

            foreach (var monster in enemies)
            { // Play with stats to test 'em here. - TODO: Generate monster accordingly player's level
                monster.Attack = 4;
                monster.Energy = 12;
                monster.Health = 50;
                monster.Initiative = 2;
                monster.Name = "Angry Doner Kebap Chef";
            }

            Console.Clear();
            DrawHelper.DrawStatsWindow();
            DrawHelper.ReloadStats(); 

            var random = new Random();

            // TODO: Battle states engine at combatEngine = new CombatEngine();
            var currentEnemy = enemies[random.Next(0, enemies.Length)]; // TODO: Player's choice ??
            var awardXp = currentEnemy.Health / 2;
            var startingRows = 35;
            var currentPlayer = (Pesho.Initiative >= currentEnemy.Initiative + 1) ? Pesho : currentEnemy;

            Console.SetCursorPosition(0, startingRows++);
            Console.WriteLine(
                    DrawHelper.Color("You wake up and suddenly from no-where a giant fucking", ConsoleColor.DarkRed),
                    DrawHelper.Color(currentEnemy.Name, ConsoleColor.Cyan),
                    DrawHelper.Color("apeared infront of you and quickly attacks!", ConsoleColor.DarkRed)
                );

            startingRows++;

            while (Pesho.Health > 0 && currentEnemy.Health > 0)
            {
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

                    var playerChoice = Console.ReadKey(true);

                    Console.SetCursorPosition(0, startingRows);

                        try
                        {
                            Pesho.Action(currentEnemy, playerChoice); 
                            
                            currentPlayer = currentEnemy;
                            startingRows++;
                        }
                        catch (GameException e)
                        {
                            DrawHelper.TextAtPosition(e.Message, 0, 33, ConsoleColor.DarkGray);
                        }

                        Thread.Sleep(2000);
                }
                else 
                {
                    if (currentEnemy.Initiative != 0)
                    {
                        var result = random.Next(0, 11);
                        Console.SetCursorPosition(0, startingRows++);

                        if (result > 1)
                        {
                            currentEnemy.Action(Pesho);  // Enemy does its thing - cast spell or attack
                        }
                        else
                        {
                            MediaPlayer.Play(Sound.MISS);

                            Console.WriteLine(result == 1 ?
                                DrawHelper.Color(currentEnemy.Name + " missed you.", ConsoleColor.White) :
                                DrawHelper.Color("You evaded!", ConsoleColor.White));
                        }
                    }
                    else
                    {
                        DrawHelper.TextAtPosition(currentEnemy.Name + " misses it's turn.",  0, startingRows++, ConsoleColor.Blue);
                    }

                    DrawHelper.ReloadStats();
                    currentEnemy.Initiative = 1; 
                    currentPlayer = Pesho;
                }
            }

            if (Pesho.Health > currentEnemy.Health)
            {
                DrawHelper.Color("Your enemy fall dead on the ground.\nYou won!", ConsoleColor.Green);
                LoadScreen.LoadWinScreen();
            }
            else
            {
                DrawHelper.TextAtPosition("You Lost!", 0, startingRows, ConsoleColor.Red);
                LoadScreen.LoadLooseScreen(); // Show game over screen
                GameSettings.SaveScore();
            }

            // TODO: If list of enemies is empty show win game screen and save score

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine(DrawHelper.Color("\nYou gained " + awardXp + " experience!", ConsoleColor.Yellow));
            Console.ResetColor();
        }
    }
}