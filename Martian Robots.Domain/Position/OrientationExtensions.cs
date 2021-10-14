using System;

namespace Martian_Robots.Domain.Position
{
    public static class OrientationExtensions
    {
        public static Direction ToDirection(this string source)
        {
            if (String.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException(nameof(source));
            }
                            
            switch(source.ToUpper())
            {
                case "N":
                    return Direction.North;
                case "E":
                    return Direction.East; 
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                default:
                    throw new ArgumentException($"Invalid orientation {source}");
            }           
        }

        public static char ToChar(this Direction source)
        {
            switch (source)
            {
                case Direction.North:
                    return 'N';
                case Direction.East:
                    return 'E';
                case Direction.South:
                    return 'S';
                case Direction.West:
                    return 'W';
                default:
                    throw new ArgumentException($"Invalid orientation {source}");
            }
        }
    }
}
