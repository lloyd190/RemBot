using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using RemDiscordBot.fileLoader;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;

namespace RemDiscordBot
{
    class Program
    {
        private IServiceProvider _services;
        private DiscordSocketClient _socketClient;
        private CommandService _commands;
        static void Main(string[] args) => new Program().MainAsync(args).GetAwaiter().GetResult();

        public async Task MainAsync(string[] args)
        {
            Properties properties = new Properties(@"C:\Users\Lloyd Kuijs\source\repos\RemDiscordBot\RemDiscordBot\Properties.txt");
            try
            {
                _socketClient = new DiscordSocketClient();
                _socketClient.Log += Log;

                _commands = new CommandService();

                _services = new ServiceCollection()
                    .AddSingleton(_socketClient)
                    .AddSingleton(_commands)
                    .BuildServiceProvider();

                await InstallCommandsAsync();
                await _socketClient.LoginAsync(TokenType.Bot, properties.GetKey("botKey"));
                await _socketClient.StartAsync();

                await Task.Delay(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            await Task.Delay(-1);
        }

        public async Task InstallCommandsAsync()
        {
            //_emotionController.EmotionStatusLog += EmotionStatusLog;
            _socketClient.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {

           var message = messageParam as SocketUserMessage;
            if (message == null) return;       
            //TODO: improve or remove this code, hacky solution for a troll thing for in the chat
            if (message.Content.Contains("~kiss") && message.Content.Contains("@381004257559707648"))
            {
                if (message.Author.Id.ToString() == "173781483075403776" || message.Author.Id.ToString() == "190122834020925441")
                {
                    await message.Channel.SendMessageAsync(String.Format("xx {0} , {1}", message.Author.Username, ":3"));
                    return;
                }
                await message.Channel.SendMessageAsync("Don't touch me!");
                return;
            }
            else if (message.Content.Contains("~kiss"))
            {
                return;
            }

            int argPos = 0;
            if (!message.HasMentionPrefix(_socketClient.CurrentUser, ref argPos) || message.Author.IsBot) return;

            var context = new SocketCommandContext(_socketClient, message);
            var result = await _commands.ExecuteAsync(context, argPos, _services);

            if (!result.IsSuccess)
            {
                await context.Channel.SendMessageAsync(result.ErrorReason);
            }
            else if(result.IsSuccess)
            {
                Console.WriteLine("message received");
            }
        }

        private Task Log(LogMessage message)
            {
                Console.WriteLine(message.ToString());
                return Task.CompletedTask;
            }
    }
}

