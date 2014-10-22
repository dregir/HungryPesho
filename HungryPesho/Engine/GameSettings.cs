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
        public const bool SoundStatus = true;

        public static void LoadGameSettings() // Load default game settings
        {
            // Creating and initializing game window;
            Console.Title = "Hungry Pesho";
            Console.CursorVisible = false;
            Console.SetWindowSize(GameWidth, GameHeight);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
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
                    writer.WriteLine(Engine.Pesho.Name);
                    writer.WriteLine(Engine.Pesho.Level);
                    writer.WriteLine(Engine.Pesho.Attack);
                    writer.WriteLine(Engine.Pesho.Energy);
                    writer.WriteLine(Engine.Pesho.Health);
                    writer.WriteLine(Engine.Pesho.Initiative);
                    writer.WriteLine(Engine.Pesho.Agility);
                    writer.WriteLine(Engine.Pesho.Intellect);
                    writer.WriteLine(Engine.Pesho.Strength);
                }
            }
            catch (Exception)
            {
                DrawHelper.TextAtPosition("SAVE GAME FAILED!", GameWidth / 3, GameHeight / 3, ConsoleColor.Red);
            }

            DrawHelper.TextAtPosition("GAME SAVED!", GameWidth / 3, GameHeight / 3, ConsoleColor.Green);

            Thread.Sleep(2000);
            Engine.StartEngine(); // TODO: Start from current progress
        }

        public static void LoadGame() // Load current game
        {
            try
            {
                var reader = new StreamReader(FilePath + "saves.hup");

                using (reader)
                {
                    // Engine.Pesho.Abilities = reader.ReadLine().ToList();
                    if (reader.ReadLine() == "Mage")
                    {
                        Engine.Pesho = new Mage();
                        Engine.Pesho.Name = "Mage";
                        Engine.Pesho.Level = int.Parse(reader.ReadLine());
                        Engine.Pesho.Attack = int.Parse(reader.ReadLine());
                        Engine.Pesho.Energy = int.Parse(reader.ReadLine());
                        Engine.Pesho.Health = int.Parse(reader.ReadLine());
                        Engine.Pesho.Initiative = int.Parse(reader.ReadLine());
                        Engine.Pesho.Agility = int.Parse(reader.ReadLine());
                        Engine.Pesho.Intellect = int.Parse(reader.ReadLine());
                        Engine.Pesho.Strength = int.Parse(reader.ReadLine());
                    }
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
            Console.Write("Enter your nickname: ");
            Engine.Pesho.Name = Console.ReadLine();

            var score = int.MaxValue;

            try
            {
                var scores = File.ReadAllLines(FilePath + "scores.hup").ToList();
                int currnetScore = int.MaxValue;

                for (int i = 0; i < scores.Count; i++)
                {
                    currnetScore = int.Parse(scores[i].Split(' ')[1]);

                    if (currnetScore < score)
                    {
                        scores.Insert(i, Engine.Pesho.Name + " " + score);
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
    }
}