using Martian_Robots.Domain.Position;
using System;

namespace Martian_Robots.Domain
{
    public class Robot
    {        
        /// <summary>
        /// Determines the current position for the robot
        /// </summary>
        public Coordinates Position { get; set; }

        /// <summary>
        /// Determines the current orientation for the robot
        /// </summary>
        public Orientation Orientation { get; }

        /// <summary>
        /// Sets the current status for the robot
        /// </summary>
        public RobotStatus Status { get; set; }

        /// <summary>
        /// Returns true,  if a robot has an active status
        /// </summary>
        public bool IsActive => (Status == RobotStatus.Active);

        /// <summary>
        /// Returns true,  if a robot has an lost status
        /// </summary>
        public bool IsLost => (Status == RobotStatus.Lost);

        public Robot (Coordinates position, Orientation orientation)
        {
            if (position == null)
                throw new ArgumentNullException(nameof(position));

            if (orientation == null)
                throw new ArgumentNullException(nameof(orientation));

            Orientation = orientation;
            Position = position;
            Status = RobotStatus.Inactive;
        }

        /// <summary>
        /// Calculates the next robot coordinates based on the current position and orientation
        /// </summary>
        /// <returns></returns>
        public Coordinates CalculateNextPosition()
        {
            Coordinates next = new Coordinates(Position.X, Position.Y);

            switch (Orientation.Current)
            {
                case Direction.North:
                    next.Y = next.Y + 1;
                    break;
                case Direction.East:
                    next.X = next.X + 1;
                    break;
                case Direction.South:
                    next.Y = next.Y - 1;
                    break;
                case Direction.West:
                    next.X = next.X - 1;
                    break;
            }

            return next;
        }                                         
    }
}
