using System.Runtime.InteropServices;

namespace SRTPluginProviderDinoCrisis1.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x4)]

    public struct GamePlayer
    {
        [FieldOffset(0x0)] private short currentHP;
        [FieldOffset(0x2)] private short maxHP;
        public short CurrentHP => currentHP;
        public short MaxHP => maxHP;
        public float Percentage => CurrentHP > 0 ? (float)CurrentHP / (float)MaxHP : 0f;
        public bool IsAlive => CurrentHP != 0 && CurrentHP > 0 && CurrentHP <= MaxHP;

        public PlayerStatus HealthState
        {
            get =>
                !IsAlive ? PlayerStatus.Dead :
                Percentage >= 0.75 ? PlayerStatus.Fine :
                Percentage >= 0.50 ? PlayerStatus.FineToo :
                Percentage >= 0.25 ? PlayerStatus.FineToo : PlayerStatus.Danger;
        }
    }

    public enum PlayerStatus
    {
        Dead,
        Fine,
        FineToo,
        Caution,
        Danger
    }
}
