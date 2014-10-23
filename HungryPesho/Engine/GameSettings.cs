namespace HungryPesho.Engine
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using HungryPesho.Creatures;
    using HungryPesho.UI;

    public static class GameSettings
    {
        public const int GameWidth = 120;
        public const int GameHeight = 50;
        public const string FilePath = "../../misc/";

        public static bool SoundStatus { get; set; }

        public static void LoadGameSettings() // Load default game settings
        {
            // Creating and initializing game window;
            Console.Title = "Hungry Pesho";
            Console.CursorVisible = false;
            Console.SetWindowSize(GameWidth, GameHeight);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            SoundStatus = true;
        }

        public static void SaveGameSettings() // Saves game settings
        {
            try
            {
                var writer = new StreamWriter("settings.hup");

                using (writer)
                {
                    // TODO: Save current settings
                }
            }
            catch (Exception)
            {
                DrawHelper.TextAtPosition("SAVE FILED!", GameWidth / 2, GameHeight / 3, ConsoleColor.Red);
            }

            DrawHelper.TextAtPosition("SAVED!", GameWidth / 2, GameHeight / 3, ConsoleColor.Green);

            Thread.Sleep(2000);
            LoadScreen.LoadStartMenu();
        }

        public static void SaveGame() // Save current game
        {
            try
            {
                var writer = new StreamWriter(FilePath + "saves.hup");

                using (writer)
                {
                    // writer.WriteLine(Engine.Pesho.Abilities.ToString()); // TODO: If there is a chance to earn abilities
                    writer.WriteLine(Player.Pesho.Name);
                    writer.WriteLine(Player.Pesho.Level);
                    writer.WriteLine(Player.Pesho.Attack);
                    writer.WriteLine(Player.Pesho.Energy);
                    writer.WriteLine(Player.Pesho.Health);
                    writer.WriteLine(Player.Pesho.Initiative);
                    writer.WriteLine(Player.Pesho.Agility);
                    writer.WriteLine(Player.Pesho.Intellect);
                    writer.WriteLine(Player.Pesho.Strength);
                }
            }
            catch (Exception)
            {
                DrawHelper.TextAtPosition("SAVE GAME FAILED!", GameWidth / 3, GameHeight / 3, ConsoleColor.Red);
            }

            DrawHelper.TextAtPosition("GAME SAVED!", GameWidth / 3, GameHeight / 3, ConsoleColor.Green);

            Thread.Sleep(2000);
            Engine.StartEngine();
        }

        public static void LoadGame() // Load current game
        {
            try
            {
                var reader = new StreamReader(FilePath + "saves.hup");

                using (reader)
                {
                    if (reader.ReadLine() == "Mage")
                    {
                        Player.Pesho = Player.SetClass(new Mage());
                        Player.Pesho.Name = "Mage";
                    }
                    else
                    {
                        Player.Pesho = Player.SetClass(new Warrior());
                        Player.Pesho.Name = "Warrior";
                    }

                    Player.Pesho.Level = int.Parse(reader.ReadLine());
                    Player.Pesho.Attack = int.Parse(reader.ReadLine());
                    Player.Pesho.Energy = int.Parse(reader.ReadLine());
                    Player.Pesho.Health = int.Parse(reader.ReadLine());
                    Player.Pesho.Initiative = int.Parse(reader.ReadLine());
                    Player.Pesho.Agility = int.Parse(reader.ReadLine());
                    Player.Pesho.Intellect = int.Parse(reader.ReadLine());
                    Player.Pesho.Strength = int.Parse(reader.ReadLine());
                }
            }
            catch (Exception)
            {
                DrawHelper.TextAtPosition("LOAD GAME FAILED!", GameWidth / 3, GameHeight / 3, ConsoleColor.Red);
            }

            DrawHelper.TextAtPosition("GAME LOADED!", GameWidth / 3, GameHeight / 3, ConsoleColor.Green);

            Thread.Sleep(2000);
            Engine.StartEngine();
        }

        public static void SaveScore() // Save player's score
        {
            DrawHelper.TextAtPosition("Enter your nickname: ", GameWidth / 3, GameHeight - 17, ConsoleColor.Cyan);
            Player.Pesho.Name = Console.ReadLine();

            var score = Player.Pesho.Level;

            try
            {
                var scores = File.ReadAllLines(FilePath + "scores.hup").ToList();
                int currnetScore = int.MaxValue;

                for (int i = 0; i < scores.Count; i++)
                {
                    currnetScore = int.Parse(scores[i].Split(' ')[1]);

                    if (currnetScore <= score)
                    {
                        scores.Insert(i, Player.Pesho.Name + " " + score);
                        File.WriteAllLines(FilePath + "scores.hup", scores.ToArray());
                        break;
                    }
                }
            }
            catch (Exception)
            {
                DrawHelper.TextAtPosition("Your score cannot be saved!", GameWidth / 2, GameHeight / 2, ConsoleColor.Red);
            }
        }

        public static void TurnSoundOn() // Turn sound ON
        {
            SoundStatus = true;
            LoadScreen.LoadStartMenu();
        }

        public static void TurnSoundOff() // Turn sound OFF
        {
            SoundStatus = false;
            LoadScreen.LoadStartMenu();
        }
    }
}