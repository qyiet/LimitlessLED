using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
            //Process Command Line Arguments
            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case        "flash":
                    case       "strobe":
                    case        "blink": { UserCommands.StrobeMode(); return; }
                                    
                    case     "fadeDown":
                    case     "fadedown":
                    case          "dim": { UserCommands.FadeDown(); return; }

                    case       "fadeUp":
                    case       "fadeup":
                    case     "brighten": { UserCommands.FadeUp(); return; }

                    case       "allOff":
                    case       "alloff": { UserCommands.AllOff(); return; }

                    case        "allOn":
                    case        "allon": { UserCommands.AllOn(); return; }

                    case "allNightMode":
                    case "allnightmode": { UserCommands.AllNightMode(); return; }

                    case         "test": { UserCommands.Test(); return; } //for testing experimental code

                    default:
                        {   //Tell the user we have no idea WTF they wanted
                            Console.WriteLine("I have no idea what you wanted me to do");
                            return;
                        }
                }
            }
            else
            {
            Console.WriteLine("There are input arguments required.  I really should put something here to explain them for you");
            }
        }
    }
}
