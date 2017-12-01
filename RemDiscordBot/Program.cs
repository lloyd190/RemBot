using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using RemDiscordBot.AI;
using RemDiscordBot.logFiles;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
namespace RemDiscordBot
{
    class Program
    {
        //TODO: move tokens and other server sided variables to a separate file later on
        private readonly String _token = "MzgxMDA0MjU3NTU5NzA3NjQ4.DPBsvw.kmbEujIW2IsvMXXOGJcJkaPHj_0";
        private IServiceProvider _services;
        private DiscordSocketClient _socketClient;
        private CommandService _commands;
        private EmotionController _emotionController;
        static void Main(string[] args) => new Program().MainAsync(args).GetAwaiter().GetResult();

        public async Task MainAsync(string[] args)
        {
            try
            {
                _emotionController = new EmotionController(20, 20);
                _emotionController.EmotionStatusLog += EmotionStatusLog;
                _socketClient = new DiscordSocketClient();
                _socketClient.Log += Log;

                _commands = new CommandService();

                _services = new ServiceCollection()
                    .AddSingleton(_socketClient)
                    .AddSingleton(_commands)
                    .AddSingleton(_emotionController)
                    .BuildServiceProvider();


                await InstallCommandsAsync();
                await _socketClient.LoginAsync(TokenType.Bot, _token);
                await _socketClient.StartAsync();

                await Task.Delay(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

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

            if (message.Content.Contains("~kiss") && message.Author.Username != "Lloyd")
            {
                await message.Channel.SendMessageAsync("Don't touch me!");
                return;
            }
            else if (message.Content.Contains("~kiss") && message.Author.Username == "Lloyd")
            {
                await message.Channel.SendMessageAsync(":3");
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
        //TODO: maybe there are some problems with the timing of the emotion updates. 
        //Check if quick messaging doesn't Skip the previous emotion update.
        private Task EmotionStatusLog(EmotionLog status)
        {
            Console.WriteLine(status.ToString());

            return Task.CompletedTask;
        }
    }
}

