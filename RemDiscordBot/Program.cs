using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
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
        static void Main(string[] args) => new Program().MainAsync(args).GetAwaiter().GetResult();

        public async Task MainAsync(string[] args)
        {
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
            _socketClient.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            int argPos = 0;
            if (!message.HasMentionPrefix(_socketClient.CurrentUser, ref argPos)) return;

            var context = new SocketCommandContext(_socketClient, message);
            var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess)
            {
                await context.Channel.SendMessageAsync("Sorry? that doesn't make sense to me.");
            }
            if(result.IsSuccess)
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

