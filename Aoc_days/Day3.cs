using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc_days
{
    class Day3
    {
        public void Answer()
        {
            Console.WriteLine("Day 3!");

            List<char[]> bytes = ReadBinary("day3Input.txt");
            int lengthOfByte = bytes[0].Length;
            var theSumOfTheBits = SumOfBits(bytes, lengthOfByte);

            List<string> bytesAsString = ConvertCharArrayToStringArray(bytes);


            var OxygenRating = GeneratorRating(bytesAsString, true);
            var CO2 = GeneratorRating(bytesAsString, false);

            var LifeSupportRating = OxygenRating * CO2;




            Console.WriteLine("The answer to part one is " + PartOne(lengthOfByte, theSumOfTheBits, bytes));

            Console.WriteLine("The answer to part two is " + LifeSupportRating);


        }
        private int GeneratorRating(List<string> bytesAsString, bool oxygen)
        {
            int position = 0;
            string filter = "";

            while (bytesAsString.Count > 1)
            {
                int sumOfPosition = 0;
                string filterAdd = "";

                foreach (var i in bytesAsString)
                {
                    sumOfPosition += (int)Char.GetNumericValue(i[position]);
                }

                var divide = bytesAsString.Count - sumOfPosition;

                if (sumOfPosition >= divide)
                {
                    if (oxygen) filterAdd = "1"; else filterAdd = "0";
                }
                else
                {
                    if (oxygen) filterAdd = "0"; else filterAdd = "1";
                }

                filter = filter + filterAdd;

                bytesAsString = bytesAsString.Where(i => i.StartsWith(filter)).ToList();

                position++;

            }
            var ed = ConvertFromBinaryStringToDecimal(bytesAsString[0]);
            return ConvertFromBinaryStringToDecimal(bytesAsString[0]);



        }

        public int ConvertFromBinaryStringToDecimal(string binary)
        {
            int[] binArray = new int[binary.Length];

            for(int i = 0; i < binary.Length; i++)
            {
                //binArray[i] = Convert.ToInt32(binary[i]);
                binArray[i] = (int)Char.GetNumericValue(binary[i]);
            }

            return ConvertFromBinaryToDecimal(binArray);

        }
        private List<string> ConvertCharArrayToStringArray(List<char[]> bytes)
        {
            List<string> bytesAsString = new List<string>();

            foreach (var item in bytes)
            {
                bytesAsString.Add(new string(item));
            }

            return bytesAsString;

        }

        private int PartOne(int lengthOfByte, int[] theSumOfTheBits, List<char[]> bytes)
        {
            int[] gamma = new int[lengthOfByte];
            int[] epsilon = new int[lengthOfByte];


            for (int i = 0; i < theSumOfTheBits.Length; i++)
            {
                if (theSumOfTheBits[i] > bytes.Count / 2)
                {
                    gamma[i] = 1;
                    epsilon[i] = 0;
                }
                else
                {
                    gamma[i] = 0;
                    epsilon[i] = 1;
                }
            }

            int gammaDec = ConvertFromBinaryToDecimal(gamma);
            int epsilonDec = ConvertFromBinaryToDecimal(epsilon);

            return gammaDec * epsilonDec;
        }

        private int ConvertFromBinaryToDecimal(int[] binary)
        {
            int dec = 0;

            for(int i = 0; i < binary.Length; i++)
            {
                dec += binary[i] * Convert.ToInt32((Math.Pow(2 , (binary.Length - i - 1 )))) ;
            }

            return dec;

        }

        private List<char[]> ReadBinary(string name)
        {
            string[] binaryasString = File.ReadAllLines("c:\\ed\\" + name);
            List<char[]> binaryAsCharArray = new List<char[]>();

            foreach(var item in binaryasString)
            {
                binaryAsCharArray.Add(item.ToCharArray());
            }

            return binaryAsCharArray;
        }

        private int[] SumOfBits(List<char[]> bytesAsString, int lengthOfByte)
        {
            int[] binaryTotal = new int[lengthOfByte];

            foreach (var item in bytesAsString)
            {
                for (int i = 0; i < lengthOfByte; i++)
                {
                    binaryTotal[i] += (int)Char.GetNumericValue(item[i]);
                }
            }

            return binaryTotal;
        }
    }
}
