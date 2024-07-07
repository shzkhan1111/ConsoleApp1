using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TicTakToe
    {
        private int[] rows;
        private int[] cols;


        private int diaLeftsum;
        private int diaRigsum;
        int[][] grid = new int[][]
        {
            new int[3],    
            new int[3],    
            new int[3]    
        };

        public TicTakToe()
        {
            rows = new int[3];
            cols = new int[3];
            Array.Fill(rows, 0);
            Array.Fill(cols, 0);
        }

        public bool makeAMove(int r, int c, int p)
        {
            r--;
            c--;
            int playermultiplier = (p == 1 ? 1 : -1);
            if (r > rows.Length || r < 0 || c < 0 || c > cols.Length || grid[r][c]!= 0)
            {
                Console.WriteLine("Invalid move");
                return false;
            }
            grid[r][c] = playermultiplier;
            
            rows[r] = playermultiplier;
            cols[c] = playermultiplier;
            if (c == r)
            {
                diaLeftsum += playermultiplier;
            }
            //var antiDiacondition = (r == 1 && c == 1) || (r == 0 && c == 2) || (r == 2 && c == 0);
            if (cols.Length - 1 - r == c)
            {
                diaRigsum += playermultiplier;
            }

            bool winningcond = Math.Abs(rows.Sum()) == 3
                || Math.Abs(cols.Sum()) == 3
                || diaLeftsum == 3
                || diaRigsum == 3
                ;
            Console.WriteLine("Numbers");
            string rowslist = string.Join(", ", rows);
            string colslist = string.Join(", ", cols);
            Console.WriteLine(rowslist);
            Console.WriteLine(colslist);

            return winningcond;

        }

    }
}
