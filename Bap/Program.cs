using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Net.WebSocket;
using Newtonsoft.Json;

namespace Sharpbott
{
    public static class Program
    {
        public static DiscordClient Client { get; set; }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            MainTask().GetAwaiter().GetResult();
            
        }

        private static async Task MainTask()
        {
            // First we'll want to initialize our DiscordClient..
            var cfg = new DiscordConfiguration()
            {
                AutoReconnect = true, // Whether you want DSharpPlus to automatically reconnect
                LargeThreshold = 250, // Total number of members where the gateway will stop sending offline members in the guild member list
                LogLevel = LogLevel.Debug, // Minimum log level you want to use
                
                // neokekcore
                Token = "YOUR TOKEN HERE", // Your token
                
                TokenType = TokenType.Bot, // Your token type. Most likely "Bot"
                UseInternalLogHandler = true, // Whether you want to use the internal log handler
            };
//            if (Environment.OSVersion.Platform == PlatformID.Win32NT ||
//                Environment.OSVersion.Platform == PlatformID.Win32S ||
//                Environment.OSVersion.Platform == PlatformID.Win32Windows)
//            {
//                cfg.WebSocketClientFactory = WebSocket4NetClient.CreateNew;
//            }
            
            Client = new DiscordClient(cfg);

            // Now we'll want to define our events
            Client.DebugLogger.LogMessage(LogLevel.Info, "Bot", "Initializing events", DateTime.Now);

            // First off, the MessageCreated event.
            Client.DebugLogger.LogMessage(LogLevel.Info, "Bot", "Initializing MessageCreated", DateTime.Now);
            
            //Client.GuildAvailable += Loading.OnGuildAvailable;
            Client.MessageCreated += async e =>
            {
                Console.WriteLine(
                    $"[{DateTime.Now}] #{e.Channel.Name} {e.Author.Username}: {e.Message.Content}");
                if (e.Author.Id != 170382670713323520UL) return;
                var em = new DiscordEmbedBuilder()
                    .WithTitle("Caca")
                    .WithDescription("Farts")
                    .WithThumbnailUrl("https://i.imgur.com/dZVD5wF.png")
                    .WithTimestamp(DateTime.Now)
                    .WithColor(DiscordColor.Blurple)
                    .AddField("Foo", "Bar", true)
                    .AddField("Foo", "Bar", true)
                    .AddField("Foo", "Bar", true)
                    .AddField("Foo", "Bar", true)
                    .AddField("Foo", "Bar", true)
                    .WithFooter("Foot").Build();
                await e.Message.RespondAsync("", embed: em);
            };
            
            await Client.ConnectAsync();
            
            Client.DebugLogger.LogMessage(LogLevel.Info, "Bot", "Connected", DateTime.Now);

            await Task.Delay(-1);
        }
    }
}
