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
                String arg = args[0].ToLower();
                switch (arg)
                {
                    case     "alloff":     { UserCommands.AllOff(); break; }

                    case     "allon":      { UserCommands.AllOn(); break; }

                    case     "allwhite":   { UserCommands.AllWhite(); break; }

                    case     "brighten":   { UserCommands.Brighten(); break; }

                    case     "dim":        { UserCommands.Dim(); break; }

                    case     "group1off":  { UserCommands.Group1Off(); break; }
                    case     "group2off":  { UserCommands.Group2Off(); break; }
                    case     "group3off":  { UserCommands.Group3Off(); break; }
                    case     "group4off":  { UserCommands.Group4Off(); break; }

                    case     "group1on":  { UserCommands.Group1On(); break; }
                    case     "group2on":  { UserCommands.Group2On(); break; }
                    case     "group3on":  { UserCommands.Group3On(); break; }
                    case     "group4on":  { UserCommands.Group4On(); break; }

                    case     "test":       { UserCommands.Test(); break; } // for testing experimental code

                    case     "flash":
                    case     "strobe":
                    case     "blink":      { UserCommands.StrobeMode(); break; }

                    case     "fadeup":     { UserCommands.FadeUp(); break; }

                    case     "fadedown":   { UserCommands.FadeDown(); break; }

                    case     "wakeupcall": { UserCommands.WakeUpCall(); break; }

                    case     "rgb":        { if(args.Length>1)UserCommands.RGBColour(Convert.ToInt32(args[1])); break; }

                    case     "disco":      { UserCommands.Disco(); break; }

                    case     "discofast":  { UserCommands.DiscoSpeedUp(); break; }

                    case     "discoslow":  { UserCommands.DiscoSpeedDown(); break; }

                    case     "changeip":   { if(args.Length>1)Properties.Settings.Default.IP = args[1]; break; }

                    case "--help": { Console.WriteLine("AllOff\t\tTurn off all lights\nAllOn\t\tTurn on all lights\nAllWhite\tTurn all lights to white\nBrighten\tTurn up brightness 1 step\nDim\t\tTurn down brightness 1 step\nGroup#Off\tTurn off group # lights\nGroup#On\tTurn on group # lights\nStrobe\t\tStrobe lights\nFadeUp\t\tFade lights up to full brightness\nFadeDown\t\tFade lights down to minimum brightness\nRGB ###\t\tSet light color to ### (between 0 and 255)\nDisco\t\tChange lights to next disco mode\nDiscoFast\tMake lights disco faster\nDiscoSlow\tMake lights disco slower\nChangeIP #\tChange bridge IP to #"); break; }

                    default: { Console.WriteLine("Type --help for options."); break; }
                }
            }
            else
            {
                Console.WriteLine("Type --help for options.");
            }

            Properties.Settings.Default.Save();

            return;
        }
    }
}
