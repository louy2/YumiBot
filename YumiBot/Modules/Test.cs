using System.Threading.Tasks;
using Discord.Commands;

namespace YumiBot.Modules
{
	public class Test : ModuleBase<SocketCommandContext>
	{
		[Command("listroles")]
		public async Task ListRoles()
		{
			var msg = string.Empty;

			foreach (var role in Context.Guild.Roles)
			{
				if (role.Name == "@everyone") continue;

				msg = $"{role.Name}\n{msg} ";
			}

			await Context.Channel.SendMessageAsync(msg);
		}
	}
}
