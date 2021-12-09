using System;
using System.IO;

namespace Aoc_days
{
    class Day1
    {
        public void Answer()
        {
            var depths = ReadDepthsFromFile();

            Console.WriteLine("simple increases - " + CountIncreasesInDepth(depths));
            Console.WriteLine("window increases - " + CountIncreasesInDepthSlidingWindow(depths));
        }

        private int[] ReadDepthsFromFile()
        {
            string[] depthsAsStrings = File.ReadAllLines("c:\\ed\\depths.txt");
            
            // lets convert it to numbers now, once.
            int[] depths = new int[depthsAsStrings.Length];

            for (int i = 0; i < depths.Length; i++)
            {
                depths[i] = int.Parse(depthsAsStrings[i]);
            }
            return depths;
        }

        private int CountIncreasesInDepth(int[] depths)
        {
            int count = 0;

            for (int i =0; i< depths.Length -1; i++)
            {
                if (depths[i + 1] > depths[i]) count++; 
            }

            return count;
        }

        private int CountIncreasesInDepthSlidingWindow(int[] depths)
        {
            int count = 0;

            for (int i = 0; i < depths.Length - 3; i++)
            {
                if (SumOfWindow(depths,i + 1) > SumOfWindow(depths, i)) count++;
            }

            return count;
        }

        private int SumOfWindow(int[]depths, int position)
        {
            return depths[position] + depths[position + 1] + depths[position + 2];
        }
    }
}
