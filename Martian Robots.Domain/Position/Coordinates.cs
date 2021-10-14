using System;

namespace Martian_Robots.Domain.Position
{
    public struct Coordinates : IEquatable<Coordinates>
    {
        // The maximum value for any coordinate is 50
        private const int max_value = 50;

        /// <summary>
        /// Determines the X Coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Determines the Y Coordinate
        /// </summary>
        public int Y { get; set; }

        public Coordinates( int x, int y)
        {
            ThrowIfMax(x);
            ThrowIfMax(y);

            X = x;
            Y = y;
        }

        /// <summary>
        ///  Throws an exception if any coordiante value is greater than {max_value}
        /// </summary>
        /// <param name="value"></param>
        public static void ThrowIfMax(int value)
        {
            if (value > max_value)
            {
                throw new ArgumentOutOfRangeException($"The Coordinate can not be more than {max_value}");
            }     
        }
        
        /// <summary>
        /// Defines the equals operator in a comparision sequence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Coordinates a, Coordinates b) => a.Equals(b);

        /// <summary>
        /// Defines the non equals operator in a comparision sequence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Coordinates a, Coordinates b) => !a.Equals(b);

        /// <summary>
        /// Determines when two instances of coordinate objects are equals
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool Equals(Coordinates instance) => X.Equals(instance.X) && Y.Equals(instance.Y);                        

        /// <summary>
        /// Defines the hashcode value for dictionary hashing operations
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();                    
        
        public override bool Equals(object obj)
        {
            if (obj is Coordinates instance)
                return Equals(instance);
            else
                return false;
        }
    }
}
