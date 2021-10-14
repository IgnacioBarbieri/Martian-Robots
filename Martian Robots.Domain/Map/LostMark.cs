using Martian_Robots.Domain.Position;
using System;

namespace Martian_Robots.Domain.Map
{
    public class LostMark : IPlanetMark 
    {
        /// <summary>
        /// Determines the current coordinates
        /// </summary>
        public Coordinates Coordinates { get; private set; }

        public LostMark(Coordinates coordinates)
        {
            if (coordinates == null)
            {
                throw new ArgumentNullException(nameof(coordinates));
            }

            Coordinates = coordinates;
        }
    }
}
