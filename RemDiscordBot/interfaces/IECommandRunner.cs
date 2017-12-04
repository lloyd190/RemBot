using Discord;
using Discord.WebSocket;
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
        void RunCommandNoData(string command, SocketUser socketUser);

        /// <summary>
        /// Runs a command with return data
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        CommandLog RunCommand(string command, SocketUser socketUser);

        /// <summary>
        /// runs a command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="emotionalReaction"></param>
        /// <returns></returns>
        CommandLog RunCustomCommand(string command, EmotionalReaction emotionalReaction, SocketUser socketUser);
        /// <summary>
        /// permanently creates a new command
        /// </summary>
        /// <param name="command">command that will comes after the @mention</param>
        /// <param name="emotionalReaction">emotional</param>
        void CreateNewCommand(string command, EmotionalReaction emotionalReaction, SocketUser socketUser);

        /// <summary>
        /// retrieves all currently running emotion statuses
        /// </summary>
        /// <remarks>
        /// A emotion timer might end right when it got retrieved during the processing it 
        /// might not be true that the emotion is still there anymore
        /// </remarks>
        /// <returns>currently running Emotions</returns>
        EmotionalReaction RetrieveEmotions();


    }
}
