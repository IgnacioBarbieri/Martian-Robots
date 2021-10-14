using Martian_Robots.Domain;

namespace Martian_Robots.Commands
{
    public interface IRobotCommand
    {
        /// <summary>
        /// Defines a common interface for executing robot commands
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="planet"></param>
        void Execute(Robot robot, IPlanet planet);
    }
}
