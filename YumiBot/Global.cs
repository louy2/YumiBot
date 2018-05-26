using Discord.WebSocket;
using System;

namespace YumiBot
{
	internal static class Global
	{
		internal static DiscordSocketClient Client { get; set; }
		public static Random Random = new Random();
	}
}