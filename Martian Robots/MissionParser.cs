using Martian_Robots.Commands;
using Martian_Robots.Domain.Position;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Martian_Robots.Parsers
{
    public class MissionParser : IParser
    {
        // All instruction strings will be less than 100 characters in length.
        const int MaxInstructionLength = 99;

        // All commands table dictionary
        private readonly IDictionary<char, Type> _commandList = new Dictionary<char, Type>()
        {
             { 'L', typeof(TurnLeftCommand) }
            ,{ 'R', typeof(TurnRightCommand) }
            ,{ 'F', typeof(ForwardCommand) }
        };

        /// <summary>
        /// It Converts a sequence of robot positions into a pair of Coordinates and Orientation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public (Coordinates position, Orientation orientation) ParsePosition(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
                
            // Defines the input position expression
            const string expression = @"^(\d*)\s(\d*)\s(\w)$";
            var match = Regex.Match(value, expression, RegexOptions.IgnoreCase);

            if (!match.Success || match.Groups.Count != 4)
            {
                throw new ArgumentException($"'{value}' is not valid.");
            }
                
            // Parses x and y values from match pattern
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            Direction direction = match.Groups[3].Value.ToDirection();

            Coordinates position = new Coordinates(x, y);
            Orientation orientation = new Orientation(direction);

            return (position, orientation);
        }

        /// <summary>
        /// It Converts a sequence of robot instructions into a list of Robot commands
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<IRobotCommand> ParseInstructions(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
                
            if (value.Length > MaxInstructionLength)
            {
                throw new ArgumentException($"Robot instructions cannot exceed length of {MaxInstructionLength}.");
            }
                
            IList<IRobotCommand> commands = new List<IRobotCommand>();
            
            foreach (char instruction in value.ToUpper())
            {
                if (!_commandList.ContainsKey(instruction))
                {
                    throw new ArgumentException($"Invalid command value{instruction}");
                }
                                    
                // It creates the robot command based into the input instruction, using the table dictionary
                var command = (IRobotCommand)Activator.CreateInstance(_commandList[instruction]);
                commands.Add(command);                
            }

            return commands;
        }
    }
}
