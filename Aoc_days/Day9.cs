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
            var lines = helper.ReadString("day9Input.txt");
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
                    if (x != 99) if (grid[x , y] >= grid[x + 1 , y]) lowpoint = false;
                    //if y
                    if (y != 0) if (grid[x , y] >= grid[x , y - 1]) lowpoint = false;
                    //if -y
                    if (y != 99) if (grid[x , y] >= grid[x , y + 1]) lowpoint = false;

                    if (lowpoint)
                    {
                        if(grid[x,y] == 9)
                        {
                            var ed = "stop";
                        }
                        lowpoints.Add(grid[x, y] + 1);
                    }
                    

                }
            }

            Console.WriteLine("lowpoints total  " + lowpoints.Sum());

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
