using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc_days
{
    class Day6
    {
        Helper helper = new Helper();
        List<int> NewFish = new List<int>();
        public void Answer()
        {

            Console.WriteLine("Day 6!");
            var file = helper.ReadString("day6Input.txt")[0].Split(",");

            List<int> AllTheFishes = new List<int>();

            //get the data

            foreach(var item in file)
            {
                AllTheFishes.Add(Convert.ToInt32(item));
            }



            // do the days
            Console.WriteLine("Initial State: " + PrintFishes(AllTheFishes));
            for (int i = 1; i < 257; i++)
            {
                AllTheFishes = BreedFishes(AllTheFishes);
                Console.WriteLine("Number of fishes " + AllTheFishes.Count() + " After " + i + " days: ");// + PrintFishes(AllTheFishes));
            }

        }

        private List<int> BreedFishes(List<int> AllTheFishes)
        {
            int numberOfFishes = AllTheFishes.Count();

            for (int i = 0; i < numberOfFishes; i++)
            {
                if (AllTheFishes[i] == 0)
                {
                    AllTheFishes[i] = AllTheFishes[i] + 7;
                    AllTheFishes.Add(8);

                    /*
                    if (NewFish.Contains(i))
                    {
                        AllTheFishes.Add(8);
                        AllTheFishes[i] = 7;
                    }
                    else
                    {
                        AllTheFishes.Add(8);
                        NewFish.Add(i);
                    }   
                    */
                }
                AllTheFishes[i] = AllTheFishes[i] - 1;
            }
            return AllTheFishes;
        }

        private string PrintFishes(List<int> AllTheFishes)
        {
            string returnString = "";

            foreach(var item in AllTheFishes)
            {
                returnString += item + ",";
            }

            return returnString.Remove(returnString.Length - 1, 1);
        }
    }
}
