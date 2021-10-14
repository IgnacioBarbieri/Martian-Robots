using Martian_Robots.Domain;
using Martian_Robots.Domain.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Martian_Robots.Application.Mission_Control
{
    public class MissionControl
    {
        /// <summary>
        /// Sets the Current Mission
        /// </summary>
       private Mission CurrentMission { get; set; }      

        /// <summary>
        /// It Manages the current mission, using the robot commands to let interact with him
        /// </summary>
        /// <param name="mission"></param>
       public void Manage(Mission mission)
       {
            if (mission == null)
            {
                throw new ArgumentNullException(nameof(mission));
            }

            // Sets the current mission
            CurrentMission = mission;

            // Manages the mission orders and executes the robot commands
            foreach (MissionOrder order in CurrentMission.Orders)
            {
                order.Robot.Status = RobotStatus.Active;

                order.Commands
                    .ToList()
                    .ForEach(command => command.Execute(order.Robot, mission.Planet));

                if (order.Robot.IsActive)
                {
                    order.Robot.Status = RobotStatus.Inactive;
                }                
            }
       }

        /// <summary>
        /// Gets the final status report for all mission robots
        /// </summary>
        /// <returns></returns>
        public string GetMissionStatus()
        {
            IEnumerable<Robot> robots =
                CurrentMission?.Orders.Select(order => order.Robot);

            StringBuilder result = new StringBuilder();

            foreach (Robot robot in robots)
            {
                result.Append(' ')
                       .Append(robot.Position.X)
                       .Append(' ')
                       .Append(robot.Position.Y)
                       .Append(' ')
                       .Append(robot.Orientation.Current.ToChar());
               
                if (robot.IsLost)
                {
                    result.Append(' ');
                    result.Append("LOST");
                }

                result.AppendLine();
            }
            
            return result.ToString();  
        }
    }
}
