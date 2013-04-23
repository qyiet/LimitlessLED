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
        static void Main(string[] args)
        {
            //This is control code for the LimitlessLED light bulbs.  It's currently pretty much under first draft testing.
            
            //initialize variables
            string bridgeipAddress = ConfigurationManager.AppSettings["ip"];
         
                    
    

            //Connect to LimitlessLED Wifi Bridge Receiver
            System.Net.Sockets.UdpClient udpClient = new System.Net.Sockets.UdpClient(bridgeipAddress, 50000);
        
            
        /*  Removed to allow testing of strobe mode below
            //Send hex command 38 which is "Turn Group1 LED lights ON" yes it remembers the last brightness and color, each LED contains a memory chip.
            udpClient.Send(new byte[] {
                                             0x38,
                                             0x0,
                                             0x55
                                             }, 3);
            //ToDo: send as many different commands here as you like, just change the number above where you see &H38

            //Close Connection
            udpClient.Close();
        */
     
    
    //Strobe mode:  Flash the lights till a key is pressed
     while (!Console.KeyAvailable)
            {
                    udpClient.Send(LimitlessLedCommands.Group1AllOff, 3);
                    System.Threading.Thread.Sleep(100);
                    udpClient.Send(LimitlessLedCommands.Group1AllOn, 3);
                    System.Threading.Thread.Sleep(100);
             }

        }
    }
}
