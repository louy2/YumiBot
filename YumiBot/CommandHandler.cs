﻿using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using System.Reflection;

namespace YumiBot
{
	public class CommandHandler
	{
		DiscordSocketClient _client;
		CommandService _service;

		public async Task InitializeAsync(DiscordSocketClient client)
		{
			_client = client;
			_service = new CommandService();
			await _service.AddModulesAsync(Assembly.GetEntryAssembly());
			_client.MessageReceived += HandleCommandAsync;
		}

		private async Task HandleCommandAsync(SocketMessage s)
		{
			if (!(s is SocketUserMessage msg)) return;
			var context = new SocketCommandContext(_client, msg);
			if (context.User.IsBot) return;

			var argPos = 0;
			if(msg.HasStringPrefix(Config.Bot.DefaultCmdPrefix, ref argPos) 
			   || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
			{
				var result = await _service.ExecuteAsync(context, argPos);
				if(!result.IsSuccess && result.Error != CommandError.UnknownCommand)
				{
					Console.WriteLine(result.ErrorReason);
				}
			}
		}
	}
}
