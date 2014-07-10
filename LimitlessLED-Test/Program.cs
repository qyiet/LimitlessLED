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
                switch (args[0].ToLower()) // case insensitive
                {
                    case       "alloff": { UserCommands.AllOff(); return; }

                    case        "allon": { UserCommands.AllOn(); return; }

                    case     "brighten": { UserCommands.Brighten(); return; }

                    case          "dim": { UserCommands.Dim(); return; }

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
                    { 
                        if(args.Length>1) UserCommands.Flash(args[1]);
                        else UserCommands.Flash("3");
                        return; 
                    }

                    case       "strobe":
                    case        "blink": { UserCommands.StrobeMode(); return; }

                    case       "fadeup": { UserCommands.FadeUp(); return; }
                    case     "fadedown": { UserCommands.FadeDown(); return; }

                    case       "allmax": { UserCommands.AllMax(); return; }
                    case       "allmin": { UserCommands.AllMin(); return; }

                    case    "wakeupcall": 
                    {
                        if (args.Length > 2) UserCommands.WakeUpCall(args[1] + args[2]);
                        else if (args.Length > 1) UserCommands.WakeUpCall(args[1]);
                        else UserCommands.WakeUpCall("");
                        return; 
                    }
                    case       "tempmax": { UserCommands.TempMax(); return; }

                    case        "rgbon": { UserCommands.RGBOn(); return; }
                    case       "rgboff": { UserCommands.RGBOff(); return; }

                    default: { Console.WriteLine("I have no idea what you wanted me to do"); return; } // Tell the user we have no idea WTF they wanted
                }
            }
            Console.WriteLine("There are input arguments required.  Some are explained below:");
            Console.WriteLine("allon: turn everything on (with the last settings).");
            Console.WriteLine("alloff: turn everything off (with the last settings).");
            Console.WriteLine("brighten: Increase the brightness one step (for the last group).");
            Console.WriteLine("dim: Decrease the brightness one step (for the last group).");
            Console.WriteLine("fadedown: Slow fade group one to minimum.");
            Console.WriteLine("fadeup: Slow fade group one to maximum.");
            Console.WriteLine("--------Fun stuff:--------");
            Console.WriteLine("wakeupcall: Turns on all lights to minimum brightness, then slowly increases the brightness over 10 min");
            Console.WriteLine("blink: blinks the lights really fast.");
            Console.WriteLine("flash n: causes the lights to flash 3 times.");
        }
    }
}
