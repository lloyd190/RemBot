using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace RemDiscordBot.Discord_Communication
{
    public class CommunicationComponent : ModuleBase<SocketCommandContext>
    {
        public CommunicationComponent()
        {

        }

        [Command("Rem!")]
        public async Task Test()
        {
           await Context.Channel.SendMessageAsync("https://pa1.narvii.com/6160/2ce86b515797bee8f9e84328648550a616084922_hq.gif");
        }
    }
}
