using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemDiscordBot.interfaces
{
    /// <summary>
    /// interface for classes which have to implement their own timer
    /// </summary>
    public interface ITimer
    {
        void InitiateTimer(double time);
        void StopTimer();

    }
}
