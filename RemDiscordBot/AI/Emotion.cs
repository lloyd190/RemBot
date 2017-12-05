using RemDiscordBot.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RemDiscordBot.AI
{
    public abstract class Emotion : Timer
    {
        private double _emotionSeverity;
        private string _key;

        public Emotion(double interval) : base(interval)
        {
        }
    }
}