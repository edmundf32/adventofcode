using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc_days
{
    internal class Day8
    {
        //https://dotnetfiddle.net/dCBXlg
        Helper helper = new Helper();

        public void Answer()
        {
            var positionsPerDigit = new Dictionary<int, char[]>
            {
                [0] = new[] { 'a', 'b', 'c', 'e', 'f', 'g' },
                [1] = new[] { 'c', 'f' },
                [2] = new[] { 'a', 'c', 'd', 'e', 'g' },
                [3] = new[] { 'a', 'c', 'd', 'f', 'g' },
                [4] = new[] { 'b', 'c', 'd', 'f' },
                [5] = new[] { 'a', 'b', 'd', 'f', 'g' },
                [6] = new[] { 'a', 'b', 'd', 'e', 'f', 'g' },
                [7] = new[] { 'a', 'c', 'f' },
                [8] = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' },
                [9] = new[] { 'a', 'b', 'c', 'd', 'f', 'g' },
            };

            var digitsWithUniqueNumberOfPositions = new[] { 1, 4, 7, 8 };

            var lines = helper.ReadString("day8Input.txt");

           // var lines = response.Split("\n");

            var inputOutput = lines.Select(line =>
            {
                return line.Split(" | ");
            });

            var inputLines = inputOutput.Select(line => line.First().Split(' '));
            var outputLines = inputOutput.Select(line => line.Last().Split(' '));

            // Step 1

            var outputs = outputLines.SelectMany(x => x);

            var outputsPerNumberOfPositions = outputs.GroupBy(o => o.Length).Select(o => new { NumberOfPoistions = o.Key, Count = o.Count() });

            var digitsToLookFor = digitsWithUniqueNumberOfPositions;

            var numberOfPositionsToLookFor = digitsToLookFor.Select(d => positionsPerDigit[d].Length).ToList();

            var result = outputsPerNumberOfPositions.Where(o => numberOfPositionsToLookFor.Contains(o.NumberOfPoistions)).Sum(o => o.Count);

            Console.WriteLine(result);

            var result2 = inputLines.Select((inputs, index) =>
            {
                var digits = GetParsedOutputDigits(inputs, outputLines.ElementAt(index), positionsPerDigit);
                return GetCombinedDigitsValue(digits);
            }).Sum(x => x);

            Console.WriteLine(result2);

        }



        // Get data



// Step 2




int GetCombinedDigitsValue(IEnumerable<int> digits)
        {
            var combined = int.Parse(string.Join("", digits.Select(d => d.ToString())));
            return combined;
        }

        IEnumerable<int> GetParsedOutputDigits(IEnumerable<string> inputs, IEnumerable<string> outputs, Dictionary<int, char[]> positionsPerDigit)
        {
            var digitPerInput = inputs.Select(input => Normalize(input)).Distinct()
                .ToDictionary(input => input, input => input switch
                {
                    { } when input.Length == positionsPerDigit[1].Length => (int?)1,
                    { } when input.Length == positionsPerDigit[4].Length => 4,
                    { } when input.Length == positionsPerDigit[7].Length => 7,
                    { } when input.Length == positionsPerDigit[8].Length => 8,
                    _ => null,
                });

            var unResolved = digitPerInput.Where(x => x.Value is null).Select(x => x.Key).ToList();

            unResolved.ForEach(input => {
                digitPerInput[input] = input switch
                {
                    { } when input.Length == 6 && GetMatchingPositions(input, digitPerInput.Single(d => d.Value == 1).Key).Count() == 1
                        => (int?)6,
                    { } when input.Length == 6 && GetMatchingPositions(input, digitPerInput.Single(d => d.Value == 4).Key).Count() == 4
                        => 9,
                    { } when input.Length == 6
                        => 0,
                    { } when input.Length == 5 && GetMatchingPositions(input, digitPerInput.Single(d => d.Value == 1).Key).Count() == 2
                        => 3,
                    { } when input.Length == 5 && GetMatchingPositions(input, digitPerInput.Single(d => d.Value == 4).Key).Count() == 3
                        => 5,
                    _ => 2
                };
            });

            return outputs.Select(output =>
            {
                return digitPerInput[Normalize(output)].GetValueOrDefault();
            });
        }

        IEnumerable<char> GetMatchingPositions(IEnumerable<char> positions, IEnumerable<char> positions2)
        {
            return positions.Intersect(positions2);
        }

        string Normalize(string positions)
        {
            return new string(positions.OrderBy(x => x).ToArray());
        }

    }
}

//            Console.WriteLine("Day 8!");
//            var file = helper.ReadString("day8.txt");

