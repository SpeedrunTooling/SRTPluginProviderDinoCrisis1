using SRTPluginBase;
using System;

namespace SRTPluginProviderDinoCrisis1
{
    internal class PluginInfo : IPluginInfo
    {
        public string Name => "Game Memory Provider (Dino Crisis 1)";

        public string Description => "A game memory provider plugin for Dino Crisis 1.";

        public string Author => "VideoGameRoulette";

        public Uri MoreInfoURL => new Uri("https://github.com/ResidentEvilSpeedrunning/SRTPluginProviderDinoCrisis1");

        public int VersionMajor => assemblyFileVersion.ProductMajorPart;

        public int VersionMinor => assemblyFileVersion.ProductMinorPart;

        public int VersionBuild => assemblyFileVersion.ProductBuildPart;

        public int VersionRevision => assemblyFileVersion.ProductPrivatePart;

        private System.Diagnostics.FileVersionInfo assemblyFileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
    }
}
