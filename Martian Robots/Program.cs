using Martian_Robots.Application.Mission_Control;
using Martian_Robots.Builders;
using Martian_Robots.Domain;
using Martian_Robots.Domain.MissionDetails;
using Martian_Robots.Domain.Position;
using Martian_Robots.Parsers;
using System;

namespace Martian_Robots
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("# Mars Mission Starting Up...");
            Console.WriteLine();
            Console.WriteLine("# Discovering Mars...");
            Console.WriteLine();

            // Mars Planet Initial Configuration
            const int width = 5;
            const int height = 3;
            Coordinates marsDimension = new Coordinates(width, height);
            RectangularMapConfig marsConfig = new RectangularMapConfig(new Coordinates(0, 0), marsDimension);
            RectangularMap mars = new RectangularMap(marsConfig);

            Console.WriteLine($"  Origin: {mars.BottomLeft.X} {mars.BottomLeft.Y}");
            Console.WriteLine($"  Top: {mars.TopRight.X} {mars.TopRight.Y}");
            Console.WriteLine();
            Console.WriteLine("# Reading Mars Instructions...");
            Console.WriteLine();

            // It Creates the Mission Input Data Parser
            MissionParser parser = new MissionParser();
            
            // It Gets the mission using the input data instructions
            MissionBuilder builder = new MissionBuilder(parser);
            builder.AssignPlanet(mars);
            builder.AddRobotInstruction("1 1 E", "RFRFRFRF");
            builder.AddRobotInstruction("3 2 N", "FRRFLLFFRRFLL");            
            builder.AddRobotInstruction("0 3 W", "LLFFFRFLFL");                        
            Mission mission = builder.GetMission();
            
            Console.WriteLine("# Processing Mission Orders...");
            Console.WriteLine();

            // It Manages the Orders in the Mars Mission Control Center
            MissionControl missionControl = new MissionControl();
            missionControl.Manage(mission);

            // Finally, it returns the Mars Mission Status
            string missionStatus = missionControl.GetMissionStatus();
            
            Console.WriteLine("# --- Mission Status Report ---");
            Console.WriteLine();
            Console.WriteLine(missionStatus);
            Console.WriteLine("# -----------------------------");

            Console.WriteLine();
            Console.WriteLine("-> Press any key to quit. <-");
            Console.ReadKey(true);
        }
    }
}
