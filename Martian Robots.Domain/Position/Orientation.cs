using System;
using System.Linq;

namespace Martian_Robots.Domain.Position
{
    public class Orientation
    {
        /// <summary>
        /// Determines the current orientation
        /// </summary>
        public Direction Current { get; private set; }
        
        public Orientation(Direction direction)
        {
            Current = direction;
        }

        /// <summary>
        /// Changes the current orientation, based on the turn value
        /// </summary>
        /// <param name="value"></param>
        public void Turn(int value)
        {
            if (value != -1 && value != 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
                            
            Direction current;
            Direction[]_directions = (Direction[])Enum.GetValues(typeof(Direction));

            if ((Current + value) < 0)
            {
                current = _directions.Last();
            }                
            else
            {
                int index = ((int)(Current + value)) % _directions.Length;
                current = _directions[index];
            }

            Current  = current;
        }
    }
}
