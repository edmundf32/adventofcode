using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Aoc_days
{
    class Day6
    {
        Helper helper = new Helper();
    //    List<int> NewFish = new List<int>();
        public void Answer()
        {

            Console.WriteLine("Day 6!");
            var file = helper.ReadString("day6Input.txt")[0].Split(",");

            List<BigInteger> AllTheFishes = new List<BigInteger>() {0,0,0,0,0,0,0,0,0};

            //get the data

            foreach (var item in file)
            {
                int daysOld = Convert.ToInt32(item);

                AllTheFishes[daysOld] ++;
            }



            // do the days
            Console.WriteLine("Initial State: " );
            for (int i = 1; i < 257; i++)
            {
                AllTheFishes = BreedFishes(AllTheFishes);
                
            }
            Console.WriteLine("the Number of fishes " + GetAllTheFishies(AllTheFishes));// + PrintFishes(AllTheFishes));
        }

        private BigInteger GetAllTheFishies(List<BigInteger> theFishes)
        {
            BigInteger returnFishes = 0;
            foreach(BigInteger i in theFishes)
            {
                returnFishes += i;
            }

            return returnFishes;
        }

        private List<BigInteger> BreedFishes(List<BigInteger> AllTheFishes)
        {
            BigInteger newfishes = AllTheFishes[0];

            for (int i = 0; i < 8; i++ )
            {
                if(i==6) { AllTheFishes[i] = AllTheFishes[i + 1] + newfishes; }
                else { AllTheFishes[i] = AllTheFishes[i + 1]; }         
            }



            AllTheFishes[8] = newfishes;

            return AllTheFishes;
            /*
            int numberOfFishes = AllTheFishes.Count();

            for (int i = 0; i < numberOfFishes; i++)
            {
                if (AllTheFishes[i] == 0)
                {
                    AllTheFishes[i] = AllTheFishes[i] + 7;
                    AllTheFishes.Add(8);

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
            */
        }
    }
}
