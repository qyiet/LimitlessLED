namespace LimitlessLED_Test
{
    /// <summary>
    /// As documented at:
    /// http://www.limitlessled.com/dev/
    /// </summary>
    class BridgeCommands
    {
        // Commands
        public static byte[] AllOn          = new byte[] { 0x42, 0x0, 0x55 };
        public static byte[] AllOff         = new byte[] { 0x41, 0x0, 0x55 };
        public static byte[] AllWhite       = new byte[] { 0xC2, 0x0, 0x55 };
    
        public static byte[] BrightnessUp   = new byte[] { 0x3C, 0x0, 0x55 };
        public static byte[] BrightnessDown = new byte[] { 0x34, 0x0, 0x55 };

        public static byte[] Group1On       = new byte[] { 0x45, 0x0, 0x55 };
        public static byte[] Group1Off      = new byte[] { 0x46, 0x0, 0x55 };
        public static byte[] Group1White    = new byte[] { 0xC5, 0x0, 0x55 };

        public static byte[] Group2On       = new byte[] { 0x47, 0x0, 0x55 };
        public static byte[] Group2Off      = new byte[] { 0x48, 0x0, 0x55 };
        public static byte[] Group2White    = new byte[] { 0xC7, 0x0, 0x55 };

        public static byte[] Group3On       = new byte[] { 0x49, 0x0, 0x55 };
        public static byte[] Group3Off      = new byte[] { 0x4A, 0x0, 0x55 };
        public static byte[] Group3White    = new byte[] { 0xC9, 0x0, 0x55 };

        public static byte[] Group4On       = new byte[] { 0x4B, 0x0, 0x55 };
        public static byte[] Group4Off      = new byte[] { 0x4C, 0x0, 0x55 };
        public static byte[] Group4White    = new byte[] { 0xCB, 0x0, 0x55 };

        public static byte[] DiscoSpeedUp   = new byte[] { 0x44, 0x0, 0x55 };
        public static byte[] DiscoSpeedDown = new byte[] { 0x43, 0x0, 0x55 };
        
        public static byte[] DiscoNext      = new byte[] { 0x4D, 0x0, 0x55 };
        public static byte[] DiscoLast      = new byte[] { 0x28, 0x0, 0x55 };

        public static byte[] RGBColour      = new byte[] { 0x20, 0x0, 0x55 };

    }
}
