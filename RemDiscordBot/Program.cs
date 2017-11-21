using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemDiscordBot.Discord_Communication;
using Discord.Commands;

namespace RemDiscordBot
{
    class Program
    {
        //TODO: move tokens and other server sided variables to a separate file later on
        private readonly String _token = "MzgxMDA0MjU3NTU5NzA3NjQ4.DPBsvw.kmbEujIW2IsvMXXOGJcJkaPHj_0";
        private DiscordSocketClient _socketClient;
        static void Main(string[] args) => new Program().MainAsync(args).GetAwaiter().GetResult();

        public async Task MainAsync(string[] args)
        {
            _socketClient = new DiscordSocketClient();
            _socketClient.Log += Log;

            await _socketClient.LoginAsync(TokenType.Bot, _token);
            await  _socketClient.StartAsync();
            Console.WriteLine("This probly doesnt work this way");
            await Task.Delay(-1);

        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}

