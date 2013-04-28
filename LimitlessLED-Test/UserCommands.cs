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

        public static void Dim()
        {
            LedBridge(BridgeCommands.BrightnessDown);
        }
    }
}
