using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc_days
{
    class Day5
    {
        Helper helper = new Helper();
        public void Answer()
        {
            Console.WriteLine("Day 8!");

            int[,] grid = MakeEmptyGrid();
            var file = helper.ReadString("day5Test.txt");

            foreach(var item in file)
            {
                var line = ConvertInputToList(item);

                foreach (var point in line)
                {
                    grid[point[1],point[0]] = grid[point[1],point[0]]  += 1;
                }

                //PrintGrid(grid);
            }




            //PrintGrid(grid);
            int totalTows = 0;
            for (int i = 0; i < 1000; i++)
            {
               for (int j = 0; j < 1000; j++)
                    {
                    if (grid[i, j] > 1) totalTows++;

                    }
            }

            Console.Write("total tows " + totalTows);

        }

        private void PrintGrid(int[,] grid)
        {
            Console.Write("The Grid" + '\n');
            Console.Write("  0 1 2 3 4 5 6 7 8 9" + '\n');
            Console.Write("  - - - - - - - - - - " + '\n');

            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + "|");
                for (int j = 0; j < 1000; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.Write('\n');
            }

        }

        private List<int[]> ConvertInputToList(string vector)
        {
            string[] startend = vector.Split("->");
            string[] startstring = startend[0].Split(",");
            string[] endstring = startend[1].Split(",");

            int[] startpoint = StringPointToIntPoint(startstring);
            int[] endpoint = StringPointToIntPoint(endstring);

            List<int[]> lineEndPoints = new List<int[]> { startpoint, endpoint };

            List<int[]> linePoints = GetLine(lineEndPoints);

            return linePoints;
        }

        private int[] StringPointToIntPoint(string[] point)
        {
            int[] intPoint = new int[2] { Convert.ToInt32(point[0]), Convert.ToInt32(point[1]) };

            return intPoint;
        }

        private List<int[]> GetLine(List<int[]> startEnd)
        {
            List<int[]> line = new List<int[]>();

            if (startEnd[0][0] == startEnd [1][0] | startEnd[0][1] == startEnd[1][1])
            {


                startEnd = MakeVectorPositive(startEnd);

                if(startEnd[0][0] == startEnd[1][0])  //vertical line

                {
                    for (int i = startEnd[0][1]; i <= startEnd[1][1]; i++)
                    {
                        line.Add(new int[2] { startEnd[0][0] ,i });
                    }
                }
                else // horizontal line
                {
                    for (int i = startEnd[0][0]; i <= startEnd[1][0]; i++)
                    {
                        line.Add(new int[2] { i, startEnd[0][1] });
                    }
                }
                return line;
            }
            else // gotta be diagonal
            {
                startEnd = MakeDiagonalVectorPositive(startEnd);


                if(startEnd[0][1] > startEnd[1][1]) // diagonal up
                {
                    for(int i = 0; i <= startEnd[1][0] - startEnd[0][0];i++)
                    {
                        line.Add(new int[2] { startEnd[0][0] + i, startEnd[0][1] - i });
                    }
                }
                else // diagonal down
                {
                    for (int i = 0; i <= startEnd[1][0] - startEnd[0][0]; i++)
                    {
                        line.Add(new int[2] { startEnd[0][0] + i, startEnd[0][1] + i });
                    }
                }


                return line;



            }
       
        }

        private List<int[]> GetDiagonalLine(List<int> DiagonalStartEndPoints)
        {

            return new List<int[]>();
        }

        private List<int[]> MakeVectorPositive(List<int[]> vector)
        {
            if(vector[0][0] > vector [1][0] || vector[0][1] > vector[1][1])   
            {
                return new List<int[]> { vector[1], vector[0] };
            }

            return vector; // do nothing
        }
        private List<int[]> MakeDiagonalVectorPositive(List<int[]> vector)
        {
            if (vector[0][0] > vector[1][0]) // always start with the smaller x
            {
                return new List<int[]> { vector[1], vector[0] };
            }

            return vector; // do nothing
        }
        private int[,] MakeEmptyGrid()
        {
            int[,] grid = new int[1000, 1000];

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    grid[i, j] = 0;
                }
            }
            return grid;
        }
    }
}
