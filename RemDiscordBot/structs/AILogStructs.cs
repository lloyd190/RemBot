using RemDiscordBot.AI;

namespace RemDiscordBot.logFiles
{//TODO: Check if structs are needed, you don't want to pass objects into a struct. You might be able to pass data of the objects to the struct and store that, IF NOT USE CLASSES PLEASE.
    /// <summary>
    /// Logging struct for packaging data to be used as optional retrievable data from the EmotionController API.
    /// </summary>
    public struct EmotionLog
    {//add where needed
        private readonly Emotion _emotion;

        public EmotionLog(Emotion emotion)
        {
            this._emotion = emotion;
        }
        public override string ToString()
        {
            return _emotion.ToString();
        }
    }
    public struct CommandLog
    {
        private readonly EmotionalReaction _EmotionalReaction;
        public EmotionalReaction EmotionalReaction
        {
            get
            {
                return _EmotionalReaction;
            }
        }

        public CommandLog(EmotionalReaction emotionalReaction)
        {
            _EmotionalReaction = emotionalReaction;
        }
        public override string ToString()
        {
            return "Struct not defined yet";
        }
    }
}