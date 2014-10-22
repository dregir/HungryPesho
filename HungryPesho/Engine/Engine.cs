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
            var random = new Random();

            // TODO: create ability and enemy factory.
            // TODO: validate player / enemy health for negative numbers

            // TODO: Initialize all in game enemies here
            var enemies = new Creature[]
            {
                new Enemy()
            };

            var enemyNames = new[]
            {
                "Yeti",
                "Rabbit Dog",
                "Grizzly Bear",
                "Mad Bunny",
                "Angry French Chef",
                "Spaska The Dragon",
                "StackOverflow",
                "Forest Troll",
                "Alf",
                "Joey From Friends",
                "Garfield",
                "Uncle Gosho",
                "Evil Harpy",
                "Invisible Man"
            };

            // TODO: Initialize all enemy abilities
            var enemyAbilities = new Ability[]
            {
                new Ability("KebapShot", "Throws Kebap at you", AbilityEffects.DirectDamage, 5),
                new Ability("Fireball", "Fireballs u", AbilityEffects.DirectDamage, 7),
                new Ability("Fireblast", "Fireblast u", AbilityEffects.DirectDamage, 4),
                new Ability("Spectral Hit", "Spectral hits u", AbilityEffects.DirectDamage, random.Next(1, 21)),
                ////new Ability("Frost Nova", "Freeze you at place", AbilityEffects.Freeze, 4)
            };

            foreach (var enemy in enemies)
            {
                enemy.AddAbilities(enemyAbilities);
            }

            foreach (var monster in enemies)
            { // Play with stats to test 'em here. - TODO: Generate monster accordingly player's level
                monster.Attack = random.Next(2, Pesho.Attack * 2);
                monster.Energy = random.Next(Pesho.Energy / 2, Pesho.Energy * 2);
                monster.Health = random.Next(Pesho.Attack * 2, (Pesho.Attack * 3) + (3 * Pesho.Level));
                monster.Initiative = random.Next(1, 6);
                monster.Name = enemyNames[random.Next(0, enemyNames.Length)];
            }

            // TODO: Battle states engine at combatEngine = new CombatEngine();
            var currentEnemy = enemies[random.Next(0, enemies.Length)]; // TODO: Player's choice ??
            var awardXp = currentEnemy.Health / 2;
            var startingRows = 35;
            var currentPlayer = (Pesho.Initiative >= currentEnemy.Initiative) ? Pesho : currentEnemy;
            var storedAgility = Pesho.Agility; 

            Console.Clear();
            DrawHelper.DrawStatsWindow();
            DrawHelper.ReloadStats(currentEnemy);

            Console.SetCursorPosition(0, startingRows++);
            Console.WriteLine(
                    DrawHelper.Color("You wake up and suddenly from no-where a giant fucking", ConsoleColor.DarkRed),
                    DrawHelper.Color(currentEnemy.Name, ConsoleColor.Cyan),
                    DrawHelper.Color("appeared in front of you and quickly attacks!", ConsoleColor.DarkRed));

            startingRows++;

            while (Pesho.Health > 0)
            {
                if (currentPlayer is Character)
                {
                    DrawHelper.TextAtPosition("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ What is your move? ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n\n", 0, 23, ConsoleColor.White);
                
                    var count = 1;

                    foreach (var ability in Pesho.Abilities)
                    {
                        Console.WriteLine(
                            DrawHelper.Color(">>", ConsoleColor.Cyan),
                            DrawHelper.Color(count + ".", ConsoleColor.Yellow),
                            DrawHelper.Color(ability.Name, ConsoleColor.Green),
                            DrawHelper.Color(" → " + ability.Description, ConsoleColor.Gray));
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
                        continue;
                    }
                       
                    DrawHelper.BlockInputAndWaitFor(2);

                    if (currentEnemy.Health == 0)
                    {
                        MediaPlayer.Play(Sound.Win);
                        Console.SetCursorPosition(0, startingRows);
                        DrawHelper.Color("Your enemy fall dead on the ground.\nYou won!", ConsoleColor.Green);
                        Console.WriteLine(DrawHelper.Color("\nYou gained " + awardXp + " experience!", ConsoleColor.Yellow));

                        Pesho.Agility = storedAgility;
                        Pesho.Experience += awardXp;

                        DrawHelper.BlockInputAndWaitFor(3);
                        StoryEngine.StateAfterBattle();
                    }
                }
                else
                {
                    if (currentEnemy.Initiative != 0)
                    {
                        var result = random.Next(0, 10 - (Pesho.Agility / 10));
                        Console.SetCursorPosition(0, startingRows++);
                        
                        if (result > 1)
                        {
                            currentEnemy.Action(Pesho);  
                        }
                        else
                        {
                            MediaPlayer.Play(Sound.Miss);

                            Console.WriteLine(result == 1 ?
                                DrawHelper.Color(currentEnemy.Name + " missed you.", ConsoleColor.White) :
                                DrawHelper.Color("You evaded!", ConsoleColor.White));
                        }
                    }
                    else
                    {
                        DrawHelper.TextAtPosition(currentEnemy.Name + " misses it's turn.", 0, startingRows++, ConsoleColor.Blue);
                    }

                    DrawHelper.ReloadStats(currentEnemy);
                    currentEnemy.Initiative = 1;
                    currentPlayer = Pesho;
                }

                if (enemies.Length == 0)
                { // TODO: If list of enemies is empty show win game screen and save score
                    LoadScreen.LoadWinScreen();
                }
            }

            Thread.Sleep(1000);
            MediaPlayer.Play(Sound.Death);
            DrawHelper.TextAtPosition("You Lost!", 0, startingRows, ConsoleColor.Red);
            LoadScreen.LoadLooseScreen(); // Show game over screen
            GameSettings.SaveScore();
            LoadScreen.LoadScoreScreen();
        }
    }
}