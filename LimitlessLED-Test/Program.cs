using System;

namespace LimitlessLED_Test
{
    class Program
    {
        /// <summary>
        /// This is control code for the LimitlessLED light bulbs.  It's currently pretty much under first draft testing.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Process Command Line Arguments
            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case       "allOff":
                    case       "alloff": { UserCommands.AllOff(); return; }

                    case        "allOn":
                    case        "allon": { UserCommands.AllOn(); return; }

                    case     "brighten": { UserCommands.Brighten(); return; }

                    case          "dim": { UserCommands.Dim(); return; }

                    case "allNightMode":
                    case "allnightmode": { UserCommands.AllNightMode(); return; }

                    case    "group1off": { UserCommands.Group1Off(); return; }
                    case    "group2off": { UserCommands.Group2Off(); return; }
                    case    "group3off": { UserCommands.Group3Off(); return; }
                    case    "group4off": { UserCommands.Group4Off(); return; }

                    case  "group1night": { UserCommands.Group1NightMode(); return; }
                    case  "group2night": { UserCommands.Group2NightMode(); return; }
                    case  "group3night": { UserCommands.Group3NightMode(); return; }
                    case  "group4night": { UserCommands.Group4NightMode(); return; }

                    case         "test": { UserCommands.Test(); return; } // for testing experimental code

                    case        "flash":
                    case       "strobe":
                    case        "blink": { UserCommands.StrobeMode(); return; }

                    case       "fadeUp":
                    case       "fadeup": { UserCommands.FadeUp(); return; }

                    case     "fadeDown":
                    case     "fadedown": { UserCommands.FadeDown(); return; }

                    case   "wakeupcall": { UserCommands.WakeUpCall(); return; }

                    case        "rgbon": { UserCommands.RGBOn(); return; }
                    case       "rgboff": { UserCommands.RGBOff(); return; }

                    default: { Console.WriteLine("I have no idea what you wanted me to do"); return; } // Tell the user we have no idea WTF they wanted
                }
            }         
            Console.WriteLine("There are input arguments required.  I really should put something here to explain them for you");
        }
    }
}
