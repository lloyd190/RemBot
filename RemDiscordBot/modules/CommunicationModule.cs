using Discord.Commands;
using RemDiscordBot.AI;
using RemDiscordBot.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemDiscordBot.modules
{
    public class CommunicationModule : ModuleBase<SocketCommandContext>
    {
        public readonly IEmotionController _emotionController;
        //Can't import the EmotionController into the IEmotionController, not sure how to change this, the api does not pick up on it.
        public CommunicationModule(EmotionController emotionController)
        {
            _emotionController = emotionController;
        }
        [Command("hello")]
        public async Task SayHello()
        {
            _emotionController.Mood = Emotion.Sad;
            if (_emotionController.Mood == Emotion.Happy)
            {
                await ReplyAsync("hello there, I am quite happy today ^.^");
                return;
            }
            await ReplyAsync("Humph, hello");
        }
    }
}
