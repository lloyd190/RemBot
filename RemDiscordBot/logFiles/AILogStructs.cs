using RemDiscordBot.AI;

namespace RemDiscordBot.logFiles
{
    /// <summary>
    /// for packaging data prints to the console for the EmotionController.
    /// </summary>
    public struct EmotionLog
    {//add where needed
        private readonly Emotion emotion;

        public EmotionLog(Emotion emotion)
        {
            this.emotion = emotion;
        }
        public override string ToString()
        {
            return emotion.ToString();
        }
    }
}