using System;
using System.Reflection;
#if !HAS_ENVIRONMENT
using System.Runtime.InteropServices;
#endif
using Newtonsoft.Json;

namespace DSharpPlus.Net.Abstractions
{
    /// <summary>
    /// Represents data for identify payload's client properties.
    /// </summary>
    internal sealed class ClientProperties
    {
        /// <summary>
        /// Gets the client's operating system.
        /// </summary>
        [JsonProperty("$os")]
        public string OperatingSystem
        {
            get
            {
                switch (Environment.OSVersion.Platform)
                {
                    case PlatformID.Win32NT:
                    case PlatformID.WinCE:
                        return "windows";
                    case PlatformID.MacOSX:
                        return "osx";
                    case PlatformID.Win32S:
                    case PlatformID.Win32Windows:
                    case PlatformID.Xbox:
                        return "potato";
                    case PlatformID.Unix:
                        return "unix";
                }

                var plat = Environment.OSVersion.VersionString;
                if (plat.Contains("freebsd"))
                    return "freebsd";
                if (plat.Contains("openbsd"))
                    return "openbsd";
                if (plat.Contains("netbsd"))
                    return "netbsd";
                if (plat.Contains("dragonfly"))
                    return "dragonflybsd";
                if (plat.Contains("miros bsd") || plat.Contains("mirbsd"))
                    return "miros bsd";
                if (plat.Contains("desktopbsd"))
                    return "desktopbsd";
                if (plat.Contains("darwin"))
                    return "osx";
                if (plat.Contains("unix"))
                    return "unix";
                return "toaster (unknown)";
            }
        }

        /// <summary>
        /// Gets the client's browser.
        /// </summary>
        [JsonProperty("$browser")]
        public string Browser
        {
            get
            {
                var a = typeof(DiscordClient).GetTypeInfo().Assembly;
                var an = a.GetName();
                return $"DSharpPlus {an.Version.ToString(4)}";
            }
        }

        /// <summary>
        /// Gets the client's device.
        /// </summary>
        [JsonProperty("$device")]
        public string Device 
            => this.Browser;

        /// <summary>
        /// Gets the client's referrer.
        /// </summary>
        [JsonProperty("$referrer")]
        public string Referrer 
            => "";

        /// <summary>
        /// Gets the client's referring domain.
        /// </summary>
        [JsonProperty("$referring_domain")]
        public string ReferringDomain 
            => "";
    }
}
