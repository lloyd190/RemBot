using RemDiscordBot.AI;
using RemDiscordBot.logFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemDiscordBot.interfaces
{
    /// <summary>
    /// Interface for classes that have to run EmotionCommands, 
    /// depending on the time taken to execute the commands you might want to implement the methods as ASYNC.
    /// </summary>
    public interface IECommandRunner
    {
        /// <summary>
        /// EmotionStatus updates
        /// </summary>
        event Func<EmotionLog, Task> EmotionLog;

        /// <summary>
        /// Runs a command with no return data
        /// </summary>
        /// <param name="command">command to create reaction for</param>
        void RunCommandNoData(string command);

        /// <summary>
        /// Runs a command with return data for testing/
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        CommandLog RunCommand(string command);




    }
}
