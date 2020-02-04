using System;
using System.IO;

namespace GBAReader
{
    internal class Program
    {
        #region Private Methods

        private static void Main()
        {
            Console.WriteLine("Hello World!");
            var path = @"C:\TEMP\Dynasty Warriors Advance [E].gba";

            byte[] gbaHeader = new byte[HEADER_LENGTH];
            using (BinaryReader br = new BinaryReader(File.OpenRead(path))) //Sets a new integer to the BinaryReader
            {
                gbaHeader = br.ReadBytes(HEADER_LENGTH);
                br.Close();
            }

            var title = BinUtil.AsciiToString(gbaHeader, TITLE_OFFSET, TITLE_LENGTH);
            var gameCode = BinUtil.AsciiToString(gbaHeader, GAME_CODE_OFFSET, GAME_CODE_LENGTH);
            var makerCode = BinUtil.AsciiToString(gbaHeader, MAKER_CODE_OFFSET, MAKER_CODE_LENGTH);
            var unitCode = BinUtil.ByteToHex(gbaHeader[UNIT_CODE_OFFSET]);
            var versionCode = BinUtil.ByteToHex(gbaHeader[VERSION_CODE_OFFSET]);
            var headerChecksum = BinUtil.ByteToHex(gbaHeader[HEADER_CHECKSUM_OFFSET]);

            Console.WriteLine("[{0}]: {1}", "Title", title);
            Console.WriteLine("[{0}]: {1}", "Game Code", gameCode);
            Console.WriteLine("[{0}]: {1}", "Maker Code", makerCode);
            Console.WriteLine("[{0}]: {1}", "Unit Code", unitCode);
            Console.WriteLine("[{0}]: {1}", "Version Code", versionCode);
            Console.WriteLine("[{0}]: {1}", "Header Checksum", headerChecksum);

            Console.ReadKey();
        }

        private static int GAME_CODE_LENGTH = 4;
        private static int GAME_CODE_OFFSET = 172;
        private static int HEADER_CHECKSUM_OFFSET = 189;
        private static int HEADER_LENGTH = 192; // 0xC0

        private static int MAKER_CODE_LENGTH = 2;

        // 0xAC
        private static int MAKER_CODE_OFFSET = 176;

        private static int TITLE_LENGTH = 12;
        private static int TITLE_OFFSET = 160; // 0xA0

                                               // 0xB0
        private static int UNIT_CODE_OFFSET = 179; // 0xB3

        private static int VERSION_CODE_OFFSET = 188; // 0xBC

        // 0xBD

        #endregion Private Methods
    }
}