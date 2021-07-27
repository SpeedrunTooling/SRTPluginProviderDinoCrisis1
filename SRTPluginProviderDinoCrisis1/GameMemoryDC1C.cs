using System;
using System.Globalization;
using System.Runtime.InteropServices;
using SRTPluginProviderDinoCrisis1.Structs;
using System.Diagnostics;
using System.Reflection;
using SRTPluginProviderDinoCrisis1.Structs.GameStructs;

namespace SRTPluginProviderDinoCrisis1
{
    public class GameMemoryDC1C : IGameMemoryDC1C
    {
        private const string IGT_TIMESPAN_STRING_FORMAT = @"hh\:mm\:ss";
        public string GameName => "Dino Crisis 1 Rebirth";
        // Versioninfo
        public string VersionInfo => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        // Player HP
        public GamePlayer Player { get => _player; set => _player = value;  }
        internal GamePlayer _player;

        // Player Supplies
        public GameSupplies[] PlayerSupplies { get => _playerSupplies; set => _playerSupplies = value; }
        internal GameSupplies[] _playerSupplies;

        // IGT
        public GameStats Stats { get => _stats; set => _stats = value; }
        internal GameStats _stats;

        public GameEnemy EnemyHealth { get => _enemyHealth; set => _enemyHealth = value; }
        internal GameEnemy _enemyHealth;

        public TimeSpan IGTTimeSpan
        {
            get
            {
                TimeSpan timespanIGT;

                if (Stats.IGT >= 0f)
                    timespanIGT = TimeSpan.FromSeconds(Stats.IGT / 60);
                else
                    timespanIGT = new TimeSpan();

                return timespanIGT;
            }
        }

        public string IGTFormattedString => IGTTimeSpan.ToString(IGT_TIMESPAN_STRING_FORMAT, CultureInfo.InvariantCulture);
    }
}
