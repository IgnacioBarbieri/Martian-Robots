using Martian_Robots.Domain;

namespace Martian_Robots.Commands
{
    public class TurnLeftCommand : IRobotCommand
    {
        public void Execute(Robot robot, IPlanet planet)
        {
            // If the robot is not active, it returns
            if (!robot.IsActive) 
            {
                return;
            }

            // Changes the orientation to the robot and remains on the current position
            robot.Orientation.Turn(-1);            
        }
    }
}
