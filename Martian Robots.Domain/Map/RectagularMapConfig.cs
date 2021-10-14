using Martian_Robots.Domain.Position;
using System;

namespace Martian_Robots.Domain.MissionDetails
{
    public class RectangularMapConfig
    {
        /// <summary>
        /// Determines the top right coordinates value
        /// </summary>
        public Coordinates TopRight { get; private set; }

        /// <summary>
        /// Determines the bottom left coordinates value
        /// </summary>
        public Coordinates BottomLeft { get; private set; }

        public RectangularMapConfig(Coordinates bottomLeft, Coordinates topRight)
        {
            if (bottomLeft == null)
            {
                throw new ArgumentNullException(nameof(bottomLeft));
            }
                
            if (topRight == null)
            {
                throw new ArgumentNullException(nameof(topRight));
            }
                
            BottomLeft = bottomLeft;
            TopRight = topRight;
        }

    }
}
