using System;
using System.Configuration;
using System.Net.Sockets;
using System.Threading;

namespace LimitlessLED_Test
{
    class UserCommands
    {
        // Connect to bridge
        static readonly string BridgeIpAddress = ConfigurationManager.AppSettings["ip"];
        static readonly UdpClient UdpClient = new UdpClient(BridgeIpAddress, 8899);

        /// <summary>
        /// Shortcut to send UDP commands to the wifi bridge
        /// </summary>
        static void LedBridge(byte[] hexCommand)
        {
            UdpClient.Send(hexCommand, 3);
        }

        /// <summary>
        /// Used for testing individual commands
        /// Will be removed when debugging is complete
        /// </summary>
        public static void Test()
        {
            AllOff();
            Thread.Sleep(100);
            //RGBOff();

            WakeUpCall("");
        }

        /// <summary>
        /// Strobe mode:  
        /// Flash the lights till a key is pressed 
        /// </summary>
        public static void StrobeMode()
        {
            Console.WriteLine("Starting Strobe mode, press any key to stop");
            while (!Console.KeyAvailable)
            {
                LedBridge(BridgeCommands.Group1Off);
                Thread.Sleep(100);
                LedBridge(BridgeCommands.Group1On);
                Thread.Sleep(100);
            }
        }

        public static void Flash(string times)
        {
            Console.WriteLine("Flashy Flashy!");
            for (int i = 0; i < int.Parse(times); i++)
            {
                LedBridge(BridgeCommands.AllOff);
                Thread.Sleep(400);
                LedBridge(BridgeCommands.AllOn);
                Thread.Sleep(400);
            }
        }

        /// <summary>
        /// Turn all lights to the maximum brightness
        /// </summary>
        public static void AllMax()
        {
            AllOn();
            RGBOn();
            for (int i = 0; i < 13; i++) //13 just in case the bulbs miss a couple commands.
            {
                Brighten();
                RGBBrighten();
                Thread.Sleep(101);
            }
        }

        /// <summary>
        /// Turn all lights to the minimum brightness
        /// </summary>
        public static void AllMin()
        {
            AllOn();
            RGBOn();
            for (int i = 0; i < 13; i++) //13 just in case the bulbs miss a couple commands.
            {
                Dim();
                RGBDim();
                Thread.Sleep(101);
            }
        }

        public static void TempMax()
        {
            Console.WriteLine("Yellowest light you ever seen, coming right up!");
            for (int i = 0; i < 10; i++)
            {
                LedBridge(BridgeCommands.ColorTempUp);
                Thread.Sleep(30);
            }
        }

        /// <summary>
        /// Slow fade group one to minimum
        /// this will probably be renamed later due to potential naming conflict
        /// </summary>
        public static void FadeDown()
        {
            Console.WriteLine("Dimming Group One");

            // Ensure group one is on, and selected by the wifi bridge
            LedBridge(BridgeCommands.Group1On);
            Thread.Sleep(150);

            // Fade selected group down 10 steps  
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("This is dimming level " + i);
                LedBridge(BridgeCommands.BrightnessDown);
                Thread.Sleep(1000);
            } 
        }

