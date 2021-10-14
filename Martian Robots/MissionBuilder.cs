using Martian_Robots.Application.Mission_Control;
using Martian_Robots.Domain;
using System;
using System.Collections.Generic;

namespace Martian_Robots.Builders
{
    public class MissionBuilder
    {
        /// <summary>
        /// It Defines the current planet to be discovering in the mission
        /// </summary>
        private IPlanet Planet { get; set; }

        /// <summary>
        /// Returns the collection of the robot instructions
        /// </summary>
        private IDictionary<String, String> Instructions { get; } = new Dictionary<String, String>();

        // Parser reference
        private readonly IParser _parser;

        public MissionBuilder (IParser parser)
        {
            if (parser == null)
            {
                throw new ArgumentException(nameof(parser));
            }
                
            _parser = parser;
        }
        
        /// <summary>
        /// Sets the planet for the mission builder.
        /// </summary>
        /// <param name="planet"></param>
        public void AssignPlanet(IPlanet planet)
        {
            if (planet == null)
            {
                throw new ArgumentNullException(nameof(planet));
            }

            Planet = planet;
        }

        /// <summary>
        /// It adds a new robot instruction using the position and the command string.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="commands"></param>
        public void AddRobotInstruction(string position, string commands)
        {
            if (String.IsNullOrEmpty(position))
            {
                throw new ArgumentNullException(nameof(position));
            }
                
            if (String.IsNullOrEmpty(commands))
            {
                throw new ArgumentNullException(nameof(commands));
            }
                
            if (Instructions.ContainsKey(position))
            {
                throw new ArgumentException("Is not possible to define a new robot instruction for an already existing position");
            }

            Instructions.Add(position, commands);
        }

        /// <summary>
        /// It Creates the mission and the robot orders
        /// </summary>
        /// <returns></returns>
        public Mission GetMission()
        {          
            Mission mission = new Mission(Planet);

            foreach (var instruction in Instructions)
            {
                var (position, orientation) = _parser.ParsePosition(instruction.Key);
                var commands = _parser.ParseInstructions(instruction.Value);

                Robot robot = new Robot(position, orientation);

                MissionOrder order = new MissionOrder(robot, commands);
                mission.Orders.Add(order);
            }
            
            return mission;
        }      
    }
}
