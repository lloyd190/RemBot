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
       // private readonly EmotionController _emotionController;
        //Can't import the EmotionController into the IEmotionController, not sure how to change this, the api does not pick up on it.
        public CommunicationModule(int emotionController)
        {
            emotionController = emotionController;
        }
        [Command("hello")]
        public async Task SayHello()
        {
            await ReplyAsync("Humph, hello");
        }
    }
}
