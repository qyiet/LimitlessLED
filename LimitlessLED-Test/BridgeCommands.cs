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
        public static byte[] AllOn          = { 0x35, 0x0, 0x55 };
        public static byte[] AllOff         = { 0x39, 0x0, 0x55 };
        public static byte[] AllNight       = { 0xB9, 0x0, 0x55 };
        public static byte[] AllFull        = { 0xB5, 0x0, 0x55 };
    
        public static byte[] BrightnessUp   = { 0x3C, 0x0, 0x55 };
        public static byte[] BrightnessDown = { 0x34, 0x0, 0x55 };

        public static byte[] ColorTempUp    = { 0x3E, 0x0, 0x55 };
        public static byte[] ColorTempDown  = { 0x3F, 0x0, 0x55 };

        public static byte[] Group1On       = { 0x38, 0x0, 0x55 };
        public static byte[] Group1Off      = { 0x3B, 0x0, 0x55 };
        public static byte[] Group1Night    = { 0xBB, 0x0, 0x55 };
        public static byte[] Group1Full     = { 0xB8, 0x0, 0x55 };

        public static byte[] Group2On       = { 0x3D, 0x0, 0x55 };
        public static byte[] Group2Off      = { 0x33, 0x0, 0x55 };
        public static byte[] Group2Night    = { 0xB3, 0x0, 0x55 };
        public static byte[] Group2Full     = { 0xBD, 0x0, 0x55 };

        public static byte[] Group3On       = { 0x37, 0x0, 0x55 };
        public static byte[] Group3Off      = { 0x3A, 0x0, 0x55 };
        public static byte[] Group3Night    = { 0xBA, 0x0, 0x55 };
        public static byte[] Group3Full     = { 0xB7, 0x0, 0x55 };

        public static byte[] Group4On       = { 0x32, 0x0, 0x55 };
        public static byte[] Group4Off      = { 0x36, 0x0, 0x55 };
        public static byte[] Group4Night    = { 0xB6, 0x0, 0x55 };
        public static byte[] Group4Full     = { 0xB2, 0x0, 0x55 };

        // RGB LEDs
        public static byte[] RGBOn             = { 0x22, 0x0, 0x55 };
        public static byte[] RGBOff            = { 0x21, 0x0, 0x55 };
        
        public static byte[] RGBBrightnessUp   = { 0x23, 0x0, 0x55 };
        public static byte[] RGBBrightnessDown = { 0x24, 0x0, 0x55 };
        
        public static byte[] RGBSpeedUp        = { 0x25, 0x0, 0x55 };
        public static byte[] RGBSpeedDown      = { 0x26, 0x0, 0x55 };
        
        public static byte[] RGBDiscoNext      = { 0x27, 0x0, 0x55 };
        public static byte[] RGBDiscoLast      = { 0x28, 0x0, 0x55 };

        public static byte[] RGBColour         = { 0x20, 0x0, 0x55 };
    }
}
