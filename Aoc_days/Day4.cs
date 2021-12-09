using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc_days
{
    class Day4
    {
        Helper helper = new Helper();
        public void Answer()
        {
            Console.WriteLine("Day 4!");
            var file = helper.ReadString("day4.txt");

            var selectedNumbers = file[0].Split(",");
            bool totalFound = false;
            List<Table> tables = BuildTables(file);
            int WinningTotal = 0;

            foreach (var selectedNumber in selectedNumbers)
            {
               // Console.WriteLine("selected number " + selectedNumber);
                foreach(var table in tables)
                {
                    foreach(var row in table.rows)
                    {
                       for(int i = 0; i < 5; i++ )
                        {
                           // Console.WriteLine("row " + i +  " value " + row[i]);
                            if (row[i].Equals(selectedNumber)) {
                               //Console.WriteLine("true");
                                row[i] = "x";
                                if(CheckTable(table, selectedNumber) > 0)
                                {
                                    if(!totalFound)
                                    {
                                        WinningTotal = CheckTable(table, selectedNumber);
                                        totalFound = true;
                                    }                                   
                                }                            
                            };
                        }
                    }
                }
            }
            Console.WriteLine("winning number = " + WinningTotal);
       }

        private int CheckTable(Table table, string winningNumber)
        {
            Int32 IntRes;


            bool IsWinner = true;
            //check rows
            foreach (var row in table.rows)
            {
                foreach (var stringEntry in row)
                {
                    if (Int32.TryParse(stringEntry, out IntRes)) IsWinner = false;
                }

                for(int i = 0; i<5, i++)
                {
                    if (Int32.TryParse(table.rows[0][i], out IntRes)) IsWinner = false;
                }
                if (IsWinner)
                {
                    int tableTotal = CalculateWinningTotal(table);
                    return tableTotal * Convert.ToInt32(winningNumber);

                }
            }

            return -1;       
        }

        private int CalculateWinningTotal(Table table)
        {
            int winningTotal = 0;
            Int32 IntRes;

            foreach (var row in table.rows)
            {
                foreach(var item in row)
                {
                    if (Int32.TryParse(item, out IntRes)) winningTotal += IntRes;
                }
            }

            return winningTotal;
        }
            
        private List<Table> BuildTables(string[] file)
        {
            int rowCount = 2;


            List<Table> tables = new List<Table>();

            while (rowCount + 5 < file.Length + 1)
            {
                Table table = new Table() { rows = new List<string[]>() };
                for (int i = 0; i < 5; i++)
                {
                    var row = (file[i + rowCount].Split(" ", StringSplitOptions.RemoveEmptyEntries));
                    table.rows.Add(row);
                }
                tables.Add(table);
                rowCount += 6;
            }

            return tables;
        }

        class Table
        {
            public List<string[]> rows { get; set; }
        }
    }
}
