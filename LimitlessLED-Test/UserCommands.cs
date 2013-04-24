using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessLED_Test
{
    class UserCommands
    {
        //connect to bridge
        static System.Net.Sockets.UdpClient udpClient = new System.Net.Sockets.UdpClient(BridgeCommands.IPAddress(), 50000);
        //shortcut to send UDP commands to the wifi bridge
        static void ledBridge(byte[] hexCommand)
        {
            udpClient.Send(hexCommand, 3);
        }


        public static void StrobeMode()
        {   //Strobe mode:  Flash the lights till a key is pressed 
            Console.WriteLine("Starting Stobe mode, press any key to stop");
            while (!Console.KeyAvailable)
            {
                ledBridge(BridgeCommands.Group1AllOff);
                System.Threading.Thread.Sleep(100);
                ledBridge(BridgeCommands.Group1AllOn);
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void FadeDown()
        {
            //Fade  group 1 down
            Console.WriteLine("Not as cool as flash");
            //ensure group one is on, and selected by the wifi bridge
            ledBridge(BridgeCommands.Group1AllOn);
            System.Threading.Thread.Sleep(150);
            //Fade selected group down 10 steps  
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("This is dimming level " + i);
                ledBridge(BridgeCommands.BrightnessDown);
                System.Threading.Thread.Sleep(1000);

            } 
        }
        public static void FadeUp()
        {
            //Fade  group 1 up
                Console.WriteLine("Not as cool as flash");
            //ensure group one is on, and selected by the wifi bridge
                udpClient.Send(BridgeCommands.Group1AllOn, 3);
                System.Threading.Thread.Sleep(150);
            //Fade selected group up 10 steps  
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("This is dimming level " + (10 - i));
                udpClient.Send(BridgeCommands.BrightnessUp, 3);
                System.Threading.Thread.Sleep(1000);

            }
        }
        public static void AllOff()
        {
            //Turn off all the lights
            udpClient.Send(BridgeCommands.AllOff, 3);
        }
        public static void AllOn()
        {
            //Turn off all the lights
            udpClient.Send(BridgeCommands.AllOn, 3);
        }
        public static void AllNightMode()
        {
            //switch all white lights to low power mode
            udpClient.Send(BridgeCommands.AllOff, 3);
            System.Threading.Thread.Sleep(101);  //aparently 100ms isn't enough, I need 101 
            udpClient.Send(BridgeCommands.AllNightMode, 3);
        }

    }
}