//            List<string> rawInputs = new List<string>();
//            List<string> rawOutputs = new List<string>();


//            foreach (var item in file)
//            {
//                rawInputs.Add(item.Split("| ")[0]);
//                rawOutputs.Add(item.Split("| ")[1]);
//            }

//            List<string[]> Inputs = Convertdata(rawInputs, 9);
//            List<string[]> Outputs = Convertdata(rawOutputs, 3);

//            //int countof147 = 0;


//            var solutionKey = CreateCompleteSolution(Inputs[0]);

//            foreach(var outputValue in Outputs)
//            {
//                for (int i = 0; i < outputValue.Length; i++)
//                {
//                        outputValue[i] = SortString(outputValue[i]);
//                }
//            }



//            string decodedNumber = "";

//            foreach(var item in Outputs[0])
//            {
//                for (int i =0; i<10; i++)
//                {
//                    if (item == solutionKey[i]) decodedNumber+= i.ToString();
//                }
//            }

//            //countof147 = countof147 + Count147(Outputs);

//            //Console.WriteLine("count of 147 = " + countof147);
//        }

//        private string SortString(string input)
//        {
//            // init array
//            char[] letters = input.ToCharArray();

//            // bubble sorting...
//            int count = letters.Length;
//            bool swapped;
//            do
//            {
//                swapped = false;
//                for (int i = 0; i < count - 1; i++)
//                {
//                    if (letters[i] > letters[i + 1])
//                    {
//                        char c = letters[i];
//                        letters[i] = letters[i + 1];
//                        letters[i + 1] = c;
//                        swapped = true;
//                    }
//                }
//                count--;
//            } while (swapped);

//            return string.Join("", letters);
//        }

        

//        private string[] CreateCompleteSolution(string[] encoded) //how ugly is this
//        {
//           string[] completeSolution = new string[10];


//            completeSolution[1] = SortString(encoded.Where(x => x.Length == 2).FirstOrDefault());
//            completeSolution[4] = SortString(encoded.Where(x => x.Length == 4).FirstOrDefault());
//            completeSolution[7] = SortString(encoded.Where(x => x.Length == 3).FirstOrDefault());
//            completeSolution[8] = SortString(encoded.Where(x => x.Length == 7).FirstOrDefault());

//            List<string> findSix = encoded.Where(x => x.Length == 6).ToList();


//            foreach (string item in findSix)
//            {
//                foreach(char c in completeSolution[1])
//                {
//                    if (!item.Contains(c))
//                    {
//                        completeSolution[6] = SortString(item);  //found six
                        
//                    }
//                }
//            }

//            findSix.Remove(completeSolution[6]);

//            foreach (string item in findSix)
//            {
//                foreach (char c in completeSolution[4])
//                {
//                    if(!item.Contains(c))
//                    {
//                        completeSolution[0] = SortString(item);  //found zero
//                    }
//                }
//            }

//            findSix.Remove(completeSolution[0]);
//            completeSolution[9] = SortString(findSix[0]); //found nine


//            List<string> findFive = encoded.Where(x => x.Length == 5).ToList();

//            foreach (string item in findFive)
//            {
             
//                    if (item.Contains(item[0]) && item.Contains(item[1]))
//                    {
//                        completeSolution[3] = SortString(item);  //found three
//                    }
                
//            }

//            findFive.Remove(completeSolution[3]);

//            string twoMaybe = SortString(findFive[0]);
//            string fiveMaybe = SortString(findFive[1]);


//            foreach (char c in completeSolution[9])
//            {
//                string s = c.ToString();
//                findFive[0] = findFive[0].Replace(s, string.Empty);
//                findFive[1] = findFive[1].Replace(s, string.Empty);
//            }

                          

//            if (findFive[0].Length == 0)
//            {
//                completeSolution[5] = twoMaybe;
//                completeSolution[2] = fiveMaybe;
//            }
//            else
//            {
//                completeSolution[5] = fiveMaybe;
//                completeSolution[2] = twoMaybe;
//            }

//            return completeSolution;
//        }
//        private int Count147(List<string[]> input)
//        {
//            int countOf147 = 0;

//            foreach(var item in input)
//            {
//                foreach (var substring in item)
//                {
//                    if (the147.Contains(substring.Length)) countOf147++;

//                }
//            }

//            return countOf147;
//        }

//        private List<string[]> Convertdata(List<string> rawinput, int size)
//        {
//            List<string[]> returnArray = new List<string[]>();

//            foreach (string item in rawinput)
//            {
//                string[] addString = new string[size];
//                addString = item.Split(" ");
//                returnArray.Add(addString);
//            }



//            return returnArray;
//        }
//        /*
//    }
//}
