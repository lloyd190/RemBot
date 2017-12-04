using RemDiscordBot.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemDiscordBot.logFiles;

namespace RemDiscordBot.AI
{
    public class EmotionController : IECommandRunner
    {
        public event Func<EmotionLog, Task> EmotionLog;

        #region members
        #endregion

        #region constructors
        public EmotionController()
        {
        }

        public void RunCommand(string command)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region properties
        #endregion

        #region methods
        #endregion
    }
}
