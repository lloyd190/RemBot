﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemDiscordBot.AI
{
    public abstract class Emotion
    {
        public bool TimerIsRunning { get; }
        public bool TimerEnded  { get; }
    }
}
