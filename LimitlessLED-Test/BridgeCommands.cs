namespace LimitlessLED_Test
{
    /// <summary>
    /// As documented at:
    /// http://www.limitlessled.com/dev/
    /// </summary>
    class BridgeCommands
    {
        // Commands
        // White LEDs
        public static byte[] AllOn          = new byte[] { 0x35, 0x0, 0x55 };
        public static byte[] AllOff         = new byte[] { 0x39, 0x0, 0x55 };
        public static byte[] AllNight       = new byte[] { 0xB9, 0x0, 0x55 };
        public static byte[] AllFull        = new byte[] { 0xB5, 0x0, 0x55 };
    
        public static byte[] BrightnessUp   = new byte[] { 0x3C, 0x0, 0x55 };
        public static byte[] BrightnessDown = new byte[] { 0x34, 0x0, 0x55 };

        public static byte[] ColorTempUp    = new byte[] { 0x3E, 0x0, 0x55 };
        public static byte[] ColorTempDown  = new byte[] { 0x3F, 0x0, 0x55 };

        public static byte[] Group1On       = new byte[] { 0x38, 0x0, 0x55 };
        public static byte[] Group1Off      = new byte[] { 0x3B, 0x0, 0x55 };
        public static byte[] Group1Night    = new byte[] { 0xBB, 0x0, 0x55 };
        public static byte[] Group1Full     = new byte[] { 0xB8, 0x0, 0x55 };

        public static byte[] Group2On       = new byte[] { 0x3D, 0x0, 0x55 };
        public static byte[] Group2Off      = new byte[] { 0x33, 0x0, 0x55 };
        public static byte[] Group2Night    = new byte[] { 0xB3, 0x0, 0x55 };
        public static byte[] Group2Full     = new byte[] { 0xBD, 0x0, 0x55 };

        public static byte[] Group3On       = new byte[] { 0x37, 0x0, 0x55 };
        public static byte[] Group3Off      = new byte[] { 0x3A, 0x0, 0x55 };
        public static byte[] Group3Night    = new byte[] { 0xBA, 0x0, 0x55 };
        public static byte[] Group3Full     = new byte[] { 0xB7, 0x0, 0x55 };

        public static byte[] Group4On       = new byte[] { 0x32, 0x0, 0x55 };
        public static byte[] Group4Off      = new byte[] { 0x36, 0x0, 0x55 };
        public static byte[] Group4Night    = new byte[] { 0xB6, 0x0, 0x55 };
        public static byte[] Group4Full     = new byte[] { 0xB2, 0x0, 0x55 };
    }
}
