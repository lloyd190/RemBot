using RemDiscordBot.AI;
using RemDiscordBot.logFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemDiscordBot.interfaces
{
    interface IEmotionController
    {
        /// <summary>
        /// delegate event for EmotionStatus Updates (call when the EMOTION CHANGES)
        /// </summary>
        event Func<EmotionLog> EmotionStatus;

        /// <summary>
        /// Current mood of the character
        /// </summary>
        Emotion Mood { get; set; }

        /// <summary>
        /// Offends the character by a specified amount.
        /// </summary>
        /// <param name="amount">amount of offensive points</param>
        void OffendCharacter(double amount);
        /// <summary>
        /// Offends the character by a base amount.
        /// </summary>
        /// <param name="amount">amount of offensive points</param>
        void OffendCharacter();
        /// <summary>
        /// Compliments the character by a specified amount.
        /// </summary>
        /// <param name="amount">amount of offensive points</param>
        void ComplimentCharacter(double amount);
        /// <summary>
        /// Compliments the character by a base amount.
        /// </summary>
        void ComplimentCharacter();


    }
}
