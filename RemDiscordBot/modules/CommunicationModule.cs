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
       public CommunicationModule()
        {
        }
        [Command("hello")]
        public async Task SayHello()
        {
            await ReplyAsync("Humph, hello");
        }
    }
}
