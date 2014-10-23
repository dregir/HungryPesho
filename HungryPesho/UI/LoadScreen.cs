namespace HungryPesho.UI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using HungryPesho.Creatures;
    using HungryPesho.Engine;

    public static class LoadScreen
    {
        public static void LoadStartMenu() // Main menu
        {
            MediaPlayer.Play(Sound.Intro);

            Console.Clear();
            DrawHelper.DrawGameWindow();

            var menuChoices = new[]
            {
                "    START     ",
                "LOAD LAST GAME",
                " HOW TO PLAY  ",
                "   OPTIONS    ",
                "  HIGHSCORE   ",
                "   CREDITS    ",
                "    EXIT      "
            };

            var startMenuMethods = new List<Action>()
            {
                LoadCharacterSelection,
                GameSettings.LoadGame,
                LoadGameInfoScreen,
                LoadOptionsScreen,
                LoadScoreScreen,
                LoadCreditsScreen,
                ExitGame
            };

            DrawHelper.CreateMenu(menuChoices, startMenuMethods, 25);
        }

        public static void LoadIngameMenu() // In game menu
        {
            MediaPlayer.Play(Sound.Intro);

            Console.Clear();
            DrawHelper.DrawGameWindow();

            var menuChoices = new[]
            {
                "  CONTINUE  ",
                "    SAVE    ",
                "    LOAD    ",
                "  OPTIONS   ",
                " HOW TO PLAY",
                "    EXIT    "
            };

            var startMenuMethods = new List<Action>()
            {
                Engine.StartEngine,
                GameSettings.SaveGame,
                GameSettings.LoadGame,
                LoadOptionsScreen,
                LoadGameInfoScreen,
                ExitGame
            };

            DrawHelper.CreateMenu(menuChoices, startMenuMethods, 25);
        }

        public static void LoadCharacterSelection() // Load character selection
        {
            const string selectClass = @"
                       ____    __        __                             __           
                      / __/__ / /__ ____/ /_  __ _____  __ ______  ____/ /__ ____ ___
                     _\ \/ -_) / -_) __/ __/ / // / _ \/ // / __/ / __/ / _ `(_-<(_-<
                    /___/\__/_/\__/\__/\__/  \_, /\___/\_,_/_/    \__/_/\_,_/___/___/
                                           /____/                                        
