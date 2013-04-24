using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LimitlessLED_Test
{
    class UserCommands
    {
        //connect to bridge
            static string bridgeipAddress = ConfigurationManager.AppSettings["ip"];
            static System.Net.Sockets.UdpClient udpClient = new System.Net.Sockets.UdpClient(bridgeipAddress, 50000);
        /// <summary>
        /// Shortcut to send UDP commands to the wifi bridge
        /// </summary>
        static void LedBridge(byte[] hexCommand)
        {
            udpClient.Send(hexCommand, 3);
        }

        /// <summary>
        /// Used for testing individual commands, once
        /// Debugging is complete
        /// </summary>
        public static void Test()
        {
            LedBridge(BridgeCommands.Group4On);
            System.Threading.Thread.Sleep(100);
            LedBridge(BridgeCommands.Group4Full);

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
                System.Threading.Thread.Sleep(100);
                LedBridge(BridgeCommands.Group1On);
                System.Threading.Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Slow fade group one to minimum
        /// this will probably be renamed later due to potential naming conflict
        /// </summary>
        public static void FadeDown()
        {
            //Fade  group 1 down
            Console.WriteLine("Not as cool as flash");
            //ensure group one is on, and selected by the wifi bridge
            LedBridge(BridgeCommands.Group1On);
            System.Threading.Thread.Sleep(150);
            //Fade selected group down 10 steps  
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("This is dimming level " + i);
                LedBridge(BridgeCommands.BrightnessDown);
                System.Threading.Thread.Sleep(1000);

            } 
        }


        /// <summary>
        /// Slow fade group one to maximum
        /// this will probably be renamed later due to potential naming conflict
        /// </summary>
        public static void FadeUp()
        {
             Console.WriteLine("Not as cool as flash");
            
            //ensure group one is on, and selected by the wifi bridge
                LedBridge(BridgeCommands.Group1On);
                System.Threading.Thread.Sleep(150);
       
            //Fade selected group up 10 steps  
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("This is dimming level " + (10 - i));
                LedBridge(BridgeCommands.BrightnessUp);
                System.Threading.Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Turn off all white lights
        /// </summary>
        public static void AllOff()
        {
            LedBridge(BridgeCommands.AllOff);
        }

        /// <summary>
        /// Turn off all the lights
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
            System.Threading.Thread.Sleep(101);  //aparently 100ms isn't enough, I need 101 
            LedBridge(BridgeCommands.AllNight);
        }


    }
}
