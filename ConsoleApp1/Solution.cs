using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Program;

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

        //pascal triange
        public static List<List<int>> Pascal_Triangle(int n)
        {
            List<List<int>> res = new List<List<int>>();
            if ( n == 0)
            {
                return res;
            }
           
            res.Add(new List<int> { 1 });
            for (int i = 0; i < n; i++) 
            {
                var cc = new List<int>();
                for (int j = 0; j <= res[i].Count() ;  j++)
                {
                   
                    if (j == 0)
                    {
                        //res.Add(cc);
                        cc.Add(1);
                    }
                    else if (j == res[i].Count())
                    {
                        cc.Add(1);
                    }
                    else
                    {
                        //res[i].Add(res[i-1][j-1] + res[i - 1][j]);
                        cc.Add(res[i][j - 1] + res[i][j]);
                    }
                }
                res.Add(cc);
            }
            return res;
        }

        //Contains Duplicates

        public static bool Contains_Duplicate(int[] nums)
        {
            var n = nums.GroupBy(x => x);
            var a = n.Any(x => x.Count() > 1);
            return a;
        }
        public static bool Contains_Duplicate1(int[] nums)
        {
            HashSet<int> hash = new HashSet<int>();
            foreach (int n in nums)
            {
                if (hash.Contains(n))
                {
                    return false;
                }
                hash.Add(n);
            }
            return true;
        }
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public static ListNode reverseListNode(ListNode listnode)
        {
            #region initialize

            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            #endregion
            ListNode prevNode = null;

            while (head != null)
            {
                ListNode next = head.next;
                head.next = prevNode;
                prevNode = head;
                head = next;

            }
            return prevNode;

        }

        //two sum solution 

        public static int[] twoSum1(int[] numbers, int n)
        {
            int[] res = new int[numbers.Length];
            if (numbers.Length < 2)
            {
                return res;
            }
            
            HashSet<int> needToFind = new HashSet<int>();
            foreach (int i in numbers)
            {
                int t = n - i;
                if (needToFind.Contains(t))
                {
                    return res = new int[] { i,t};
                }
                else
                {
                    needToFind.Add(i);
                }

            }
            return res;

        }


        public static int[] twoSum(int[] numbers, int n)
        {
            //two pointer approach
            //for sorted array 
            int a_pointer = 0;
            int b_pointer = numbers.Length - 1;
            while (b_pointer > a_pointer)
            {
                int currentSum = numbers[a_pointer] + numbers[b_pointer];
                if (currentSum > n)
                {
                    //reduce the sum
                    b_pointer--;
                }
                else if (currentSum < n)
                {
                    //increase the curent sum
                    a_pointer++;
                }
                else
                {
                    return new int[] { numbers[a_pointer], numbers[b_pointer] };
                }
            }
            return new int[] { 0, 0 };
        }

        public static ListNode Palindrome_ListNode1()
        {
            #region initialize

            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(4);
            head.next.next.next.next.next.next = new ListNode(3);
            head.next.next.next.next.next.next.next = new ListNode(2);
            head.next.next.next.next.next.next.next.next = new ListNode(9);


            List<int> vals = new List<int>();   

            #endregion
            ListNode prevNode = null;
            while (head != null)
            {
                vals.Add(head.val);
                ListNode temp = head.next;
                head.next = prevNode;
                prevNode = head;
                head = temp;
                
            }
            int i = 0;
            while (prevNode != null)
            {
                if (prevNode.val != vals[i++])
                {
                    Console.WriteLine("Not a Palindrome");
                    return prevNode;
                }
                prevNode = prevNode.next;
            }
            Console.WriteLine("Palindrome");



            return prevNode;

        }
        public static bool Palindrome_ListNode()
        {
            
            #region initialize

            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next.next = new ListNode(4);
            head.next.next.next.next.next.next.next = new ListNode(3);
            head.next.next.next.next.next.next.next.next = new ListNode(2);
            head.next.next.next.next.next.next.next.next.next = new ListNode(1);
            #endregion
            ListNode first = head;
            ListNode second = head;

            while (first != null && first.next?.next != null)
            {
                first = first.next.next;
                second = second.next;
            }
            second = reverseLis(second);
            first = head;
            while (second != null && first != null)
            {
                if (first.val != second.val)
                {
                    return false;
                }
                second = second.next;
                first = first.next;
            }
            return true;
            
            //return null;
        }
        public static ListNode reverseLis(ListNode listnode)
        {
            ListNode prev = null;
            while (listnode != null )
            {
                ListNode temp = listnode.next;
                listnode.next = prev;
                prev = listnode;
                listnode = temp;
            }
            return prev;
        }


        public static int BinarySearch(int[] numbers, int n)
        {
            int right = numbers.Length - 1;
            int left = 0;
            while (right > left)
            {
                int middle = (left + right)/2;
                if (numbers[middle] > n)
                {
                    right = middle - 1;
                }
                else if (numbers[middle] < n)
                {
                    left = middle + 1;
                }
                else
                {
                    return middle;
                }
            }
            return -1;
        }

        public static string toLowerCase(string str)
        {
            str = "HEYD";
            string res = "";
            int subNum = 'A' - 'a';
            for (int i = 0; i < str.Length;i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    res += (char)(str[i] - subNum);
                }
                else
                {
                    res += (char) str[i];

                }
            }

            return res;
        }


        public static ListNode oddEvenLinkList()
        {
            ListNode listnode = new ListNode(1);
            listnode.next = new ListNode(2);
            listnode.next.next = new ListNode(3);
            listnode.next.next.next = new ListNode(4);
            listnode.next.next.next.next = new ListNode(5);
            listnode.next.next.next.next.next = new ListNode(6);

            ListNode odd = listnode;
            ListNode even = odd.next;
            ListNode evenNode = even;
            while (even?.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            ListNode res = odd;
            res.next = even;
            return null;
        }

        
    }
}
