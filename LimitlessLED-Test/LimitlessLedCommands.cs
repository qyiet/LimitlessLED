namespace LimitlessLED_Test
{
    /// <summary>
    /// As documented at:
    /// http://www.limitlessled.com/dev/
    /// </summary>
    class LimitlessLedCommands
    {
        public static byte[] Group1AllOn  = new byte[] { 0x38, 0x0, 0x55 };
        public static byte[] Group1AllOff = new byte[] { 0x3B, 0x0, 0x55 };
    }
}
