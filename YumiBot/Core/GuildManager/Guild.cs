using System.Collections.Generic;
using Discord;

namespace YumiBot.Core.GuildManager
{
	public class Guild
	{
		/// <summary>
		/// The guild's Discord-generated Id.
		/// </summary>
		public ulong Id { get; set; }

		/// <summary>
		/// Is the custom prefix set by an admin
		/// </summary>
		public string CustomPrefix { get; set; } = null;

		/// <summary>
		/// Roles in which users need to have in order to be considered an admin. 
		/// Having ANY of these roles makes them so.
		/// </summary>
		public List<IRole> AdminRoles { get; set; }
	}
}
