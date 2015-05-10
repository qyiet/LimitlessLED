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
            if (Properties.Settings.Default.IP == "")
            {
                Console.WriteLine("Please input the IP of your wireless bridge device");
                Properties.Settings.Default.IP = Console.ReadLine();
            }

            // Process Command Line Arguments
            if (args.Length != 0)
            {
<<<<<<< HEAD
                switch (args[0].ToLower()) // case insensitive
=======
<<<<<<< HEAD
                String arg = args[0].ToLower();
                switch (arg)
                {
                    case     "alloff":     { UserCommands.AllOff(); break; }

                    case     "allon":      { UserCommands.AllOn(); break; }

                    case     "allwhite":   { UserCommands.AllWhite(); break; }

                    case     "brighten":   { UserCommands.Brighten(); break; }

                    case     "dim":        { UserCommands.Dim(); break; }

				switch (args[0].ToLower()) // case insensitive
>>>>>>> pr/4
                {
                    case       "alloff": { UserCommands.AllOff(); return; }

                    case        "allon": { UserCommands.AllOn(); return; }

                    case     "group1off":  { UserCommands.Group1Off(); break; }
                    case     "group2off":  { UserCommands.Group2Off(); break; }
                    case     "group3off":  { UserCommands.Group3Off(); break; }
                    case     "group4off":  { UserCommands.Group4Off(); break; }

                    case     "group1on":  { UserCommands.Group1On(); break; }
                    case     "group2on":  { UserCommands.Group2On(); break; }
                    case     "group3on":  { UserCommands.Group3On(); break; }
                    case     "group4on":  { UserCommands.Group4On(); break; }

<<<<<<< HEAD
=======
                    case     "test":       { UserCommands.Test(); break; } // for testing experimental code
>>>>>>> pr/4
                    case "allnightmode": { UserCommands.AllNightMode(); return; }

                    case     "flash":
                    case     "strobe":
                    case     "blink":      { UserCommands.StrobeMode(); break; }

                    case     "fadeup":     { UserCommands.FadeUp(); break; }

                    case     "fadedown":   { UserCommands.FadeDown(); break; }

                    case     "rgb":        { if(args.Length>1)UserCommands.RGBColour(Convert.ToInt32(args[1])); break; }

                    case     "disco":      { UserCommands.Disco(); break; }

                    case     "discofast":  { UserCommands.DiscoSpeedUp(); break; }

                    case        "flash": 
                    { 
                        if(args.Length>1) UserCommands.Flash(args[1]);
                        else UserCommands.Flash("3");
                        return; 
                    }

<<<<<<< HEAD
                    case        "flash": 
                    { 
                        if(args.Length>1) UserCommands.Flash(args[1]);
                        else UserCommands.Flash("3");
                        return; 
                    }

=======
>>>>>>> pr/4
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
<<<<<<< HEAD
=======

                    case     "discoslow":  { UserCommands.DiscoSpeedDown(); break; }

                    case     "changeip":   { if(args.Length>1)Properties.Settings.Default.IP = args[1]; break; }

                    case "--help": { Console.WriteLine("AllOff\t\tTurn off all lights\nAllOn\t\tTurn on all lights\nAllWhite\tTurn all lights to white\nBrighten\tTurn up brightness 1 step\nDim\t\tTurn down brightness 1 step\nGroup#Off\tTurn off group # lights\nGroup#On\tTurn on group # lights\nStrobe\t\tStrobe lights\nFadeUp\t\tFade lights up to full brightness\nFadeDown\t\tFade lights down to minimum brightness\nRGB ###\t\tSet light color to ### (between 0 and 255)\nDisco\t\tChange lights to next disco mode\nDiscoFast\tMake lights disco faster\nDiscoSlow\tMake lights disco slower\nChangeIP #\tChange bridge IP to #"); break; }
>>>>>>> pr/4

            //Console.WriteLine("There are input arguments required.  Some are explained below:");
            //Console.WriteLine("allon: turn everything on (with the last settings).");
            //Console.WriteLine("alloff: turn everything off (with the last settings).");
            //Console.WriteLine("brighten: Increase the brightness one step (for the last group).");
            //Console.WriteLine("dim: Decrease the brightness one step (for the last group).");
            //Console.WriteLine("fadedown: Slow fade group one to minimum.");
            //Console.WriteLine("fadeup: Slow fade group one to maximum.");
            //Console.WriteLine("--------Fun stuff:--------");
            //Console.WriteLine("wakeupcall: Turns on all lights to minimum brightness, then slowly increases the brightness over 10 min");
            //Console.WriteLine("blink: blinks the lights really fast.");
            //Console.WriteLine("flash n: causes the lights to flash 3 times.");

                    default: { Console.WriteLine("Type --help for options."); break; }
                }
            }
<<<<<<< HEAD
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
=======

            else
            {
                Console.WriteLine("Type --help for options.");
            }

            Properties.Settings.Default.Save();

            return;

>>>>>>> pr/4
        }
    }
}
