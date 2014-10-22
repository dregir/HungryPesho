namespace HungryPesho.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HungryPesho.UI;

    public class StoryEngine
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
                "plesent",
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
                Engine.StartEngine
                // TODO: add find item scenario
                // TODO: add loose hp scenario
                // TODO: something else
            };

            string realPesho = @"

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

            DrawHelper.Color(realPesho, ConsoleColor.DarkGreen);

            string introStory = 
                    "It's a {0} {1} and you my friend are very, very hungry, no words can describe your hunger and thirst for food!" +
                    "\n  You can eat everything and everyone and I really doubt that you will be satisfied." +
                    "\n  YOU ARE HUNGRY and because of that you need to get up and start kicking some asses, not for money," +
                    "\n  nor for glory, just for fooood - the only thing which is in your head and not in your stomach obviously." +
                    "\n  But where to go what to do..?! Its up to you, but be careful there is also really hungry monsters out there," +
                    "\n  waiting for someone brave enough or just desperately hungry." +
                    "\n\n You stand up and look around. At east there is a deep lurky looking forest. Hey, maybe there is something to eat," +
                    "\n  a rabbit would be nice, oh wait no, a dozen of rabbits maybe or, or a BEAR?!? Arrrrrr, have you ever tried a bear meat??" +
                    "\n  Well if you wanna go I wont stop you so just press 1 and hold your breath until I told you to stop." +
                    "\n  Or you can go North, there is a waterfall and maybe fish or a bear that is stealing your fish.." +
                    "\n  So if you want to go there press 2 and only god knows what you will find there...";

            DrawHelper.TextAtPosition(string.Format(introStory, conditions[random.Next(0, conditions.Length)], dayTime[random.Next(0, dayTime.Length)]), 5, 30, ConsoleColor.DarkYellow);

            SetAndDisplayOptions(scenarios, scenes);
        }

        public static void StateAfterBattle()
        {
            Console.Clear();

            string storyAfterBattle = "What a fight! I've never seen anyone fight like that before! Erm.. maybe a couple," +
                              "\n               anyway this didn't satisfy your urge, am I wrong? Naah, I am never wrong, you are still" +
                              "\n               hungry as fuck.. Hm lets see if that scary looking monster over there can do the trick," +
                              "\n               but before that, is anything else you want to do right now?" +
                              "\n               It's time to chose MR.Freeman.., I mean Pesho!";

            DrawHelper.TextAtPosition(storyAfterBattle, 15, 30, ConsoleColor.DarkYellow);

            Action[] scenarios = { Engine.StartEngine, Engine.StartEngine };

            var scenes = new[]
            {
                "1. Use item from inventory",
                "2. Attack the scary monster",
            };

            SetAndDisplayOptions(scenarios, scenes, 40);
        }

        private static void SetAndDisplayOptions(IList<Action> scenarios, IEnumerable<string> options, int startAtRow = 45)
        {
            foreach (var option in options)
            {
                DrawHelper.TextAtPosition(option, 44, startAtRow++, ConsoleColor.White);
            }

            while (true)
            {
                var action = Console.ReadKey(true);
                var key = (int)action.Key - 49;

                if (key > scenarios.Count - 1 || key < 0)
                {
                    DrawHelper.TextAtPosition("Not hungry enough? IMPOSSIBLE!! Why don't you try with " + scenarios.Count + " ?", 29, 43, ConsoleColor.DarkGray);
                }
                else
                {
                    scenarios[key]();
                    break;
                }
            }
        }
    }
}