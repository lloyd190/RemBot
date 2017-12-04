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
        [Command("checkmood")]
        public async Task SayHello()
        {
            
            switch (_emotionController.Mood)
            {
                case Emotion.Happy:
                    await ReplyAsync("Happy");
                    break;
                case Emotion.Sad:
                    await ReplyAsync("Sad");
                    break;
                case Emotion.Neutral:
                    await ReplyAsync("Neutral");
                    break;
                case Emotion.Angry:
                    await ReplyAsync("Angry");
                    break;
                default:
                    await ReplyAsync("Default case");
                    break;
            }
        }

        [Command("changemood")]
        public async Task changemood([Remainder]string mood)
        {
            switch (mood.ToLower())
            {
                case "happy":
                    _emotionController.Mood = Emotion.Happy;
                    await ReplyAsync("happy");
                    break;
                case "sad":
                    _emotionController.Mood = Emotion.Sad;
                    await ReplyAsync("sad");
                    break;
                case "nuetral":
                    _emotionController.Mood = Emotion.Neutral;
                    await ReplyAsync("neutral");
                    break;
                case "angry":
                    _emotionController.Mood = Emotion.Angry;
                    await ReplyAsync("angry");
                    break;
                default:
                    await ReplyAsync("I can't feel this emotion at this moment");
                    break;
            }
}

    }
}
