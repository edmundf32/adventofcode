using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc_days
{
     class Day7
    {
        Helper helper = new Helper();
        public void Answer()
        {

            Console.WriteLine("Day 7!");
            var file = helper.ReadString("day7Input.txt")[0].Split(",");
            List<int> positions = new List<int>();

            foreach (var item in file)
            {
                positions.Add(int.Parse(item));
            }

            var maxNum = positions.Max(z => z);

            long totalFuel = 100000000000;
            int distanceguessFuel = 0;

            for (int i = 0; i < maxNum; i ++)
            {
            
                int guessFuel = 0;

                foreach ( int item in positions)
                {
                    distanceguessFuel = Math.Abs(item-i);
                    int sumOfFuel = 0;

                    for (int j = 0; j <=  distanceguessFuel; j ++)
                    {
                        sumOfFuel += j;
                    }

                //Console.WriteLine("move from  " + item + "to  " + i + " fuel = " + sumOfFuel);

                guessFuel += sumOfFuel;


                }
                Console.WriteLine("iteration - " + i + "guess " + guessFuel);
                if (guessFuel < totalFuel) totalFuel = guessFuel;


            }
            Console.WriteLine(" minimum " + totalFuel);
        }

        




    }
}
