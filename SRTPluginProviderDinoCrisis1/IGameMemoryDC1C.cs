using System;
using SRTPluginProviderDinoCrisis1.Structs;
using SRTPluginProviderDinoCrisis1.Structs.GameStructs;

namespace SRTPluginProviderDinoCrisis1
{
    public interface IGameMemoryDC1C
    {
        string GameName { get; }
        // Plugin Version Info
        string VersionInfo { get; }

        // Player HP
        GamePlayer Player { get; set; }

        // Game Stats
        GameStats Stats { get; set; }

        // Enemy HP
        GameEnemy EnemyHealth { get; set; }

        TimeSpan IGTTimeSpan { get; }

        string IGTFormattedString { get; }
    }
}