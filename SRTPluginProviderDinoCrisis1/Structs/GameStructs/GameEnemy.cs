using System.Runtime.InteropServices;

namespace SRTPluginProviderDinoCrisis1.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x4)]

    public struct GameEnemy
    {
        [FieldOffset(0x0)] private ushort currentHP;
        [FieldOffset(0x2)] private ushort maxHP;
        public ushort CurrentHP => currentHP;
        public ushort MaxHP => maxHP;
        public bool IsTrigger => MaxHP <= 10;
        public bool IsAlive => !IsTrigger && CurrentHP <= MaxHP;
        public bool IsDamaged => IsAlive && CurrentHP < MaxHP;
        public float Percentage => IsAlive ? (float)CurrentHP / (float)MaxHP : 0f;
    }
}
