using System;
using System.Collections.Generic;
using System.IO;

namespace Aoc_days
{
    class Day2
    {

        public void Answer()
        {
            Console.WriteLine("Day 2!");

            var finalpostion = FollowDirections(ReadDirectionsFromFile("directions.txt")); 

            foreach(var item in finalpostion)
            {
                Console.WriteLine("direction, " + item.Key + " - value, " + item.Value);
            }
            Console.WriteLine("final position " + finalpostion["horizontal"] * finalpostion["vertical"]);

            var newfinalpostion = NewFollowDirections(ReadDirectionsFromFile("directions.txt"));
            Console.WriteLine('\n');
            Console.WriteLine("new directions");

            foreach (var item in newfinalpostion)
            {
                Console.WriteLine("direction, " + item.Key + " - value, " + item.Value);
            }
            Console.WriteLine("final position " + newfinalpostion["horizontal"] * newfinalpostion["depth"]);

        }

        private Dictionary<string, int> Directions()
        {
            return new Dictionary<string, int>() { { "horizontal", 0 }, { "vertical", 0 }};
        }

        private Dictionary<string, int> NewDirections()
        {
            return new Dictionary<string, int>() { { "horizontal", 0 }, { "depth", 0 }, { "aim", 0 } };
        }

        private Dictionary<string, int> NewFollowDirections(string[] directions)
        {
            var direction = NewDirections(); // starting position

            foreach (var line in directions)
            {
                string[] directionandvalue = line.Split(' ');
                if (directionandvalue[0].Contains("forward"))
                {
                    direction["horizontal"] = direction["horizontal"] + Convert.ToInt32(directionandvalue[1]);
                    direction["depth"] = direction["depth"] + direction["aim"] * Convert.ToInt32(directionandvalue[1]);
                }
                else if (directionandvalue[0].Contains("up"))
                {
                    direction["aim"] = direction["aim"] - Convert.ToInt32(directionandvalue[1]);
                }
                else { direction["aim"] = direction["aim"] + Convert.ToInt32(directionandvalue[1]); }

                
            }

            return direction;
        }

        private Dictionary<string, int> FollowDirections(string[] directions)
        {
            var direction = Directions(); // starting position

            foreach (var line in directions)
            {
                string[] directionandvalue = line.Split(' ');
                if (directionandvalue[0].Contains("forward"))
                    {
                    direction["horizontal"] = direction["horizontal"] + Convert.ToInt32(directionandvalue[1]);
                }
                else if(directionandvalue[0].Contains("up"))
                    {
                    direction["vertical"] = direction["vertical"] - Convert.ToInt32(directionandvalue[1]);
                }
                else { direction["vertical"] = direction["vertical"] + Convert.ToInt32(directionandvalue[1]); }

            }

            return direction;
        }

        private string[] ReadDirectionsFromFile(string name)
        {
            string[] directions = File.ReadAllLines("c:\\ed\\" + name);

            return directions;
        }
            
    }
}




    


