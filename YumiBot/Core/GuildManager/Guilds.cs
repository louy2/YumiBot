using System.Collections.Generic;
using System.Linq;
using Discord;

namespace YumiBot.Core.GuildManager
{
	public static class Guilds
	{
		// ReSharper disable once InconsistentNaming
		private static readonly List<Guild> _Guilds;

		private const string GuildsFile = "Resources/guilds.json";

		static Guilds()
		{
			if(DataStorage<Guild>.SaveExists(GuildsFile))
			{
				_Guilds = DataStorage<Guild>.LoadItems(GuildsFile).ToList();
			}
			else
			{
				_Guilds = new List<Guild>();
				SaveGuilds();
			}
		}

		/// <summary>
		/// Save all the guilds into the json file.
		/// </summary>
		public static void SaveGuilds()
		{
			DataStorage<Guild>.SaveItems(_Guilds, GuildsFile);
		}
		
		/// <summary>
		/// Get a bot guild from a Discord guild.
		/// </summary>
		/// <param name="guild"></param>
		/// <returns></returns>
		public static Guild GetGuild(IGuild guild)
		{
			return GetOrCreateGuild(guild.Id);
		}

		private static Guild GetOrCreateGuild(ulong id)
		{
			var result = from a in _Guilds
				where a.Id == id
				select a;

			var account = result.FirstOrDefault() ?? CreateGuild(id);
			return account;
		}

		private static Guild CreateGuild(ulong id)
		{
			var newAccount = new Guild()
			{
				Id = id,
			};

			_Guilds.Add(newAccount);
			return newAccount;
		}
	}
}
