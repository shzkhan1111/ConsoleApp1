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
            if (i < 0 || i > grid.Length - 1 || j < 0)
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
            BFS(grid, i, j + 1);
            BFS(grid, i, j - 1);
            return 0;


        }

        //pascal triange
        public static List<List<int>> Pascal_Triangle(int n)
        {
            List<List<int>> res = new List<List<int>>();
            if (n == 0)
            {
                return res;
            }

            res.Add(new List<int> { 1 });
            for (int i = 0; i < n; i++)
            {
                var cc = new List<int>();
                for (int j = 0; j <= res[i].Count(); j++)
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
                    return res = new int[] { i, t };
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
            while (listnode != null)
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
                int middle = (left + right) / 2;
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
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    res += (char)(str[i] - subNum);
                }
                else
                {
                    res += (char)str[i];

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

        public static int isDefaulted()
        {
            //0 is ok, 1 is defauted
            int[] numbers = { 0, 0, 0, 1, 1, 1, 1, 1 };
            int l = 0;
            int r = numbers.Length - 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (numbers[m] == 0)
                {
                    l = m + 1;
                }
                else if (numbers[m] == 1)
                {
                    r = m - 1;
                }
            }
            return l;//add condition to check before and after the element as well
        }

        public static void isStringBackSpacedEqual1()
        {
            string s1 = "scf&&lw&";
            string s2 = "sl";
            List<char> c1 = new List<char>();
            List<char> c2 = new List<char>();

            int shorterLength = 0, maxLength = 0;
            string shorterString, longerString;
            if (s1.Length > s2.Length)
            {
                shorterString = s2;
                longerString = s1;
                shorterLength = s2.Length;
                maxLength = s1.Length;

            }
            else
            {
                shorterString = s1;
                longerString = s2;
                shorterLength = s1.Length;
                maxLength = s2.Length;
            }
            int i = 0;
            int j = 0;
            while (j < maxLength)
            {
                if (i < shorterLength)
                {
                    if (shorterString[i] != '&')
                    {
                        c1.Add((char)shorterString[i]);
                    }
                    else
                    {
                        if (c1.Count > 0)
                        {
                            c1.RemoveAt(c1.Count - 1);
                        }
                    }
                    i++;
                }

                if (longerString[j] != '&')
                {
                    c2.Add((char)longerString[j]);
                }
                else
                {
                    if (c2.Count > 0)
                    {
                        c2.RemoveAt(c2.Count - 1);
                    }
                }
                j++;
            }

            if (c1.Count() != c2.Count())
            {
                Console.WriteLine("Not Equal");
                return;
            }
            for (int k = 0; k < c1.Count(); k++)
            {
                if (c1[k] != c2[k])
                {
                    Console.WriteLine("Not Equal");
                    return;
                }
            }
            Console.WriteLine("Equal");
            return;

        }


        public static void isStringBackSpacedEqual()
        {
            string s1 = "scf&&lw&";
            string s2 = "s2&l";
            int s1Pointer = s1.Length - 1;
            int s2Pointer = s2.Length - 1;
            int s1ToSkip = 0;
            int s2ToSkip = 0;

            bool continueFlag = false;
            while (s1Pointer > 0 || s2Pointer > 0)
            {
                continueFlag = false;
                if (s1Pointer > 0)
                {
                    if (s1[s1Pointer] == '&')
                    {
                        s1ToSkip++;
                        s1Pointer--;
                        continueFlag = true;
                    }
                    else if (s1ToSkip > 0)
                    {
                        s1ToSkip--;
                        s1Pointer--;
                        continueFlag = true;
                    }

                    if (continueFlag)
                    {
                        continue;
                    }
                }

                if (s2Pointer > 0)
                {
                    if (s2[s2Pointer] == '&')
                    {
                        s2ToSkip++;
                        s2Pointer--;
                        continueFlag = true;
                    }
                    else if (s2ToSkip > 0)
                    {
                        s2ToSkip--;
                        s2Pointer--;
                        continueFlag = true;
                    }

                    if (continueFlag)
                    {
                        continue;
                    }
                }




                if (s1[s1Pointer] != s2[s2Pointer])
                {
                    Console.WriteLine("Not Equal");
                    return;
                }
                s1Pointer--;
                s2Pointer--;
            }

            if (s1Pointer > 0)
            {
                s1Pointer -= s1ToSkip;
                s1ToSkip = 0;
            }
            if (s2Pointer > 0)
            {
                s2Pointer -= s2ToSkip;
                s2ToSkip = 0;
            }

            if (s2Pointer > 0 || s1Pointer > 0)
            {
                Console.WriteLine("Not Equal");
                return;
            }
            Console.WriteLine("Equal");
            return;

        }


        public static void isLinkListRepeated1()
        {
            // Create nodes
            ListNode listnode = new ListNode(1);
            ListNode listnode2 = new ListNode(2);
            ListNode listnode3 = new ListNode(3);
            ListNode listnode4 = new ListNode(4);
            ListNode listnode5 = new ListNode(5);
            ListNode listnode6 = new ListNode(6);

            // Connect nodes to form a linked list
            listnode.next = listnode2;
            listnode2.next = listnode3;
            listnode3.next = listnode4;
            listnode4.next = listnode5;
            listnode5.next = listnode6;

            // Create a cycle by connecting the last node to a previous node
            listnode6.next = listnode3; // This creates a cycle between node 6 and node 3


            HashSet<ListNode> hash = new HashSet<ListNode>();

            hash.Add(listnode);
            listnode = listnode.next;
            while (listnode != null)
            {
                if (hash.Contains(listnode))
                {
                    Console.WriteLine("Contains Values");
                    return;
                }
                hash.Add(listnode);
                listnode = listnode.next;
            }
        }

        public static void isLinkListRepeated()
        {
            // Create nodes
            ListNode listnode = new ListNode(1);
            ListNode listnode2 = new ListNode(2);
            ListNode listnode3 = new ListNode(3);
            ListNode listnode4 = new ListNode(4);
            ListNode listnode5 = new ListNode(5);
            ListNode listnode6 = new ListNode(6);

            // Connect nodes to form a linked list
            listnode.next = listnode2;
            listnode2.next = listnode3;
            listnode3.next = listnode4;
            listnode4.next = listnode5;
            listnode5.next = listnode6;

            // Create a cycle by connecting the last node to a previous node
            listnode6.next = listnode3; // This creates a cycle between node 6 and node 3

            ListNode copy = listnode;
            if (listnode == null)
            {
                return;
            }
            while (listnode?.next?.next != null)
            {
                copy = copy.next;
                listnode = listnode.next.next;
                if (listnode == copy)
                {
                    Console.WriteLine("Contains Cycle");
                    return;
                }
            }
            Console.WriteLine("Doesnt contains Cycle");
            return;

        }
        public static void reversedStringInPlace()
        {
            char[] c = new char[] { 'H', 'E', 'L', 'L', '0' };
            int a_p = 0;
            int b_p = c.Length - 1;
            while (a_p < b_p)
            {
                char t = c[a_p];
                c[a_p] = c[b_p];
                c[b_p] = t;
                a_p++; b_p--;
            }
        }

        public static void validPalindrome()
        {
            char[] c = new char[] { 'H', 'E', 'L', 'L', '0' };
            int a_p = 0;
            int b_p = c.Length - 1;
            while (a_p < b_p)
            {
                char t = c[a_p];
                c[a_p] = c[b_p];
                c[b_p] = t;
                a_p++; b_p--;
            }
        }

        public static ListNode Middle_ListNode()
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

            while (second?.next?.next != null)
            {
                second = second.next.next;
                first = first.next;
            }
            return first;

        }


        public static ListNode Merge2List()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(3);
            l1.next.next = new ListNode(5);
            l1.next.next.next = new ListNode(7);

            ListNode l2 = new ListNode(2);
            l2.next = new ListNode(4);
            l2.next.next = new ListNode(6);
            l2.next.next.next = new ListNode(8);
            l2.next.next.next.next = new ListNode(10);
            l2.next.next.next.next.next = new ListNode(12);

            ListNode head;

            if (l1.val > l2.val)
            {
                head = l2;
                l2 = l2.next;
            }
            else
            {
                head = l1;
                l1 = l1.next;
            }
            ListNode temp = head;
            while (l1.next != null || l2.next != null)
            {
                if (l1.next != null && l2.next != null)
                {
                    if (l1.val > l2.val)
                    {
                        head.next = l2;
                        l2 = l2.next;
                    }
                    else
                    {
                        head.next = l1;
                        l1 = l1.next;
                    }
                    head = head.next;
                }
                else if (l1.next != null)
                {
                    head.next = l1;
                    l1 = l1.next;
                    head = head.next;

                }
                else if (l2.next != null)
                {
                    head.next = l2;
                    l2 = l2.next;
                    head = head.next;
                }
            }

            return temp;

        }

        public static void ReturnToOrigin()
        {
            string movements = "UDLRRLPUDD";
            int lr = 0, ud = 0;
            for (int i = 0; i < movements.Length; i++)
            {
                switch (movements[i])
                {
                    case 'U':
                        ud++;
                        break;

                    case 'D':
                        ud--;
                        break;

                    case 'L':
                        lr--;
                        break;
                    case 'R':
                        lr++;
                        break;
                    default:
                        break;
                }
            }
            if (lr == 0 && ud == 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }

        public static bool CanVisitAllRooms()
        {
            IList<IList<int>> rooms = new List<IList<int>> {
            new List<int> {1, 3},
            new List<int> {3, 0, 1},
            new List<int> {2},
            new List<int> {0},
            new List<int> {0}
        };

            bool[] seen = new bool[rooms.Count()];
            foreach (var r in rooms)
            {
                foreach (var key in r)
                {
                    seen[key] = true;
                }
            }

            var isAllSeen = !seen.Any(x => !x);
            return isAllSeen;
        }

        public static void sortSquare()
        {
            //this list is sorted
            int[] numbers = { -4, -1, 0, 3, 10 };
            //find the index of first non negative number 
            int negativePointer = 0;
            while (negativePointer < numbers.Length && numbers[negativePointer] < 0)
            {
                negativePointer++;
            }
            int pp = negativePointer;
            int np = negativePointer - 1;
            int[] sorted = new int[numbers.Length];
            int c = 0;
            while (pp < numbers.Length && np >= 0)
            {
                if ( (numbers[pp] * numbers[pp] ) < ( numbers[np] * numbers[np] ))
                {
                    sorted[c] = numbers[pp] * numbers[pp];
                    pp++;
                }
                else
                {
                    sorted[c] = numbers[np] * numbers[np];
                    np--;
                }
                c++;
            }
            while (pp < numbers.Length)
            {
                sorted[c] = numbers[pp] * numbers[pp];
                pp++;c++;
                
            }
            while(np > 0)
            {
                sorted[c] = numbers[np] * numbers[np];
                np--; c++;
            }
        }
    }
}
