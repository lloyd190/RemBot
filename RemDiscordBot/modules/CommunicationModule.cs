using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemDiscordBot.modules
{
    public class CommunicationModule : ModuleBase<SocketCommandContext>
    {
        [Command("hello")]
        [Summary("just saying hello")]
        public async Task sayHello()
        {
            await Context.Channel.SendMessageAsync("hi there, this is my first command ever executed!");
        }
        [Command("hello")]
        [Summary("just saying hello")]
    }
}
