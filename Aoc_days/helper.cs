using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc_days
{
    class Helper
    {
        public List<char[]> ReadBinary(string name)
        {
            string[] binaryasString = File.ReadAllLines("c:\\ed\\" + name);
            List<char[]> binaryAsCharArray = new List<char[]>();

            foreach (var item in binaryasString)
            {
                binaryAsCharArray.Add(item.ToCharArray());
            }

            return binaryAsCharArray;
        }

        public string[] ReadString(string name)
        {
            return File.ReadAllLines("c:\\ed\\" + name);

        }

    }
}
