using Martian_Robots.Domain;
using Martian_Robots.Domain.Map;
using Martian_Robots.Domain.Position;

namespace Martian_Robots.Commands
{
    public class ForwardCommand : IRobotCommand
    {
        public void Execute(Robot robot, IPlanet planet)
        {
            // If the robot is not active, it returns
            if (!robot.IsActive)
            {
                return;
            }

            // Calculates the next position using the current orientation of the robot
            Coordinates nextPostion = robot.CalculateNextPosition();

            // If exists a lost mark at the robot coordinates, it returns
            if (planet.HasLostMarkInPosition(robot.Position, nextPostion))
            {
                return;
            }

            // If the calculated next position is out of boundaries, a lost mark is created in the planet
            if (!planet.IsInBoundaries(nextPostion))
            {
                robot.Status = RobotStatus.Lost;

                LostMark mark = new LostMark(nextPostion);
                planet.AddMark(robot.Position, mark);

                return;
            }
                        
            // Finally, it assigns the new position to the robot
            robot.Position = nextPostion;           
        }
    }
}
