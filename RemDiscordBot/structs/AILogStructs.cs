using RemDiscordBot.AI;

namespace RemDiscordBot.logFiles
{
    /// <summary>
    /// Logging struct for packaging data to be used as optional retrievable data from the EmotionController API.
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