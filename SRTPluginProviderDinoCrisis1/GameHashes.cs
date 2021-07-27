using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace SRTPluginProviderDinoCrisis1
{
    /// <summary>
    /// SHA256 hashes for the RE1/BIO1 game executables.
    /// </summary>
    public static class GameHashes
    {
        private static readonly byte[] DCR_SourceNext_20000419_1 = new byte[32] { 0x7A, 0xCC, 0x3D, 0xC1, 0xA3, 0xF3, 0x39, 0x8E, 0x08, 0xE5, 0xBD, 0xAD, 0x74, 0x6B, 0xDB, 0xF9, 0x8C, 0xA5, 0x50, 0x7E, 0x9B, 0x9B, 0xA5, 0xFB, 0xA7, 0x09, 0x03, 0x1B, 0x49, 0x8D, 0x3F, 0xCA };

        public static GameVersion DetectVersion(string filePath)
        {
            byte[] checksum;
            using (SHA256 hashFunc = SHA256.Create())
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                checksum = hashFunc.ComputeHash(fs);

            if (checksum.SequenceEqual(DCR_SourceNext_20000419_1))
            {
                Console.WriteLine("(SourceNext) Rebirth");
                return GameVersion.DCR_SourceNext_20000419_1;
            }

            Console.WriteLine("Unknown Version");
            return GameVersion.Unknown;
        }
    }
}