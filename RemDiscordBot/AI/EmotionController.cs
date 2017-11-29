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
        public event Func<EmotionLog, Task> EmotionStatusLog;

        #region members
        private double _baseComplimentValue;
        private double _baseOffenseValue;
        private Emotion _Emotion = Emotion.Neutral;
        private double _EmotionMeter = 50;
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
            if (amount <= _EmotionMeter && !(_EmotionMeter + amount > 100))
            {
                _EmotionMeter += amount;
            }
        }

        public void ComplimentCharacter()
        {
            if (!(_EmotionMeter + _baseComplimentValue > 100))
            {
                _EmotionMeter += _baseComplimentValue;
            }
        }

        public void OffendCharacter(double amount)
        {
            if (!(_EmotionMeter + _baseOffenseValue > 100))
            {
                _EmotionMeter -= amount;
            }
        }

        public void OffendCharacter()
        {
            if (!(_EmotionMeter + _baseOffenseValue > 100))
            {
                _EmotionMeter -= _baseOffenseValue;
            }
        }
        #endregion
    }
}
