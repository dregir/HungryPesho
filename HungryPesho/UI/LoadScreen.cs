namespace HungryPesho.UI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Media;
    using System.Threading;
    using HungryPesho.Creatures;
    using HungryPesho.Engine;

    public static class LoadScreen
    {
        public static void LoadStartMenu() // Main menu
        {
            MediaPlayer.Play(Sound.INTRO);

            Console.Clear();
            DrawHelper.DrawGameWindow();

            var menuChoices = new[]
            {
                "   START   ",
                "HOW TO PLAY",
                "  OPTIONS  ",
                " RANKLIST  ",
                "  CREDITS  ",
                "   EXIT    "
            };

            var startMenuMethods = new List<Action>()
            {
                LoadCharacterSelection,
                LoadGameInfoScreen,
                LoadOptionsScreen,
                LoadRankListScreen,
                LoadCreditsScreen,
                ExitGame
            };

            DrawHelper.CreateMenu(menuChoices, startMenuMethods, 25);
        }

        public static void LoadIngameMenu() // Ingame menu
        {
            MediaPlayer.Play(Sound.INTRO);

            Console.Clear();
            DrawHelper.DrawGameWindow();

            var menuChoices = new[]
            {
                " CONTINUE  ",
                "   SAVE    ",
                "   LOAD    ",
                "  OPTIONS  ",
                "HOW TO PLAY",
                "   EXIT    "
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
            DrawHelper.Color(@"
                    ____    __        __                             __           
                   / __/__ / /__ ____/ /_  __ _____  __ ______  ____/ /__ ____ ___
                  _\ \/ -_) / -_) __/ __/ / // / _ \/ // / __/ / __/ / _ `(_-<(_-<
                 /___/\__/_/\__/\__/\__/  \_, /\___/\_,_/_/    \__/_/\_,_/___/___/
                                         /___/                                    
            ", ConsoleColor.Blue);

            DrawHelper.TextAtPosition("Warrior", 15, 38, ConsoleColor.White, ConsoleColor.DarkRed);
            DrawHelper.TextAtPosition("Mage", 70, 38, ConsoleColor.White);

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

                DrawHelper.TextAtPosition(@"
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
                                                     (________mrf\____.dBBBb.________)____)", 0, 10, mageColor);



                DrawHelper.TextAtPosition
                (@"
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
                       \|"
                    , 0, 10, warColor);
            };

            switchClass(selection);

            while (true)
            {
                var input = Console.ReadKey(true);

                if (input.Key.Equals(ConsoleKey.LeftArrow) || input.Key.Equals(ConsoleKey.RightArrow))
                {
                    MediaPlayer.Play(Sound.CLICK);

                    if (selection == 0)
                    {
                        DrawHelper.TextAtPosition("Warrior", 15, 38, ConsoleColor.White);
                        DrawHelper.TextAtPosition("Mage", 70, 38, ConsoleColor.White, ConsoleColor.Blue);
                        selection++;
                    }
                    else
                    {
                        DrawHelper.TextAtPosition("Warrior", 15, 38, ConsoleColor.White, ConsoleColor.DarkRed);
                        DrawHelper.TextAtPosition("Mage", 70, 38, ConsoleColor.White);
                        selection--;
                    }

                    switchClass(selection);
                    continue;
                }

                if (input.Key.Equals(ConsoleKey.Enter))
                {
                    MediaPlayer.Play(Sound.ENTER);

                    if (selection == 1)
                    {
                        Engine.Pesho = new Mage();
                    }
                    else
                    {
                        Engine.Pesho = new Warrior();
                    }

                    Engine.StartEngine();
                }

                if (input.Key.Equals(ConsoleKey.Escape))
                {
                    LoadScreen.LoadStartMenu();
                }
            }
        }

        public static void LoadGameInfoScreen() // TODO: How to play screen
        {
            Console.WriteLine("How to play goes here");

            DrawHelper.TextAtPosition("Press Esc to go back", GameSettings.GameWidth / 2, GameSettings.GameHeight / 2, ConsoleColor.Yellow);
        }

        public static void LoadOptionsScreen() // TODO: Game options
        {
            Console.WriteLine("Music OFF");

            DrawHelper.TextAtPosition("Press Esc to go back", GameSettings.GameWidth / 2, GameSettings.GameHeight / 2, ConsoleColor.Yellow);
        }

        public static void LoadCreditsScreen() // Game credits Screen
        {
            MediaPlayer.Play(Sound.CREDITS);

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


                            In Hungry Pesho!

                            Game intro...
                                           Good luck!");

            DrawHelper.TextAtPosition("Press Esc to go back", GameSettings.GameWidth / 2, GameSettings.GameHeight / 2, ConsoleColor.Yellow);
        }

        public static void LoadLooseScreen() // Gave Over screen
        {
            MediaPlayer.Play(Sound.LOSE);

            Console.Clear();
            Console.Title = "Hugry pesho!  -=-  You LOOSE!";

            Console.WriteLine(@"GAME OVER

             _                   _
            ( )                 ( )_
           (_, |      __ __      | _)
             \'\    /  ^  \    /'/
              '\'\,/\      \,/'/'
                '\| []   [] |/'
                  (_  /^\  _)
                    \  ~  /
                    /HHHHH\
                  /'/{^^^}\'\
              _,/'/'  ^^^  '\'\,_
             (_, |           | ,_)
               (_)           (_)
            ");
        }

        public static void LoadWinScreen() // Win Game screen
        {
            MediaPlayer.Play(Sound.WIN);

            Console.Clear();
            Console.Title = "Hungry Pesho!  -=-  You WIN!";

            Console.WriteLine(@"YOU WIN

             ╔╗╔╗╔╗╔╗
             ║╚╝╚╝║╠╣╔═╦╗
             ╚╗╔╗╔╝║║║║║║
              ╚╝╚╝ ╚╝╚╩═╝
            ");
        }

        public static void LoadRankListScreen() // Show current high score
        {
            MediaPlayer.Play(Sound.RANKLIST);

            Console.Clear();
            Console.Title = "Hungry Pesho!  -=-  Ranklist";

            try
            {
                StreamReader reader = new StreamReader(GameSettings.FilePath + "scores.hup");

                using (reader)
                {
                    
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