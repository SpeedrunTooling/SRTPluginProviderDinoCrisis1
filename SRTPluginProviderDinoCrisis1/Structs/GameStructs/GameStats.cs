using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SRTPluginProviderDinoCrisis1.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x2)]

    public struct GameStats
    {
        [FieldOffset(0x0)] private short roomID;
        [FieldOffset(0x3)] private byte saveCount;
        [FieldOffset(0x4)] private uint igt;
        [FieldOffset(0xA)] private byte continues;

        public short RoomID => roomID;
        public string RoomName => Rooms.Names.ContainsKey(RoomID) ? Rooms.Names[RoomID] : "";
        public byte SaveCount => saveCount;
        public uint IGT => igt;
        public byte Continues => continues;
    }

    public class Rooms
    {
        public static Dictionary<short, string> Names = new Dictionary<short, string>()
        {
            { 0x101, "Toilets" },
            { 0x102, "Management Office Hallway" },
            { 0x103, "Management Office (Save Room)" },
            { 0x104, "Strategy Room" },
            { 0x105, "Control Room Hall" },
            { 0x106, "Control Room" },
            { 0x107, "Main Entrance" },
            { 0x108, "Lecture Room Hallway" },
            { 0x109, "Lecture Room" },
            { 0x10A, "Office Hallway" },
            { 0x10B, "Office" },
            { 0x10C, "Material Storage" },
            { 0x10D, "Backyard Of Facility" },
            { 0x10E, "Passageway To Back-Up Generator" },
            { 0x10F, "Back-Up Generator Room" },
            { 0x110, "Piping Check Passageway A" },
            { 0x111, "Piping Check Passageway B" },
            { 0x112, "The Backyard" },
            { 0x113, "Elevator Hall" },
            { 0x201, "Communication Antenna Passageway" },
            { 0x202, "Chief's Room" },
            { 0x203, "Hall" },
            { 0x204, "Lounge" },
            { 0x205, "Communications Room" },
            { 0x206, "Stairway" },
            { 0x301, "Research Area Hall" },
            { 0x302, "Research Meeting Room" },
            { 0x303, "Gas Experiment Room" },
            { 0x304, "Computer Room (Save Room)" },
            { 0x305, "Library Room" },
            { 0x306, "Main Hallway" },
            { 0x307, "Medical Room Hallway" },
            { 0x308, "Medical Room" },
            { 0x309, "Hall" },
            { 0x30A, "Hallway For Carrying Materials" },
            { 0x30B, "Back-Up Generator Room" },
            { 0x30C, "Carry Out Room" },
            { 0x401, "Passageway To Heliport" },
            { 0x402, "Hangar" },
            { 0x403, "Heliport" },
            { 0x404, "Large Size Elevator Passageway" },
            { 0x405, "Large Size Elevator" },
            { 0x406, "Large Size Elevator Control Room" },
            { 0x407, "Passageway To Power Room" },
            { 0x408, "Elevator Power Room" },
            { 0x409, "Liaison Elevator #2" },
            { 0x40A, "Undeground Passageway To Facility" },
            { 0x40B, "Materials Room" },
            { 0x40C, "Liaison Elevator #1" },
            { 0x40D, "FMV of T-Rex Attacking Helicopter" },
            { 0x501, "Piping Check Passageway B2" },
            { 0x502, "Stabilizer Research Hallway" },
            { 0x503, "Stabilizer Experiment Room" },
            { 0x504, "Stabilizer Design Room" },
            { 0x505, "Researchers Resting Room" },
            { 0x506, "Security Pass Room (Save Room)" },
            { 0x507, "Parts Storage" },
            { 0x508, "Passageway" },
            { 0x509, "Third Energy Area B2" },
            { 0x50A, "Third Energy Area B3" },
            { 0x50B, "Third Energy Control Room" },
            { 0x50C, "Power Freq. Room" },
            { 0x50D, "Passageway To Personal Lab" },
            { 0x50E, "Dr.Kirks Personal Lab" },
            { 0x50F, "Dr.Kirks Library Room" },
            { 0x510, "Third Energy Control Room:Lower Level" },
            { 0x601, "Back-Up Generator Room" },
            { 0x602, "Control Room (Save Room)" },
            { 0x603, "Passageway To Carrying Out Room" },
            { 0x604, "Rest Station" },
            { 0x605, "General Weapons Storage" },
            { 0x606, "Transport Passageway" },
            { 0x607, "Special Weapons Storage" },
            { 0x608, "Central Stairway" },
            { 0x609, "Disembarkation Immigration Office (Save Room)" },
            { 0x60A, "Port" },
            { 0x60B, "Passageway To Port" },
            { 0x60C, "On Back Of Hovercraft: Final Fight With T-Rex" },
            { 0x60D, "Underground Heliport" },
            { 0x610, "Hovercraft Storage" },
            { 0x612, "Inside Hovercraft: Before Final Fight With T -Rex" },
            { 0x613, "Port: T-Rex Chase And Fight" },
            { 0x614, "Port Transport Passageway" }
        };
    }
}
