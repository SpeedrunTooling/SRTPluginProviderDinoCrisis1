using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SRTPluginProviderDinoCrisis1.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x3)]

    public struct GameSupplies
    {
        [FieldOffset(0x0)] private byte id;
        [FieldOffset(0x1)] private byte quantity;
        [FieldOffset(0x2)] private byte itemType;

        public byte ID => id;
        public string Name => Items.Names.ContainsKey(ID) ? Items.Names[ID] : "";
        public byte Quantity => Items.Names.ContainsKey(ID) ? quantity : (byte)0;
        public int MaxQuantity => Items.MaxQuantity.ContainsKey(ID) ? Items.MaxQuantity[ID] : 0;
        public byte ItemType => itemType;
    }

    public class Items
    {
        public static Dictionary<byte, string> Names = new Dictionary<byte, string>()
        {
            { 0x10, "SG Bullets" },
            { 0x11, "Slag Bullets" },
            { 0x12, "An. Dart S" },
            { 0x13, "An. Dart M" },
            { 0x14, "An. Dart L" },
            { 0x15, "Poison Dart" },
            { 0x16, "9mm Parabellum" },
            { 0x17, "40S&W Bullets" },
            { 0x18, "Grenade Bullets" },
            { 0x19, "Heat Bullets" },
            { 0x1A, "Infinite Grenades" },
            { 0x1B, "Hemostat" },
            { 0x1C, "Med. Pak S" },
            { 0x1D, "Med. Pak M" },
            { 0x1E, "Med. Pak L" },
            { 0x1F, "Resuscitation" },
            { 0x20, "An. Aid" },
            { 0x21, "Recovery Aid" },
            { 0x22, "Intensifier" },
            { 0x23, "Multiplier" }
        };

        public static Dictionary<byte, int> MaxQuantity = new Dictionary<byte, int>()
        {
            { 0x10, 10 },
            { 0x11, 10 },
            { 0x12, 3 },
            { 0x13, 3 },
            { 0x14, 3 },
            { 0x15, 3 },
            { 0x16, 34 },
            { 0x17, 30 },
            { 0x18, 6 },
            { 0x19, 6 },
            { 0x1A, 255 },
            { 0x1B, 2 },
            { 0x1C, 2 },
            { 0x1D, 2 },
            { 0x1E, 2 },
            { 0x1F, 1 },
            { 0x20, 1 },
            { 0x21, 1 },
            { 0x22, 1 },
            { 0x23, 1 }
        };
    }
}
