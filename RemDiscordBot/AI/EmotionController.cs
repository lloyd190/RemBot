using RemDiscordBot.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemDiscordBot.logFiles;
using Discord.WebSocket;

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
        #endregion

        #region properties
        #endregion

        #region methods
        public void RunCommandNoData(string command, SocketUser user)
        {
            throw new NotImplementedException();
        }

        public CommandLog RunCommand(string command, SocketUser user)
        {
            throw new NotImplementedException();
        }

        public CommandLog RunCustomCommand(string command, EmotionalReaction emotionalReaction, SocketUser user)
        {
            throw new NotImplementedException();
        }

        public void CreateNewCommand(string command, EmotionalReaction emotionalReaction, SocketUser user)
        {
            throw new NotImplementedException();
        }

        public EmotionalReaction RetrieveEmotions()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