        /// <summary>
        /// Slow fade group one to maximum
        /// this will probably be renamed later due to potential naming conflict
        /// </summary>
        public static void FadeUp()
        {
             Console.WriteLine("Brightening Group One");
            
            // Ensure group one is on, and selected by the wifi bridge
            LedBridge(BridgeCommands.Group1On);
            Thread.Sleep(150);
       
            // Fade selected group up 10 steps  
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("This is dimming level " + (10 - i));
                LedBridge(BridgeCommands.BrightnessUp);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Turn all white lights off
        /// </summary>
        public static void AllOff()
        {
            LedBridge(BridgeCommands.AllOff);
        }

        /// <summary>
        /// Turn all white lights on
        /// </summary>
        public static void AllOn()
        {
            LedBridge(BridgeCommands.AllOn);
        }

        /// <summary>
        /// Switch all white lights to low power mode
        /// </summary>
        public static void AllNightMode()
        {
            LedBridge(BridgeCommands.AllOff);
            Thread.Sleep(101);  // aparently 100ms isn't enough, I need 101 
            LedBridge(BridgeCommands.AllNight);
        }

        /// <summary>
        ///  Brighten the last selected group
        /// </summary>
        public static void Brighten()
        {
            LedBridge(BridgeCommands.BrightnessUp);
        }

        /// <summary>
        /// Dim the last selected group
        /// </summary>
        public static void Dim()
        {
            LedBridge(BridgeCommands.BrightnessDown);
        }

        /// <summary>
        /// Set Group 4 to Night mode 
        /// (takes 100ms as it requires 2 commands to be sent)
        /// </summary>       
        public static void Group4NightMode()
        {
            LedBridge(BridgeCommands.Group4Off);
            Thread.Sleep(101);
            LedBridge(BridgeCommands.Group4Night);
        }

        /// <summary>
        /// Set Group 3 to Night mode 
        /// (takes 100ms as it requires 2 commands to be sent)
        /// </summary>
        public static void Group3NightMode()
        {
            LedBridge(BridgeCommands.Group3Off);
            Thread.Sleep(101);
            LedBridge(BridgeCommands.Group3Night);
        }

        /// <summary>
        /// Set Group 2 to Night mode 
        /// (takes 100ms as it requires 2 commands to be sent)
        /// </summary>
        public static void Group2NightMode()
        {
            LedBridge(BridgeCommands.Group2Off);
            Thread.Sleep(101);
            LedBridge(BridgeCommands.Group2Night);
        }

        /// <summary>
        /// Set Group 1 to Night mode 
        /// (takes 100ms as it requires 2 commands to be sent)
        /// </summary>
        public static void Group1NightMode()
        {
            LedBridge(BridgeCommands.Group1Off);
            Thread.Sleep(101);
            LedBridge(BridgeCommands.Group1Night);
        }

        /// <summary>
        /// Turn group 1 off
        /// </summary>
        public static void Group1Off()
        {
            LedBridge(BridgeCommands.Group1Off);
        }
        
        /// <summary>
        /// Turn group 2 off
        /// </summary>
        public static void Group2Off()
        {
            LedBridge(BridgeCommands.Group2Off);
        }
        
        /// <summary>
        /// Turn group 3 off
        /// </summary>
        public static void Group3Off()
        {
            LedBridge(BridgeCommands.Group3Off);
        }
        
        /// <summary>
        /// Turn group 4 off
        /// </summary>
        public static void Group4Off()
        {
            LedBridge(BridgeCommands.Group4Off);
        }

        /// <summary>
        /// Turns on all lights to minimum brightness, then slowly increases the brightness over 10 min
        /// </summary>
        public static void WakeUpCall(string timeString)
        {
            DateTime now = DateTime.Now;
            if (timeString == "") timeString = now.ToString("hh:mm:ss");
            DateTime time;
            int brightTime = int.Parse(ConfigurationManager.AppSettings["wakeDelay"]);
            try
            {
                time = DateTime.Parse(timeString);
            }
            catch (FormatException fe) { Console.WriteLine("Try entering the time you would like to wake up similar to this: 6:00am."); return; }
            if (TimeSpan.FromMilliseconds(Math.Abs((time-now).TotalMilliseconds)) > TimeSpan.FromSeconds(1)) //If the difference is'nt more than a second, you probably meant now.
            {
                while (time.CompareTo(now) < 0) //If it is in the past, move it to the future.
                {
                    time = time.AddDays(1);
                }
                Console.Write("Wake up call at: ");
                Console.WriteLine(time);
                Thread.Sleep(time - now); //wait until the specified wake up time.
            }
            // Turn on White lights and then dim them to minimum after the delay set in the config file.
            AllOn();
            Thread.Sleep(brightTime);
            for (int i = 0; i < 13; i++) //13 just in case the bulbs miss a couple commands.
            {
                Dim();
                Thread.Sleep(101);
            }

            // Turn on the RGB Lights, set them to white and then dim them to minimum as fast as possible
            RGBOn();
            Thread.Sleep(101);
            RGBPrevMode();
            Thread.Sleep(101);
            for (int i = 0; i < 13; i++) //13 just in case the bulbs miss a couple commands.
            {
                RGBDim();
                Thread.Sleep(101);
            }
                    
            // Slowly increase brightness to max over the next 10 min
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(60000);
                AllOn();
                Thread.Sleep(101);
                Brighten();
                Thread.Sleep(101);
                RGBOn();
                Thread.Sleep(101);
                RGBPrevMode();
                Thread.Sleep(101);
                RGBBrighten();
            }
        }

        /// <summary>
        /// Turn on RGB LED Bulbs
        /// </summary>
        public static void RGBOn()
        {
            LedBridge(BridgeCommands.RGBOn);
        }

        /// <summary>
        /// Turn off the RGB Bulbs
        /// </summary>
        public static void RGBOff()
        {
            LedBridge(BridgeCommands.RGBOff);
        }


        /// <summary>
        /// Will set the RGB bulbs to the colour specified between 0 and 255
        /// </summary>
        /// <param name="colour"></param>
        public static void RGBColour(int colour)
        {
            // Set invalid colours to 0
            if (colour < 0 || colour > 256) { colour = 0; } 
            
            // Get generic colour command
            var hexCommand = (byte[])BridgeCommands.RGBColour.Clone();
           
            // Set to requested colour
            hexCommand[1] = (byte)colour;
            
            // Send command to bridge;
            UdpClient.Send(hexCommand, 3);
        }
        
        /// <summary>
        /// Set Disco Mode to next mode
        /// </summary>
        public static void RGBNextMode()
        {
            LedBridge(BridgeCommands.RGBDiscoNext);
        }

        /// <summary>
        /// Set Disco Mode to previous mode
        /// </summary>
        public static void RGBPrevMode()
        {
            LedBridge(BridgeCommands.RGBDiscoLast);
        }

        /// <summary>
        /// Brighten RGB Lights
        /// </summary>
        public static void RGBBrighten()
        {
            LedBridge(BridgeCommands.RGBBrightnessUp);
        }

        /// <summary>
        /// Dim the RGB Lights
        /// </summary>
        public static void RGBDim()
        {
            LedBridge(BridgeCommands.RGBBrightnessDown);
        }

        /// <summary>
        /// Increase the speed of the Colour LED's disco mode
        /// </summary>
        public static void RGBSpeedUp()
        {
            LedBridge(BridgeCommands.RGBSpeedUp);
        }

        /// <summary>
        /// Decrease the speed of the Colour LED's Disco mode
        /// </summary>
        public static void RGBSpeedDown()
        {
            LedBridge(BridgeCommands.RGBSpeedDown);
        }

    }
}
