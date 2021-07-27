using ProcessMemory;
using SRTPluginProviderDinoCrisis1.Structs.GameStructs;
using System;
using System.Diagnostics;

namespace SRTPluginProviderDinoCrisis1
{
    internal class GameMemoryDC1CScanner : IDisposable
    {
        //private static readonly int MAX_ENTITIES = 8;
        private static readonly int MAX_SUPPLIES = 10;
        //private static readonly int MAX_BOX_ITEMS = 8;

        // Variables
        private ProcessMemoryHandler memoryAccess;
        private GameMemoryDC1C gameMemoryValues;
        public bool HasScanned;
        public bool ProcessRunning => memoryAccess != null && memoryAccess.ProcessRunning;
        public int ProcessExitCode => (memoryAccess != null) ? memoryAccess.ProcessExitCode : 0;

        // Pointer Address Variables
        private int pointerAddressHP;
        private int pointerAddressStats;
        private int pointerAddressEnemy;
        private int pointerAddressSupplies;

        // Pointer Classes
        private IntPtr BaseAddress { get; set; }

        internal GameMemoryDC1CScanner(Process process = null)
        {
            gameMemoryValues = new GameMemoryDC1C();
            if (process != null)
                Initialize(process);
        }

        internal void Initialize(Process process)
        {
            if (process == null)
                return; // Do not continue if this is null.

            
            SelectPointerAddresses(GameHashes.DetectVersion(process.MainModule.FileName));
            

            //if (!SelectPointerAddresses(GameHashes.DetectVersion(process.MainModule.FileName)))
            //    return; // Unknown version.

            int pid = GetProcessId(process).Value;
            memoryAccess = new ProcessMemoryHandler(pid);
            if (ProcessRunning)
            {
                BaseAddress = NativeWrappers.GetProcessBaseAddress(pid, PInvoke.ListModules.LIST_MODULES_64BIT); // Bypass .NET's managed solution for getting this and attempt to get this info ourselves via PInvoke since some users are getting 299 PARTIAL COPY when they seemingly shouldn't.
                gameMemoryValues._playerSupplies = new GameSupplies[MAX_SUPPLIES];
                for (var i = 0; i < MAX_SUPPLIES; i++)
                {
                    gameMemoryValues._playerSupplies[i] = new GameSupplies();
                }
            }
        }

        private void SelectPointerAddresses(GameVersion gv)
        {
            if (gv == GameVersion.DCR_SourceNext_20000419_1)
            {
                pointerAddressStats = 0x2DD8F0;
                pointerAddressHP = 0x2D59A0;
                pointerAddressSupplies = 0x2DDCFC;
                pointerAddressEnemy = 0x2D41E0;
            }
            else if (gv == GameVersion.Unknown)
            {
                Console.WriteLine("Unknown Version. May Not Be Supported Please Contact Developer!");
                pointerAddressStats = 0x2DD8F0;
                pointerAddressHP = 0x2D59A0;
                pointerAddressSupplies = 0x2DDCFC;
                pointerAddressEnemy = 0x2D41E0;
            }
        }

        internal IGameMemoryDC1C Refresh()
        {
            // Player HP
            gameMemoryValues._player = memoryAccess.GetAt<GamePlayer>(IntPtr.Add(BaseAddress, pointerAddressHP));

            // IGT
            gameMemoryValues._stats = memoryAccess.GetAt<GameStats>(IntPtr.Add(BaseAddress, pointerAddressStats));

            // Enemy HP
            gameMemoryValues._enemyHealth = memoryAccess.GetAt<GameEnemy>(IntPtr.Add(BaseAddress, pointerAddressEnemy));

            for (var i = 0; i < MAX_SUPPLIES; i++)
            {
                gameMemoryValues._playerSupplies[i] = memoryAccess.GetAt<GameSupplies>(IntPtr.Add(BaseAddress, pointerAddressSupplies + (i * 0x4)));
            }

            HasScanned = true;
            return gameMemoryValues;
        }

        private int? GetProcessId(Process process) => process?.Id;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls


        private unsafe bool SafeReadByteArray(IntPtr address, int size, out byte[] readBytes)
        {
            readBytes = new byte[size];
            fixed (byte* p = readBytes)
            {
                return memoryAccess.TryGetByteArrayAt(address, size, p);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (memoryAccess != null)
                        memoryAccess.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~REmake1Memory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}