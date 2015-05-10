namespace LimitlessLED_Test
{
    /// <summary>
    /// As documented at:
    /// http://www.limitlessled.com/dev/
    /// </summary>
    class BridgeCommands
    {
        // Commands
        public static byte[] AllOn          = { 0x42, 0x0, 0x55 };
        public static byte[] AllOff         = { 0x41, 0x0, 0x55 };
        public static byte[] AllWhite       = { 0xC2, 0x0, 0x55 };

    
        public static byte[] BrightnessUp   = { 0x3C, 0x0, 0x55 };
        public static byte[] BrightnessDown = { 0x34, 0x0, 0x55 };

        public static byte[] Group1On       = { 0x45, 0x0, 0x55 };
        public static byte[] Group1Off      = { 0x46, 0x0, 0x55 };
        public static byte[] Group1White    = { 0xC5, 0x0, 0x55 };

        public static byte[] Group2On       = { 0x47, 0x0, 0x55 };
        public static byte[] Group2Off      = { 0x48, 0x0, 0x55 };
        public static byte[] Group2White    = { 0xC7, 0x0, 0x55 };

        public static byte[] Group3On       = { 0x49, 0x0, 0x55 };
        public static byte[] Group3Off      = { 0x4A, 0x0, 0x55 };
        public static byte[] Group3White    = { 0xC9, 0x0, 0x55 };

        public static byte[] Group4On       = { 0x4B, 0x0, 0x55 };
        public static byte[] Group4Off      = { 0x4C, 0x0, 0x55 };
        public static byte[] Group4White    = { 0xCB, 0x0, 0x55 };

        public static byte[] DiscoSpeedUp   = { 0x44, 0x0, 0x55 };
        public static byte[] DiscoSpeedDown = { 0x43, 0x0, 0x55 };
        
        public static byte[] DiscoNext      = { 0x4D, 0x0, 0x55 };

        public static byte[] RGBColour      = { 0x20, 0x0, 0x55 };

    }
}