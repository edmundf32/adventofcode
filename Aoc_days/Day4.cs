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
        bool totalFound = false;
        int WinningTotal = 0;

        public void Answer()
        {
            Console.WriteLine("Day 4!");
            var file = helper.ReadString("day4Input.txt");

            var selectedNumbersasstring = file[0].Split(",");
            int[] selectedNumbers = GetSelectedNumbers(selectedNumbersasstring);

            List<Table> tables = BuildTables(file);

            foreach (var selectedNumber in selectedNumbers)
            {
                if (totalFound) break;
                for (int i = 0; i < tables.Count; i++)
                {
                    tables[i] = MarkTable(tables[i], selectedNumber);
                }
            }

            Console.WriteLine("winning number = " + WinningTotal);
        
        }


        private Table MarkTable(Table table, int selectedNumber)
        {
            foreach (var row in table.rows)
            {
                //if (totalFound) break;
                for (int i = 0; i < 5; i++)
                {
                    if (row[i] == selectedNumber)
                    {
                        row[i] = -1;
                        if (CheckTable(table, selectedNumber) > 0)
                        {/*
                            if (!totalFound)
                           {
                                WinningTotal = CheckTable(table, selectedNumber);
                                totalFound = true;
                                break;
                            }
                            */
                            return WinningTable();

                        }
                    };
                }
            }
            return table;
        }

       
        private int CheckTable(Table table, int winningNumber)
        {
            if(winningNumber == 16)
            {
                int ed = 0;
            }
            // check columns
            int[] columnasarray = new int[5];
            for (int i = 0; i<5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    columnasarray[j] = table.rows[j][i];
                }

                if (columnasarray.Sum() == -5)
                {
                    int tableTotal = CalculateWinningTotal(table);
                    Console.WriteLine("table total = " + tableTotal + " winning number = " + winningNumber);
                    return tableTotal * winningNumber;
                }

            }
    

            //check rows
            foreach (var row in table.rows)
            {
                if (row.Sum() == -5)
                {
                    int tableTotal = CalculateWinningTotal(table);
                    Console.WriteLine("table total = " + tableTotal + " winning number = " + winningNumber);
                    return tableTotal * winningNumber;
                }

            }

            return -1;       
        }

        private int CalculateWinningTotal(Table table)
        {
            int winningTotal = 0;


            foreach (var row in table.rows)
            {
                foreach(var item in row)
                {
                   if(item != -1) winningTotal += item;
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
                Table table = new Table() { rows = new List<int[]>() };
                for (int i = 0; i < 5; i++)
                {
                    int[] numrow = new int[5];
                    var row = (file[i + rowCount].Split(" ", StringSplitOptions.RemoveEmptyEntries));
                    for (int j = 0; j < 5; j++) 
                    {
                        numrow[j] = Convert.ToInt32(row[j]);
                    } 
                    table.rows.Add(numrow);
                }
                tables.Add(table);
                rowCount += 6;
            }

            return tables;
        }

        class Table
        {
            public List<int[]> rows { get; set; }
        }

        private int[] GetSelectedNumbers(string[] file)
        {
            int[] selectedNumbers = new int[file.Length];

            for (int i = 0; i < file.Length; i++)
            {
                selectedNumbers[i] = Convert.ToInt32(file[i]);
            }

            return selectedNumbers;
        }

        private Table WinningTable()
        {
            Table table = new Table() { rows = new List<int[]>() };
            for (int i = 0; i < 5; i++)
            {
                int[] numrow = new int[5];
                for (int j = 0; j < 5; j++)
                {
                    numrow[j] = 35;
                }
                table.rows.Add(numrow);
            }

            return table;
        }
    }
}
