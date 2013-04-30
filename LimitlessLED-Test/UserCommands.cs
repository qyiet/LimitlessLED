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
        static readonly UdpClient UdpClient = new UdpClient(BridgeIpAddress, 50000);

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

            WakeUpCall();
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
        public static void WakeUpCall()
        {
            // Turn on White lights and then dim them to minimum as fast as possible
            AllOn();
            Thread.Sleep(100);         
            for (int i = 0; i < 10; i++)
            {
                Dim();
                Thread.Sleep(100);
            }

            // Turn on the RGB Lights, set them to white and then dim them to minimum as fast as possible
            RGBOn();
            Thread.Sleep(100);
            RGBPrevMode();
            Thread.Sleep(100);
            for (int i = 0; i < 10; i++)
            {
                RGBDim();
                Thread.Sleep(100);
            }
                    
            // Slowly increase brightness to max over the next 10 min
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(60000);
                AllOn();
                Thread.Sleep(100);
                Brighten();
                Thread.Sleep(100);
                RGBOn();
                Thread.Sleep(100);
                RGBPrevMode();
                Thread.Sleep(100);
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
