using Martian_Robots.Commands;
using Martian_Robots.Domain;
using System;
using System.Collections.Generic;

namespace Martian_Robots.Application.Mission_Control
{
    public class MissionOrder
    {        
       /// <summary>
       /// Sets the current Robot in the mission order
       /// </summary>
        public Robot Robot { get; private set; }

        /// <summary>
        /// Returns the collection of Robot commands used in the mission order
        /// </summary>
        public IEnumerable<IRobotCommand>  Commands { get; }

        public MissionOrder(Robot robot, IEnumerable<IRobotCommand> commands)
        {
            if (robot == null)
            {
                throw new ArgumentNullException(nameof(robot));
            }
                            
            if (commands == null)
            {
                throw new ArgumentNullException(nameof(commands));
            }

            Robot = robot;
            Commands = commands;
        }
    }
}
