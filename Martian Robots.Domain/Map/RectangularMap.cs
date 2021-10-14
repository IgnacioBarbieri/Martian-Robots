using Martian_Robots.Domain.MissionDetails;
using Martian_Robots.Domain.Position;
using System;
using System.Linq;
using System.Collections.Generic;
using Martian_Robots.Domain.Map;

namespace Martian_Robots.Domain
{
    public class RectangularMap : IPlanet
    {
        /// <summary>
        /// Determines the top right coordinates value
        /// </summary>
        public Coordinates TopRight { get; private set; }

        /// <summary>
        /// Determines the bottom left coordinates value
        /// </summary>
        public Coordinates BottomLeft { get; private set; }

        // Collection that contains all the planet marks on a position
        private readonly IDictionary<Coordinates, List<IPlanetMark>> Marks = new Dictionary<Coordinates, List<IPlanetMark>>();

        public RectangularMap(RectangularMapConfig configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
                
            BottomLeft = configuration.BottomLeft;
            TopRight = configuration.TopRight;
        }

        /// <summary>
        /// Creates a new planet mark on the defined position
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="mark"></param>
        public void AddMark(Coordinates coordinates, IPlanetMark mark)
        {
            if (coordinates == null)
            {
                throw new ArgumentNullException(nameof(coordinates));
            }

            if (mark == null)
            {
                throw new ArgumentNullException(nameof(mark));
            }

            if (!Marks.ContainsKey(coordinates))
            {
                Marks.Add(coordinates, new List<IPlanetMark>());
            }

            Marks[coordinates].Add(mark);
        }

        /// <summary>
        /// Verifies if on the position has any lost mark
        /// </summary>
        /// <param name="position"></param>
        /// <param name="nextPosition"></param>
        /// <returns></returns>
        public bool HasLostMarkInPosition(Coordinates position, Coordinates nextPosition)
        {
            bool result = false;
            
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (nextPosition == null)
            {
                throw new ArgumentNullException(nameof(nextPosition));
            }

            if (Marks.ContainsKey(position))
            {
                result = Marks[position]
                                .OfType<LostMark>()
                                .Any(mark => mark.Coordinates == nextPosition);
            }

            return result;
        }

        /// <summary>
        /// Determines if a position is in planet boundaries
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public bool IsInBoundaries(Coordinates coordinates)
        {
            if (coordinates == null)
            {
                throw new ArgumentNullException(nameof(coordinates));
            }
                
            return (coordinates.X >= BottomLeft.X 
                  && coordinates.X <= TopRight.X
                  && coordinates.Y >= BottomLeft.Y 
                  && coordinates.Y <= TopRight.Y);
        }
    }
}
