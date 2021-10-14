using Martian_Robots.Domain.Position;

namespace Martian_Robots.Domain
{
    public interface IPlanetMark
    {
        /// <summary>
        /// Gets the current coordinates for the mark
        /// </summary>
        Coordinates Coordinates { get; }
    }
}
