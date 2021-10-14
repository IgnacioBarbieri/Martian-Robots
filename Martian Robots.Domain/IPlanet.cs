using Martian_Robots.Domain.Position;

namespace Martian_Robots.Domain
{
    public interface IPlanet
    {
        /// <summary>
        /// Determines if a position is in planet boundaries
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        bool IsInBoundaries(Coordinates coordinate);

        /// <summary>
        /// Creates a new planet mark on the defined position
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="mark"></param>
        void AddMark(Coordinates coordinates, IPlanetMark mark);

        /// <summary>
        /// Verifies if on the position has any lost mark
        /// </summary>
        /// <param name="position"></param>
        /// <param name="nextPosition"></param>
        /// <returns></returns>
        bool HasLostMarkInPosition(Coordinates position, Coordinates nextPosition);
    }
}