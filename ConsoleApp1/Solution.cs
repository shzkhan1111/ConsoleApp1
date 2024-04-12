using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Solution
    {
        #region Question
        //Given a 2D grid map of '1's(land) and '0's(water), count the number of distinct islands.An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are surrounded by water.
        #endregion
        public static int NumIslands(char[][] grid)
        {
            //logic 
            //if move left, right, up and down 
            //find all 1 recursion BFS turn them to 0

            int c = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        c++;
                        BFS(grid, i, j);
                    }
                }
            }

            return c;
        }
        public static int BFS(char[][] grid, int i, int j)
        {
            if (i < 0 || i > grid.Length - 1  || j < 0 )
            {
                //base condition 
                return 0;
            }
            if (j > grid[i].Length - 1 || grid[i][j] == '0')
            {
                return 0;
            }

            grid[i][j] = '0';
            BFS(grid, i + 1, j);
            BFS(grid, i - 1, j);
            BFS(grid, i , j + 1);
            BFS(grid, i , j - 1);
            return 0;


        }
    }
}
