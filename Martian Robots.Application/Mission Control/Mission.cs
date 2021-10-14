using Martian_Robots.Domain;
using System;
using System.Collections.Generic;

namespace Martian_Robots.Application.Mission_Control
{
    public class Mission
    {
        /// <summary>
        /// It Assigns the Current Planet
        /// </summary>
        public IPlanet Planet { get; }

        /// <summary>
        /// Sets the current mission orders
        /// </summary>
        public IList<MissionOrder> Orders { get; } = new List<MissionOrder>();

        public Mission(IPlanet planet)
        {
            if (planet == null)
            {
                throw new ArgumentNullException(nameof(planet));
            }
                
            Planet = planet;
        }
    }
}
