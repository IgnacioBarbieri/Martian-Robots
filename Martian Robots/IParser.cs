using Martian_Robots.Commands;
using Martian_Robots.Domain.Position;
using System.Collections.Generic;

namespace Martian_Robots
{
    public interface IParser
    {
        /// <summary>
        /// It Converts a sequence of robot positions into a pair of Coordinates and Orientation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        (Coordinates position, Orientation orientation) ParsePosition(string value);

        /// <summary>
        /// It Converts a sequence of robot instructions into a list of Robot commands
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IEnumerable<IRobotCommand> ParseInstructions(string value);
    }
}