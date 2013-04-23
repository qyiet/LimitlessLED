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

            //Process Command Line Arguements

                        if (args.Length != 0)
                        {
                            switch (args[0])
                            {
                                case "flash":
                                case "strobe":
                                case "blink":
                                    {
                                        //Strobe mode:  Flash the lights till a key is pressed 
                                            Console.WriteLine("Flash, ahhhaAHHHHAaaahhh");                        
                                            while (!Console.KeyAvailable)
                                             {
                                                udpClient.Send(LimitlessLedCommands.Group1AllOff, 3);
                                                System.Threading.Thread.Sleep(100);
                                                udpClient.Send(LimitlessLedCommands.Group1AllOn, 3);
                                                System.Threading.Thread.Sleep(100);
                                            }
                                            return;
                                    }
                                case "fadeDown":
                                case "fadedown":
                                case      "dim":
                                    {
                                        //Fade  group 1 down
                                        Console.WriteLine("Not as cool as flash");
                                        //ensure group one is on, and selected by the wifi bridge
                                        udpClient.Send(LimitlessLedCommands.Group1AllOn, 3);
                                        System.Threading.Thread.Sleep(150);
                                        //Fade selected group down 10 steps  
                                        for (int i = 1; i < 10; i++)
                                        {
                                            Console.WriteLine("This is dimming level " + i);
                                            udpClient.Send(LimitlessLedCommands.BrightnessDown, 3);
                                            System.Threading.Thread.Sleep(1000);

                                        }
                                        return;
                                    }

                                case "fadeUp":
                                case "fadeup":
                                case "brighten":
                                    {
                                     //Fade  group 1 up
                                        Console.WriteLine("Not as cool as flash");
                                        //ensure group one is on, and selected by the wifi bridge
                                        udpClient.Send(LimitlessLedCommands.Group1AllOn, 3);
                                        System.Threading.Thread.Sleep(150);
                                        //Fade selected group up 10 steps  
                                        for (int i = 1; i < 10; i++)
                                        {
                                            Console.WriteLine("This is dimming level " + i);
                                            udpClient.Send(LimitlessLedCommands.BrightnessUp, 3);
                                            System.Threading.Thread.Sleep(1000);

                                        }
                                        return;
                                    }
                                case "allOff":
                                case "alloff":
                                    {
                                       //Turn off all the lights
                                        udpClient.Send(LimitlessLedCommands.AllOff, 3);
                                        return;
                                    }
                                case "allOn":
                                case "allon":
                                    {
                                        //Turn off all the lights
                                        udpClient.Send(LimitlessLedCommands.AllOn, 3);
                                        return;
                                    }
                                case "allNightMode":
                                case "allnightmode":
                                    {
                                        //switch all white lights to low power mode
                                        udpClient.Send(LimitlessLedCommands.AllOff, 3);
                                        System.Threading.Thread.Sleep(101);  //aparently 100ms isn't enough, I need 101 
                                        udpClient.Send(LimitlessLedCommands.AllNightMode,3);
                                        return;
                                    }

                                default:
                                    {   //the the user we have no idea WTF they wanted
                                        Console.WriteLine("I have no idea what you wanted me to do");
                                        return;
                                    }
                            }
                        }
                        else
                        {
                        Console.WriteLine("There are input arguments required.  I really should put something here to explain them for you");
                        }

  

        }
    }
}
