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
            LedBridge(BridgeCommands.Group1On);
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
            // Turn on all lights and then dim them to minimum as fast as possible
            AllOn();
            Thread.Sleep(100);
            for (int i = 0; i < 10; i++)
            {
                Dim();
                Thread.Sleep(100);
            }
        
            // Slowly increase brightness to max over the next 10 min
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(60000);
                Brighten();
            }      
        }
    }
}
