namespace HungryPesho.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HungryPesho.UI;

    public struct StoryEngine
    {
        public static void Intro()
        {
            Console.Clear();
            var random = new Random();

            var dayTime = new[]
            {
                "day",
                "night"
            };

            var conditions = new[]
            {
                "rainy",
                "misty",
                "snowy",
                "hot",
                "cold",
                "pleasant",
                "hungry"
            };

            var scenes = new[]
            {
                "1. To the forest",
                "2. To the waterfall",
                "3. Take a nap"
            };

            Action[] scenarios =
            {
                Engine.StartEngine,
                Engine.StartEngine,
                Engine.StartEngine
            };

            const string RealPesho = @"

                           __,='`````'=/__
                          '//  (o) \(o) \ `'         _,-,                                   --''--          --''--
                          //|     ,_)   (`\      ,-'`_,-\     <--- The real Pesho                   --''--
                        ,-~~~\  `'==='  /-,      \==```` \__
                       /        `----'     `\     \       \/
                    ,-`                  ,   \  ,.-\       \                 ,\;`~\,;\;`\,            
                   /      ,    ♥ FOOD     \,-`\`_,-`\_,..--'\               /;|\_|,\~/`,\/;,
                  ,`    ,/,              ,>,   )     \--`````\             `\`/;`\,`;`|;\`\'
                  (      `\`---'`  `-,-'`_,<   \      \_,.--'`             ;|V`,;'|'/'`/'/|\
                   `.      `--. _,-'`_,-`  |    \                          /;'|`\V'/;\,\_V/
                    [`-.___   <`_,-'`------(    /                          `;|\, |;`,_|_,'
                    (`` _,-\   \ --`````````|--`                               `,`\_\/;'
                     >-`_,-`\,-` ,          |                                    \;`/     
                   <`_,'     ,  /\          |                                   \\| |  
                    `  \/\,-/ `/  \/`\_/V\_/                                   `\.| |  
                       (  ._. )    ( .__. )                             ---....__/  `\,____  
                       |      |    |      |                                 _,-'     `-   ...
                        \,---_|    |_---./
                        ooOO(_)    (_)OOoo                         

                 _(_)_                      
     @@@@       (_)@(_)  vVVVv    _     @@@@                           .--'|}         _   ,             
    @@()@@ wWWWw  (_)\   (___)  _(_)_  @@()@@                         /    /}}  -====;o`\/ }
     @@@@  (___)     `|/   Y   (_)@(_)  @@@@                        .=\.--'`\}        \-'\-'----.
      /      Y       \|   \|/   /(_)    \|                         //` '---./`         \ |-..-'`
   \ |     \ |/       | /\ | / \|/       |/                       ||  /|              /\/\             
     |///  \\|/// \\\\|//\\|///\|///  \\\|//                      \\ | |              `--`
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\\\/^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^";

            DrawHelper.Color(RealPesho, ConsoleColor.DarkGreen);

            const string IntroStory = "It's a {0} {1} and you my friend are very, very hungry, no words can describe your hunger and thirst for food!" +
                    "\n You can eat everything and everyone and I really doubt that you will be satisfied. YOU ARE HUNGRY! And because of that" +
                    "\n you need to get up and start kicking some asses, not for money, nor for glory, just for food - the only thing which is" +
                    "\n in your head and not in your stomach obviously. But where to go what to do? It's up to you, but be careful, there are" +
                    "\n also really hungry monsters out there, waiting for someone brave enough or just desperately hungry." +
                    "\n\n You stand up and look around. At East there is a deep murky looking forest. Hey, maybe there is something to eat," +
                    "\n a rabbit would be nice, oh wait no, a dozen of rabbits maybe or, or a BEAR?!? Arr, have you ever tried a bear meat??" +
                    "\n Well if you wanna go I won't stop you, so just press 1 and hold your breath until I told you to stop." +
                    "\n Or you can go North, there is a waterfall and maybe fish or a bear that is stealing your fish.." +
                    "\n So if you want to go there press 2 and only god knows what you will find there...";

            DrawHelper.TextAtPosition(string.Format(IntroStory, conditions[random.Next(0, conditions.Length)], dayTime[random.Next(0, dayTime.Length)]), 2, 30, ConsoleColor.DarkYellow);

            SetAndDisplayOptions(scenarios, scenes);
        }

        public static void StateAfterBattle()
        {
            Console.Clear();

            const string Dragon = @"  
                                     -==\\                         `//~\\   ~~~~`---.___.-~~
                                ______-==|                         | |  \\           _-~`
                          __--~~~  ,-/-==\\                        | |   `\        ,'
                        _-~       /'    |  \\                      / /      \      /
                      .'        /       |   \\                   /' /        \   /'
                     /  ____  /         |    \`\.__/-~~ ~ \ _ _/'  /          \/'
                    /-'~    ~~~~~---__  |     ~-/~         ( )   /'        _--~`
                                      \_|      /        _)   ;  ),   __--~~
                                       '~~--_/      _-~/-  / \   '-~ \
                                       {\__--_/}    / \\_>- )<__\      \
                                      /'   (_/  _-~  | |__>--<__|      |
                                     |0  0 _/) )-~     | |__>--<__|     |
                                     / /~ ,_/       / /__>---<__/      |
                                    o o _//        /-~_>---<__-~      /
                                    (^(~          /~_>---<__-      _-~
                                    ,/|           /__>--<__/     _-~
                                  ,//('(          |__>--<__|     /                  .----_
                                  ( ( '))          |__>--<__|    |                 /' _---_~\
                                 -)) )) (           |__>--<__|    |               /'  /     ~\`\
                                 ,/,'//( (             \__>--<__\    \            /'  //        ||
                                ,( ( ((, ))              ~-__>--<_~-_  ~--____---~' _/'/        /'
                              `~/  )` ) ,/|                 ~-_~>--<_/-__       __-~ _/
                              ._-~//( )/ )) `                    ~~-'_/_/ /~~~~~~~__--~
                               ;'( ')/ ,)(                              ~~~~~~~~~~

    ";

            const string StoryAfterBattle = "What a fight! I've never seen anyone fight like that before! Erm.. maybe a couple," +
                                            "\n               anyway this didn't satisfy your urge, am I wrong? Naah, I am never wrong, you are still" +
                                            "\n               hungry as fuck.. Hm lets see if that scary looking Dragon over there can do the trick," +
                                            "\n               but before that, is anything else you want to do right now?" +
                                            "\n               It's time to chose MR.Freeman.., I mean Pesho!";

            DrawHelper.TextAtPosition(Dragon, 25, 5, ConsoleColor.Cyan);
            DrawHelper.TextAtPosition(StoryAfterBattle, 15, 32, ConsoleColor.DarkYellow);

            Action[] scenarios = { Engine.StartEngine, Engine.StartEngine };

            var scenes = new[]
            {
                "1. Attack the scary Dragon.",
                "2. Go find something to eat.",
            };

            SetAndDisplayOptions(scenarios, scenes, 40, true);
        }

        private static void SetAndDisplayOptions(Action[] scenarios, IEnumerable<string> options, int startAtRow = 45, bool bossFight = false)
        {
            foreach (var option in options)
            {
                DrawHelper.TextAtPosition(option, 44, startAtRow++, ConsoleColor.White);
            }

            while (true)
            {
                var action = Console.ReadKey(true);
                var key = (int)action.Key - 49;

                if (key > scenarios.Length - 1 || key < 0)
                {
                    DrawHelper.TextAtPosition("Not hungry enough? IMPOSSIBLE!! Why don't you try with " + scenarios.Length + "?", 29, 43, ConsoleColor.DarkGray);
                }
                else
                {
                    if (key == 0 && bossFight)
                    {
                        Engine.BossFight = true;
                    }

                    scenarios[key]();
                    break;
                }
            }
        }
    }
}