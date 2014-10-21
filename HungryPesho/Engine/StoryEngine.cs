using System;
using HungryPesho.UI;

namespace HungryPesho.Engine
{
    class StoryEngine
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
            DrawHelper.Color(@"         

                           __,='`````'=/__
                          '//  (o) \(o) \ `'         _,-,
                          //|     ,_)   (`\      ,-'`_,-\     <--- The real Pesho
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
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\\\/^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
",



                                           ConsoleColor.DarkGreen);

            DrawHelper.TextAtPosition(String.Format("It's a {0} {1} and you my friend are very, very hungry, no words can describe your hunger and thirst for food!" +
                                                    "\n  You can eat everything and everyone and I really doubt that you will be satisfied." +
                                                    "\n  YOU ARE HUNGRY and because of that you need to get up and start kicking some asses, not for money," +
                                                    "\n  nor for glory, just for fooood - the only thing which is in your head and not in your stomach obviously." +
                                                    "\n  But where to go what to do..?! Its up to you, but be carefull there is also realy hungry monsters out there waiting" +
                                                    "\n  for someone brave enough or just desperetly hungry." +
                                                    "\n\n  You stand up and look around. At east there is a deep lurky looking forst. Hey, maybe there is something to eat," +
                                                    "\n  a rabit would be nice, oh wait no, a dozen of rabits maybe or, or a BEAR?!? Arrrrrr, have you ever tried a bear meat??         \n  Well if you wanna go I wont stop you so just press 1 and hold your breath until I told you to stop." +
                                                    "\n  You can go North! There is a waterfall and maybe fish or a bear that that is stealing your fish.." +
                                                    "\n  So if you want to go there press 2 and only god knows what you will find there...",
                                                                                           conditions[random.Next(0, conditions.Length)],
                                                                                                                            dayTime[0]),
                                                                                  5,
                                                                                  30, ConsoleColor.DarkYellow);

            DrawHelper.TextAtPosition("1. To the Forest", 44, 44, ConsoleColor.White);
            DrawHelper.TextAtPosition("2. To the WaterFall", 44, 45, ConsoleColor.White);
            DrawHelper.TextAtPosition("3. Take a nap..", 44, 46, ConsoleColor.White);

            Action[] scenarios =
            { 
                Engine.StartEngine
                //Todo add find item scenario
                //Todo add loose hp scenario
                //Todo something else
            };

            var input = Console.ReadKey(true);

            if (input.Key.Equals(ConsoleKey.D1))
            {
                scenarios[(random.Next(0, scenarios.Length))]();
            }
            else if (input.Key.Equals(ConsoleKey.D2))
            {
                scenarios[(random.Next(0, scenarios.Length))]();
            }
            else if (input.Key.Equals(ConsoleKey.D3))
            {
                Engine.StartEngine();
            }
        }
    }
}
