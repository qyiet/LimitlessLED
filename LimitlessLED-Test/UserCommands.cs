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
        //shortcut to send UDP commands to the wifi bridge
        static void LedBridge(byte[] hexCommand)
        {
            udpClient.Send(hexCommand, 3);
        }

        public static void Test()
        {
            LedBridge(BridgeCommands.Group4On);
            System.Threading.Thread.Sleep(100);
            LedBridge(BridgeCommands.Group4Full);

        }

        public static void StrobeMode()
        {   
            //Strobe mode:  Flash the lights till a key is pressed 
            Console.WriteLine("Starting Strobe mode, press any key to stop");
            while (!Console.KeyAvailable)
            {
                LedBridge(BridgeCommands.Group1Off);
                System.Threading.Thread.Sleep(100);
                LedBridge(BridgeCommands.Group1On);
                System.Threading.Thread.Sleep(100);
            }
        }

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

        public static void FadeUp()
        {
            //Fade  group 1 up
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

        public static void AllOff()
        {
            //Turn off all the lights
            LedBridge(BridgeCommands.AllOff);
        }

        public static void AllOn()
        {
            //Turn off all the lights
            LedBridge(BridgeCommands.AllOn);
        }

        public static void AllNightMode()
        {
            //switch all white lights to low power mode
            LedBridge(BridgeCommands.AllOff);
            System.Threading.Thread.Sleep(101);  //aparently 100ms isn't enough, I need 101 
            LedBridge(BridgeCommands.AllNight);
        }


    }
}
