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
        public static bool BossFight { private get; set; }

        private static bool AlreadyDied { get; set; } 
 
        public static void StartGame()
        {
            GameSettings.LoadGameSettings();
            LoadScreen.LoadStartMenu();
        }

        public static void StartEngine()
        {
            Console.Clear();

            var currentEnemy = new Enemy() as Creature;
            var boss = new Enemy();

            if (BossFight)
            {
                boss = new Enemy();
                boss.Health = 200;
                boss.Energy = 50;
                boss.Attack = (Player.Pesho.Health / 2) + 2;
                boss.Initiative = 10;

                var abilityList = new[]
                {
                    new Ability("You shall not pass!", "Za da ti e gadno!", AbilityEffects.DirectDamage, Player.Pesho.Health / 10)
                };

                boss.AddAbilities(abilityList);
                boss.Name = "N'vetlin Sakov";
                currentEnemy = boss;
            }

            var nextLevel = Player.Pesho.Level * 10;
            var random = new Random();
            var awardXp = (int)Math.Round(currentEnemy.Health / 1.5);
            var startingRows = 35;
            var currentPlayer = (Player.Pesho.Initiative >= currentEnemy.Initiative) ? Player.Pesho : currentEnemy;
            var storedAgility = Player.Pesho.Agility;

            Console.Clear();
            DrawHelper.DrawStatsWindow();
            DrawHelper.ReloadStats(currentEnemy);

            Console.SetCursorPosition(0, startingRows++);
            Console.WriteLine(
                    DrawHelper.Color("Suddenly from no-where a giant", ConsoleColor.DarkRed),
                    DrawHelper.Color(currentEnemy.Name, ConsoleColor.Cyan),
                    DrawHelper.Color("appeared in front of you and quickly attacks!", ConsoleColor.DarkRed));

            startingRows++;

            while (Player.Pesho.Health > 0)
            {
                if (currentPlayer is Character)
                {
                    DrawHelper.TextAtPosition("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ What is your move? ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n\n", 0, 23, ConsoleColor.White);

                    var count = 1;

                    foreach (var ability in Player.Pesho.Abilities)
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
                        Player.Pesho.Action(currentEnemy, playerChoice);
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
                        var itemDrop = ItemsFactory.CreateItem();

                        MediaPlayer.Play(Sound.Win);
                        Console.SetCursorPosition(0, startingRows++);
                        DrawHelper.Color("Your enemy fall dead on the ground.\nYou won!", ConsoleColor.Green);
                        DrawHelper.TextAtPosition("\nYou gained " + awardXp + " experience!", 0, startingRows++, ConsoleColor.Yellow);
                        Player.Pesho.Experience += awardXp;

                        if (Player.Pesho.Experience >= nextLevel)
                        {
                            DrawHelper.TextAtPosition(
                                "\nCongratulations you are now " + ++Player.Pesho.Level + " level",
                                0,
                                startingRows++,
                                ConsoleColor.DarkYellow);

                            Player.Pesho.Health += 10;
                            Player.Pesho.Energy += 10;
                            Player.Pesho.Attack += 3;

                            if (Player.Pesho.Level == 5)
                            {
                                if (Player.Pesho is Mage)
                                {
                                    (Player.Pesho as Mage).LoadUltimate();
                                }
                                else if (Player.Pesho is Warrior)
                                {
                                    (Player.Pesho as Warrior).LoadUltimate();
                                }
                            }
                        }

                        Console.WriteLine(
                            DrawHelper.Color("\nYou found a", ConsoleColor.White),
                            DrawHelper.Color(itemDrop.Name, ConsoleColor.Blue));
                        DrawHelper.DisplayItemDialog(itemDrop, startingRows);

                        Player.Pesho.Agility = storedAgility;                    
                        DrawHelper.ReloadStats(currentEnemy);
                        StoryEngine.StateAfterBattle();
                        BossFight = false;
                    }
                }
                else
                {
                    if (currentEnemy.Initiative != 0)
                    {
                        var result = random.Next(0, 10 - (Player.Pesho.Agility / 10));
                        Console.SetCursorPosition(0, startingRows++);

                        if (result > 1)
                        {
                            currentEnemy.Action(Player.Pesho);
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
                    currentPlayer = Player.Pesho;
                }

                if (boss.Health == 0)
                { 
                   LoadScreen.LoadWinScreen();
                }
            }

            BossFight = false;

            if (!AlreadyDied)
            {
                DrawHelper.BlockInputAndWaitFor(1);
                MediaPlayer.Play(Sound.Death);
                DrawHelper.TextAtPosition("You Lost!", 0, startingRows, ConsoleColor.Red);
                LoadScreen.LoadLooseScreen(); // Show game over screen
                GameSettings.SaveScore();
                LoadScreen.LoadScoreScreen();
                AlreadyDied = true;
            }
        }
    }
}