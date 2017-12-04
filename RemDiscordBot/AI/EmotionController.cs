using RemDiscordBot.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemDiscordBot.logFiles;

namespace RemDiscordBot.AI
{
    public enum Emotion { Happy, Sad, Neutral,Angry }
    public class EmotionController : IEmotionController
    {
        public event Func<EmotionLog, Task> EmotionStatusLog;

        #region members
        private double _baseComplimentValue;
        private double _baseOffenseValue;
        private Emotion _Emotion = Emotion.Neutral;
        #endregion

        #region constructors
        public EmotionController(double baseComplimentValue, double baseOffenseValue)
        {
            if (baseComplimentValue <= 0 || baseOffenseValue <= 0)
            {
                throw new ArgumentException("Arguments are not within the wanted range," +
                    " the EmotionMeter will not have been influenced by these values or would have been influenced negatively");
            }
            _baseComplimentValue = baseComplimentValue;
            _baseOffenseValue = baseOffenseValue;
        }
        #endregion

        #region properties
        public Emotion Mood
        {
            get
            {
                return _Emotion;
            }

            set
            {
                if (_Emotion != value)
                {
                    _Emotion = value;
                    EmotionStatusLog(new EmotionLog(value));
                }

            }
        }
        #endregion

        #region methods
        public void ComplimentCharacter(double amount)
        {
        }

        public void ComplimentCharacter()
        {
        }

        public void OffendCharacter(double amount)
        {
        }

        public void OffendCharacter()
        {
        }

        private void CalculateEmotion()
        {

        }
        #endregion
    }
}
