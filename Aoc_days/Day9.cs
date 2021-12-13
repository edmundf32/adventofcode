using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc_days
{


    class Day9
    {
        Helper helper = new Helper();
        public void Answer()
        {
            var lines = helper.ReadString("day9.txt");
            var grid = GetThegrid(lines);

            List<int> lowpoints = new List<int>();


            for (int x = 0; x < lines[0].Length; x++)
            {
                for (int y = 0; y < lines.Count(); y++)
                {
                    bool lowpoint = true;

                    //if x
                    if (x != 0) if (grid[x , y] >= grid[x - 1 , y]) lowpoint = false;
                    //if -x
                    if (x != lines[0].Length - 1) if (grid[x , y] >= grid[x + 1 , y]) lowpoint = false;
                    //if y
                    if (y != 0) if (grid[x , y] >= grid[x , y - 1]) lowpoint = false;
                    //if -y
                    if (y != lines.Count() - 1) if (grid[x , y] >= grid[x , y + 1]) lowpoint = false;

                    if (lowpoint)
                    {
                        lowpoints.Add(grid[x, y] + 1);
                    }                    
                }
            }

            Console.WriteLine("Basin + = " + CalculateBasinPositivex(grid, 6 , 4));
            Console.WriteLine("Basin -  = " + CalculateBasinNegativex(grid, 6, 4));

            Console.WriteLine("lowpoints total  " + lowpoints.Sum());

        }

        private int CalculateBasinPositivex(int[,] grid, int x, int y)
        {
            int basinSize = 0;

            while (x != 10 && grid[x, y] != 9)
            {
                basinSize++;
                x++;
            }

            return basinSize -1;
        }

        private int CalculateBasinNegativex(int[,] grid, int x, int y)
        {
            int basinSize = 0;

            //count - x

            while(x != 0 && grid[x,y] != 9)
            {
                basinSize++;
                x--;
            }

            return basinSize -1;
        }


        private int[,] GetThegrid(string[] lines)
        {
            var grid = new int[lines[0].Length, lines.Count() ];

            for (int i = 0; i < lines[0].Length; i++)
            {
                for (int j = 0; j < lines.Count(); j++)
                {
                    grid[i, j] = int.Parse(lines[j][i].ToString());
                }
            }

            return grid;
        }
    }
}
