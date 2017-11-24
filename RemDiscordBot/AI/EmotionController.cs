using RemDiscordBot.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemDiscordBot.logFiles;

namespace RemDiscordBot.AI
{
    public enum Emotion { Happy, Sad, Neutral }
    public class EmotionController : IEmotionController
    {
        public event Func<EmotionLog> EmotionStatus;

        #region members
        private Emotion Emotion = Emotion.Neutral;
        #endregion

        public Emotion Mood
        {
            get
            {
                return Emotion;
            }

            set
            {
                if (Emotion != value)
                {
                    Emotion = value;
                    EmotionStatus.Method.EventHandler temp = MyEvent;
                    if (temp != null)
                    {
                        temp();
                    }
                }

            }
        }

        public void ComplimentCharacter(double amount)
        {
            throw new NotImplementedException();
        }

        public void ComplimentCharacter()
        {
            throw new NotImplementedException();
        }

        public void OffendCharacter(double amount)
        {
            throw new NotImplementedException();
        }

        public void OffendCharacter()
        {
            throw new NotImplementedException();
        }
    }
}
