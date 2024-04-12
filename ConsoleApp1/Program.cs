using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
       

        static void Main(string[] args)
        {
            char[][] grid = new char[][] {
            new char[] { '1', '1', '1', '0', '0' },
            new char[] { '1', '1', '0', '1', '0' },
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '0', '0', '1', '0', '1' }
        };

            //var wxs = Solution.NumIslands(grid);
            //Console.WriteLine(wxs);
            var s = Solution.Pascal_Triangle(5);
            for (int i = 0; i < s.Count; i++)
            {
                Console.Write("List" + (i + 1) + ": ");
                foreach (var num in s[i])
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
