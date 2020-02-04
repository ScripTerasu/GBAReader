using System;
using System.IO;
using System.Text;

namespace GBAReader
{
    public static class BinUtil
    {
        public static string AsciiToString(byte[] byteArray, int offset, int length)
        {
            StringBuilder sb = new StringBuilder();
            for (int x = offset; x < offset + length; x++)
            {
                byte b = byteArray[x];
                if (IsValidAscii(b))
                {
                    char c = (char)(b & 0xFF);
                    sb.Append(c);
                }
            }
            return sb.ToString().Trim();
        }

        /**
     * Returns true when the given byte is a valid ascii char (with a value between 32 and 126).
     */
        private static bool IsValidAscii(byte c)
        {
            return c >= 0x20 && c <= 0x7E;
        }

        public static string ByteToHex(byte b)
        {
            return string.Format("{0:X2}", b);
        }
    }
}