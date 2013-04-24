using System.Configuration;

namespace LimitlessLED_Test
{
    /// <summary>
    /// As documented at:
    /// http://www.limitlessled.com/dev/
    /// </summary>
    class BridgeCommands
    {
        //commands
        public static byte[] AllOn          = new byte[] { 0x35, 0x0, 0x55 };
        public static byte[] AllOff         = new byte[] { 0x39, 0x0, 0x55 };
        public static byte[] AllNightMode   = new byte[] { 0xB9, 0x0, 0x55 };
        
        public static byte[] BrightnessUp   = new byte[] { 0x3C, 0x0, 0x55 };
        public static byte[] BrightnessDown = new byte[] { 0x34, 0x0, 0x55 };

        public static byte[] Group1AllOn    = new byte[] { 0x38, 0x0, 0x55 };
        public static byte[] Group1AllOff   = new byte[] { 0x3B, 0x0, 0x55 };

        public static string IPAddress()
        {
            string bridgeipAddress = ConfigurationManager.AppSettings["ip"];
            return bridgeipAddress;
        }
    }
}
