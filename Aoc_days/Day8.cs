using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc_days
{
    internal class Day8
    {
        Helper helper = new Helper();
        List<int> the147 = new List<int>() { 2, 3, 4, 7};
        List<string> completeSolution = new List<string>();
        public void Answer()
        {
            Console.WriteLine("Day 8!");
            var file = helper.ReadString("day8Input.txt");

            List<string> rawInputs = new List<string>();
            List<string> rawOutputs = new List<string>();


            foreach (var item in file)
            {
                rawInputs.Add(item.Split("|")[0]);
                rawOutputs.Add(item.Split("|")[1]);
            }

            List<string[]> Inputs = Convertdata(rawInputs, 9);
            List<string[]> Outputs = Convertdata(rawOutputs, 3);

            int countof147 = 0;

            //countof147 = countof147 + Count147(Inputs);
            countof147 = countof147 + Count147(Outputs);

            Console.WriteLine("count of 147 = " + countof147);
        }


        private List<string> CreateCompleteSolution(List<string> encoded)
        {
            List<string> completeSolution = new List<string>();



            return completeSolution;

        }
        private int Count147(List<string[]> input)
        {
            int countOf147 = 0;

            foreach(var item in input)
            {
                foreach (var substring in item)
                {
                    if (the147.Contains(substring.Length)) countOf147++;

                }
            }

            return countOf147;
        }

        private List<string[]> Convertdata(List<string> rawinput, int size)
        {
            List<string[]> returnArray = new List<string[]>();

            foreach (string item in rawinput)
            {
                string[] addString = new string[size];
                addString = item.Split(" ");
                returnArray.Add(addString);
            }



            return returnArray;
        }
    }
}