";

            DrawHelper.Color(selectClass, ConsoleColor.Green);

            DrawHelper.TextAtPosition("Warrior", 18, 38, ConsoleColor.White, ConsoleColor.DarkRed);
            DrawHelper.TextAtPosition("Mage", 77, 38, ConsoleColor.White);

            var selection = 0;

            Action<int> switchClass = (pos) =>
            {
                ConsoleColor warColor;
                ConsoleColor mageColor;

                if (pos == 0)
                {
                    warColor = ConsoleColor.White;
                    mageColor = ConsoleColor.DarkGray;
                }
                else
                {
                    warColor = ConsoleColor.DarkGray;
                    mageColor = ConsoleColor.White;
                }

                const string mage = @"
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
                                                                _ .-'    /     Bb     '-. '-._
                                                             .-'       |      BBb       '-.  '-.
                                                            (________mrf\____.dBBBb.________)____)";

                DrawHelper.TextAtPosition(mage, 0, 10, mageColor);

                const string warrior = @"
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
              /  .-'   \\. \\
              `-'       \\`-'    
                         \|";

                DrawHelper.TextAtPosition(warrior, 0, 10, warColor);
            };

            switchClass(selection);

            DrawHelper.TextAtPosition("Warriors are melee fighters highly trained in the art of weaponry.", 15, 43, ConsoleColor.Red);

            DrawHelper.TextAtPosition("\"For as long as war has raged, heroes from every race have aimed to master the art of battle.  " +
                           "\n      Warriors combine strength, leadership, and a vast knowledge of arms and armor to wreak havoc" +
                           "\n      in glorious combat.\"", 5, 45, ConsoleColor.DarkRed);

            while (true)
            {
                var input = Console.ReadKey(true);

                if (input.Key.Equals(ConsoleKey.LeftArrow) || input.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (selection == 0)
                    {
                        DrawHelper.TextAtPosition("Warrior", 18, 38, ConsoleColor.White);
                        DrawHelper.TextAtPosition("Mage", 77, 38, ConsoleColor.White, ConsoleColor.Blue);
                        DrawHelper.TextAtPosition("Mages are ranged class specializing in casting powerful spells.   ",
                            15,
                            43,
                            ConsoleColor.Cyan);
                        DrawHelper.TextAtPosition(
                            "\"Students gifted with a keen intellect and unwavering discipline may walk the path of the Mage." +
                            "\n      The arcane magic available to magi is both great and dangerous, and thus is revealed only to the" +
                            "\n      most devoted practitioners.\"",
                            5,
                            45,
                            ConsoleColor.DarkCyan);
                        selection++;
                    }
                    else
                    {
                        DrawHelper.TextAtPosition("Warrior", 18, 38, ConsoleColor.White, ConsoleColor.DarkRed);
                        DrawHelper.TextAtPosition("Mage", 77, 38, ConsoleColor.White);
                        DrawHelper.TextAtPosition("Warriors are melee fighters highly trained in the art of weaponry.", 15, 43, ConsoleColor.Red);
                        DrawHelper.TextAtPosition(
                            "\"For as long as war has raged, heroes from every race have aimed to master the art of battle.  " +
                            "\n      Warriors combine strength, leadership, and a vast knowledge of arms and armor to wreak havoc    " +
                            "\n      in glorious combat.\"          ", 5, 45, ConsoleColor.DarkRed);
                        selection--;
                    }

                    switchClass(selection);
                    continue;
                }

                if (input.Key.Equals(ConsoleKey.Enter))
                {
                    MediaPlayer.Play(Sound.Enter);

                    if (selection == 1)
                    {
                        Player.Pesho = Player.SetClass(new Mage());
                    }
                    else
                    {
                        Player.Pesho = Player.SetClass(new Warrior());
                    }

                    StoryEngine.Intro();
                }

                if (input.Key.Equals(ConsoleKey.Escape))
                {
                    LoadScreen.LoadStartMenu();
                }
            }
        }

        public static void LoadGameInfoScreen() // How to play screen
        {

            const string HowToPlay = @"
            “Hungry Pesho” is a turn based game, where your character (Pesho)
            can choose to be either powerful mage or a strong warrior.

            As the game title says, Pesho is hungry and you must help him to find some food,
            by fighting evil creatures. You can choose from several different zones,
            where you can fight different creatures to get your food.

            After every defeated opponent your character have a chance to get a weapon or an armor,
            to increase his stats and chance for survival.";

            DrawHelper.TextAtPosition(HowToPlay, 5, 5, ConsoleColor.Cyan);

            DrawHelper.TextAtPosition("Press Esc to go back", GameSettings.GameWidth / 2, GameSettings.GameHeight / 2, ConsoleColor.Yellow);
        }

        public static void LoadOptionsScreen() // Game options
        {
            DrawHelper.TextAtPosition("Sound", (GameSettings.GameWidth / 3) - 2, 8, ConsoleColor.Green);

            var optionsChoices = new[]
            {
                "ON",
                "OFF",
            };

            var optionsMethods = new List<Action>()
            {
                GameSettings.TurnSoundOn,
                GameSettings.TurnSoundOff,
            };

            DrawHelper.CreateMenu(optionsChoices, optionsMethods, 7);
        }

        public static void LoadCreditsScreen() // Game credits Screen
        {
            MediaPlayer.Play(Sound.Credits);

            Console.Clear();
            Console.Title = "Hungry Pesho!  -=-  Game Credits";

            Console.Write(@"
                                ____  
               ________         L|eam          __.                              
               \______ \_______   ____   ____ |__|______ 
                |    |  \_  __ \_/ __ \ / ___\|  \_  __ \
                |    `   \  | \/\  ___// /_/  >  ||  | \/
               /_______  /__|    \___  >___  /|__||__|   
                       \/            \/_____/       



                            Pavlin Kostadinov
                            Adrian Bozhankov
                            Nina Markova
                            Mihail Dimitrov
                            Valyu Valev
                            Karim Hristov


                            Don't stay hungry!

                            Go to eat...
                                           Good luck!");

            DrawHelper.TextAtPosition("Press Esc to go back", GameSettings.GameWidth / 2, GameSettings.GameHeight / 2, ConsoleColor.Yellow);
        }

        public static void LoadLooseScreen() // Gave Over screen
        {
            MediaPlayer.Play(Sound.Lose);

            Console.Clear();
            Console.Title = "Hugry pesho!  -=-  You LOOSE!";

            const string GameOver = @"


                          ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███ 
                         ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
                        ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
                        ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
                        ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
                         ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
                          ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
                        ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
                              ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░  
                                                           ,-.
                                      ___,---.__          /'|`\          __,---,___
                                   ,-'    \`    `-.____,-'  |  `-.____,-'    //    `-.
                                 ,'        |           ~'\     /`~           |        `.
                                /      ___//              `. ,'          ,  , \___      \
                               |    ,-'   `-.__   _         |        ,    __,-'   `-.    |
                               |   /          /\_  `   .    |    ,      _/\          \   |
                               \  |           \ \`-.___ \   |   / ___,-'/ /           |  /
                                \  \           | `._   `\\  |  //'   _,' |           /  /
                                 `-.\         /'  _ `---'' , . ``---' _  `\         /,-'
                                             /     \    ,='/ \`=.    /     \       ''
                                            |__   /|\_,--.,-.--,--._/|\   __|
                                            /  `./  \\`\ |  |  | /,//' \,'  \
                                           /   /     ||--+--|--+-/-|     \   \
                                          |   |     /'\_\_\ | /_/_/`\     |   |
                                           \   \__, \_     `~'     _/ .__/   /
                                            `-._,-'   `-._______,-'   `-._,-'

";

            DrawHelper.TextAtPosition(GameOver, 50, 0, ConsoleColor.DarkRed);
        }

        public static void LoadWinScreen() // Win Game screen
        {
            MediaPlayer.Play(Sound.Win);

            Console.Clear();
            Console.Title = "Hungry Pesho!  -=-  You WIN!";

            Console.WriteLine(@"YOU WIN

             ╔╗╔╗╔╗╔╗
             ║╚╝╚╝║╠╣╔═╦╗
             ╚╗╔╗╔╝║║║║║║
              ╚╝╚╝ ╚╝╚╩═╝
            ");
        }

        public static void LoadScoreScreen() // Show current high score
        {
            MediaPlayer.Play(Sound.Ranklist);

            Console.Clear();
            Console.Title = "Hungry Pesho!  -=-  High Scores";

            try
            {
                using (var reader = new StreamReader(GameSettings.FilePath + "scores.hup"))
                {
                    string line;
                    int row = 3;

                    while ((line = reader.ReadLine()) != null)
                    {
                        DrawHelper.TextAtPosition(line + " Level", GameSettings.GameWidth / 3, row += 2, ConsoleColor.Yellow);
                    }
                }
            }
            catch (Exception)
            {
                DrawHelper.TextAtPosition("LOADING HIGH SCORES FILED!", GameSettings.GameWidth / 2, GameSettings.GameHeight / 2, ConsoleColor.Red);
                Thread.Sleep(1000);

                LoadScreen.LoadStartMenu();
            }

            DrawHelper.TextAtPosition("Press Esc to go back", GameSettings.GameWidth / 2, GameSettings.GameHeight / 2, ConsoleColor.Yellow);
        }

        public static void ExitGame() // Exit game
        {
            Environment.Exit(0);
        }
    }
}