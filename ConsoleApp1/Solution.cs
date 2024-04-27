using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
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
                if ((numbers[pp] * numbers[pp]) < (numbers[np] * numbers[np]))
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
                pp++; c++;

            }
            while (np > 0)
            {
                sorted[c] = numbers[np] * numbers[np];
                np--; c++;
            }
        }

        public static int maxAreaOfContainer()
        {
            int[] inputs = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int a_pointer = 0;
            int b_pointer = inputs.Length - 1;
            int max_area = 0;
            int temp_a = 0, temp_b = 0;
            while (a_pointer < b_pointer)
            {
                int current_MaxArea = Math.Min(inputs[a_pointer], inputs[b_pointer]) * (b_pointer - a_pointer);
                if (current_MaxArea > max_area)
                {
                    max_area = current_MaxArea;
                    temp_a = a_pointer;
                    temp_b = b_pointer;
                }
                if (inputs[a_pointer] > inputs[b_pointer])
                {
                    b_pointer--;
                }
                else
                {
                    a_pointer++;
                }
            }
            return max_area;

        }


        public static int threeSumClosestBruteForce()
        {
            //brute force approach 
            int[] inputs = { 1, 8, 6, 2, 5, 4, 8, 3, 7, 9, 10, 21, 25 };
            int target = 25;
            (int first, int second, int third) indexes = (0, 0, 0);
            int currentClosest = int.MaxValue;
            for (int i = 0; i < inputs.Length - 2; i++)
            {
                for (int j = i + 1; j < inputs.Length - 1; j++)
                {
                    for (int k = j + 1; j < inputs.Length; j++)
                    {
                        int currentSum = Math.Abs(inputs[i] + inputs[j] + inputs[k] - target);
                        if (currentClosest > currentSum)
                        {
                            currentClosest = currentSum;
                            indexes = (inputs[i], inputs[j], inputs[k]);
                        }
                    }
                }
            }

            return currentClosest;
        }
        public static int threeSumClosest2Pointer()
        {
            //brute force approach 
            int[] inputs = { 1, 8, 6, 2, 5, 4, 8, 3, 7, 9, 10, 21, 25 };
            inputs = inputs.OrderBy(x => x).ToArray();
            int target = 1;
            //(int first, int second, int third) indexes = (0, 0, 0);
            int currentClosest = int.MaxValue;

            for (int i = 0; i < inputs.Length - 2; i++)
            {
                int a_p = i + 1, b_p = inputs.Length - 1;
                while (a_p < b_p)
                {
                    int currentSum = (inputs[i] + inputs[a_p] + inputs[b_p]);
                    if (currentSum > target)
                    {
                        b_p--;
                    }
                    else
                    {
                        a_p++;
                    }
                    if (Math.Abs(currentSum - target) < Math.Abs(currentClosest - target))
                    {
                        currentClosest = currentSum;
                        //indexes = (i , a_p , b_p);
                    }
                }
            }

            return currentClosest;
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public static IList<int> LargestValuesInTree()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(3);
            root.right.right = new TreeNode(9);

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            List<int> res = new List<int>();

            if (root == null)
            {
                return res;
            }
            while (queue.Count > 0)
            {
                var levelCount = queue.Count();
                int maxValue = int.MinValue;

                for (int i = 0; i < levelCount; i++)
                {
                    var x = queue.Dequeue();
                    maxValue = Math.Max(maxValue, x.val);
                    if (x.left != null)
                    {
                        queue.Enqueue(x.left);
                    }
                    if (x.right != null)
                    {
                        queue.Enqueue(x.right);
                    }
                }
                res.Add(maxValue);
            }
            return res;
        }

        public static TreeNode TreePruning()
        {
            TreeNode root = new TreeNode(0);
            root.left = new TreeNode(0);
            root.right = new TreeNode(0);
            root.left.left = new TreeNode(0);
            root.left.right = new TreeNode(0);
            root.right.left = new TreeNode(0);
            root.right.right = new TreeNode(0);
            #region extra
            //root.left.left.left = new TreeNode(1);
            //root.left.left.right = new TreeNode(1);
            //root.left.right.left = new TreeNode(1);
            //root.left.right.right = new TreeNode(1);

            //root.right.left.left = new TreeNode(1);
            //root.right.left.right = new TreeNode(1);
            //root.right.right.left = new TreeNode(1);
            //root.right.right.right = new TreeNode(1);
            #endregion
            var res = PruneIfNot1(root);


            return root;
        }
        public static bool PruneIfNot1(TreeNode tree)
        {
            if (tree is null) return false;

            //find 1 on left
            var isLeft1 = PruneIfNot1(tree.left);
            //find 1 on right
            var isRight1 = PruneIfNot1(tree.right);

            if (!isLeft1)
            {
                tree.left = null;
            }
            if (!isRight1)
            {
                tree.right = null;
            }

            return tree.val == 1 || isLeft1 || isRight1;
        }

        public static ListNode swapNodes()
        {
            ListNode listnode = new ListNode(1);
            listnode.next = new ListNode(2);
            listnode.next.next = new ListNode(3);
            listnode.next.next.next = new ListNode(4);
            listnode.next.next.next.next = new ListNode(5);
            listnode.next.next.next.next.next = new ListNode(6);

            ListNode temp = new ListNode(0);
            temp.next = listnode;
            ListNode current = temp;
            while (current?.next?.next != null)
            {
                ListNode first = current.next;
                ListNode second = current.next.next;

                first.next = second.next;
                second.next = first;
                current.next = second;
                current = current.next.next;
            }

            return temp.next;
        }

        public static TreeNode TreeNodeBottomLeft()
        {
            TreeNode root = new TreeNode(2);
            root.left = new TreeNode(1);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.right.left = new TreeNode(5);
            root.right.left.right = new TreeNode(10);
            root.right.left.left = new TreeNode(11);
            root.right.right = new TreeNode(6);


            Queue<TreeNode> qtreeNode = new Queue<TreeNode>();
            qtreeNode.Enqueue(root);
            TreeNode current = new TreeNode();
            while (qtreeNode.Count > 0)
            {
                current = qtreeNode.Dequeue();
                if (current.right != null)
                {
                    qtreeNode.Enqueue(current.right);
                }
                if (current.left != null)
                {
                    qtreeNode.Enqueue(current.left);
                }
            }
            return current;
        }

        public static ListNode PartitionNodes()
        {
            ListNode listnode = new ListNode(1);
            listnode.next = new ListNode(2);
            listnode.next.next = new ListNode(3);
            listnode.next.next.next = new ListNode(4);
            listnode.next.next.next.next = new ListNode(5);
            listnode.next.next.next.next.next = new ListNode(100);
            listnode.next.next.next.next.next.next = new ListNode(13);
            listnode.next.next.next.next.next.next.next = new ListNode(11);
            listnode.next.next.next.next.next.next.next.next = new ListNode(15);
            listnode.next.next.next.next.next.next.next.next.next = new ListNode(14);

            ListNode before = new ListNode(0);
            ListNode after = new ListNode(0);
            ListNode equals = new ListNode(0);

            ListNode beforePointer = before;
            ListNode afterPointer = after;
            ListNode equalsPointer = equals;
            int val = 13;
            while (listnode.next != null)
            {
                if (listnode.val < val)
                {
                    before.next = listnode;
                    before = before.next;
                }
                else if (listnode.val > val)
                {
                    after.next = listnode;
                    after = after.next;
                }
                else
                {
                    equals.next = listnode;
                    equals = equals.next;
                }
                listnode = listnode.next;
            }
            equals.next = afterPointer.next;
            before.next = equalsPointer.next;

            return beforePointer.next;
        }

        public static int RangeSumBst()
        {
            TreeNode root = new TreeNode(10);//
            root.left = new TreeNode(5);
            root.right = new TreeNode(15);//
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(7);//
            root.right.right = new TreeNode(18);


            int low = 7;
            int high = 15;
            var t = RangeSumImp(root, low, high);
            return t;
        }
        private static int RangeSumImp(TreeNode root, int low, int high)
        {
            int sum = 0;
            if (root is null)
            {
                return sum;
            }
            if (root.val >= low && root.val <= high)
            {
                sum = root.val;
            }

            if (root.left != null)
            {
                sum = (sum + RangeSumImp(root.left, low, high));
            }

            if (root.right != null)
            {
                sum = (sum + RangeSumImp(root.right, low, high));
            }

            return sum;

        }

        public static bool isUniTree()
        {
            TreeNode root = new TreeNode(10);//
            root.left = new TreeNode(10);
            root.right = new TreeNode(10);//
            root.left.left = new TreeNode(10);
            root.left.right = new TreeNode(8);//
            root.right.right = new TreeNode(10);

            if (root is null)
            {
                return true;
            }
            var t = iniTreeImp(root, root.val);
            return t;
        }
        private static bool iniTreeImp(TreeNode tree, int val)
        {
            bool ans = true;
            if (tree.val != val)
            {
                ans = false;
            }
            if (tree.left != null)
            {
                ans = ans && iniTreeImp(tree.left, val);
            }
            if (tree.right != null)
            {
                ans = ans && iniTreeImp(tree.right, val);
            }
            return ans;
        }

        //sum of abs value - 1 
        public static int numberofMoves = 0;
        public static int DistributeCoins()
        {
            TreeNode root = new TreeNode(0);//
            root.left = new TreeNode(5);
            root.right = new TreeNode(15);//
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(7);//
            root.right.right = new TreeNode(18);
            int res = DisTriConImp(root);
            return res;

        }

        private static int DisTriConImp(TreeNode root)
        {
            //go down to the bottom node get the value and -1 and add it to the sum
            if (root is null)
            {
                return 0;
            }
            int leftSum = DisTriConImp(root.left);
            int rightSum = DisTriConImp(root.right);
            numberofMoves += Math.Abs(leftSum) + Math.Abs(rightSum);
            return root.val + leftSum + rightSum - 1;
        }



        //complete Binary tree 
        //every level exept the last is completly filled 
        //all nodes left as possible left filled right may remain empty 


        public static bool completeBinTree()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            //root.right.right = new TreeNode(6);
            root.right.left = new TreeNode(6);
            root.right.left.left = new TreeNode(6);
            root.right.left.left.right = new TreeNode(6);
            root.right.left.left.right.left = new TreeNode(6);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root == null)
            {
                return true;
            }
            queue.Enqueue(root);
            bool nullSeen = false;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == null)
                {
                    nullSeen = true;
                }
                else
                {
                    if (nullSeen)
                    {
                        return false;
                    }
                }

                if (current != null)
                {
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }

            return true;
        }

        public static int widthOftree()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(3);
            root.right.right = new TreeNode(9);

            Queue<TreeNode> queue = new Queue<TreeNode>();
            Queue<int> indexes = new Queue<int>();
            if (root == null)
            {
                return 0;
            }
            queue.Enqueue(root);
            indexes.Enqueue(1);
            //Algo 
            /*
             * get the current element in the queue 
             * with its index value 
             * get the current size of the q and by that add new elemnt in the q 
             * get the last index with the width of the left - right 
             * check if this width at the current level is the max if so than 
             * update max
             */
            int max = -1;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                int leftIndex = indexes.Peek();
                int rightIndex = leftIndex;

                for (int i = 0; i < size; i++)
                {
                    TreeNode current = queue.Dequeue();
                    int index = indexes.Dequeue();
                    rightIndex = index;
                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                        indexes.Enqueue(index * 2);
                    }
                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                        indexes.Enqueue((index * 2) + 1);
                    }
                }
                max = Math.Max(max, rightIndex - leftIndex + 1);
            }
            return max;
        }

        public static void flatten_Tree()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(3);
            root.right.right = new TreeNode(9);

            if (root is null)
            {
                return;
            }
            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(root);
            while (s.Count > 0)
            {
                var current = s.Pop();
                if (current.right != null)
                {
                    s.Push(current.right);
                }
                if (current.left != null)
                {
                    s.Push(current.left);
                }
                current.left = null;
                if (s.Count > 0)
                    current.right = s.Peek();

            }

        }

        public static List<int> rightSide_Tree()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(3);
            root.right.right = new TreeNode(9);

            List<int> result = new List<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            if (root is null)
            {
                return result;
            }
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var current = q.Dequeue();
                    if (i == 0)
                    {
                        result.Add(current.val);
                    }
                    if (current.right != null)
                    {
                        q.Enqueue(current.right);
                    }
                    if (current.left != null)
                    {
                        q.Enqueue(current.left);
                    }
                }
            }

            return result;
        }

        public static int numOfStonesAndJewels1()
        {
            string jewels = "aA";
            string stones = "aAAbbbb";

            var x = jewels.ToCharArray().Intersect(stones.ToCharArray());
            int abs = x.Count();
            return abs;
        }

        public static int numOfStonesAndJewels()
        {
            string jewels = "aA";
            string stones = "aAAbbbb";
            HashSet<char> jewelSet = new HashSet<char>();

            foreach (var j in stones)
            {
                jewelSet.Add(j);
            }
            int c = 0;
            foreach (var s in jewels)
            {
                if (jewelSet.Contains(s))
                {
                    c++;
                }
            }

            return c;
        }

        public static ListNode SortNodes()
        {
            ListNode listnode = new ListNode(100);
            listnode.next = new ListNode(2);
            listnode.next.next = new ListNode(3);
            listnode.next.next.next = new ListNode(205);
            //listnode.next.next.next.next = new ListNode(5);
            //listnode.next.next.next.next.next = new ListNode(99);
            //listnode.next.next.next.next.next.next = new ListNode(13);
            //listnode.next.next.next.next.next.next.next = new ListNode(11);
            //listnode.next.next.next.next.next.next.next.next = new ListNode(15);
            //listnode.next.next.next.next.next.next.next.next.next = new ListNode(14);
            listnode = SplitNodes(listnode);



            return listnode;
        }
        private static ListNode SplitNodes(ListNode listnode)
        {
            if (listnode?.next == null)
            {
                return listnode;
            }
            ListNode slow = listnode;
            ListNode fast = listnode;
            ListNode temp = listnode;

            while (fast?.next != null)
            {
                fast = fast.next.next;
                temp = slow;
                slow = slow.next;
            }
            temp.next = null;
            ListNode left = SplitNodes(listnode);
            ListNode right = SplitNodes(slow);
            var vxd = MergeListNode(left, right);
            return vxd;
        }

        private static ListNode MergeListNode(ListNode left, ListNode right)
        {
            ListNode tempNode = new ListNode(0);
            ListNode current = tempNode;
            while (left != null && right != null)
            {
                if (left.val < right.val)
                {
                    current.next = left;
                    left = left.next;
                }
                else
                {
                    current.next = right;
                    right = right.next;
                }
                current = current.next;
            }
            while (left != null)
            {
                current.next = left;
                left = left.next;
                current = current.next;
            }
            while (right != null)
            {
                current.next = right;
                right = right.next;
                current = current.next;
            }

            return tempNode.next;
        }

        public static bool searchBinary_Tree()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            //root.right.right = new TreeNode(6);
            root.right.left = new TreeNode(32);
            root.right.left.left = new TreeNode(11);
            root.right.left.left.right = new TreeNode(41);
            root.right.left.left.right.left = new TreeNode(90);

            int number = 41;
            var x = searchBinary_TreeImp(root, number);
            return !(x is null);

        }
        private static TreeNode searchBinary_TreeImp(TreeNode treeNode, int number)
        {
            if (treeNode is null)
            {
                return null;
            }
            if (treeNode.val == number)
            {
                return treeNode;
            }
            var left = searchBinary_TreeImp(treeNode.left, number);
            if (left != null)
            {
                return left;
            }
            var right = searchBinary_TreeImp(treeNode.right, number);
            if (right != null)
            {
                return right;
            }

            return null;

        }


        public static int PeakIndexInMountainArray()
        {
            int[] arr = { 0, 2, 5, 10, 1, 0 };
            int le = 0; int ri = arr.Count() - 1;
            int mid = le + ((ri - le) / 2);

            while (le < ri)
            {
                if (arr[mid] < arr[mid - 1])
                {
                    ri = mid;
                }
                else
                {
                    le = mid + 1;
                }

                mid = le + ((ri - le) / 2);
            }

            return le;

        }

        public static int sumOfLeftNodesDfs()
        {

            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            var x = sumOfLeftNodesDfsImpStack(root);

            return x;

        }
        private static int sumOfLeftNodesDfsImp(TreeNode root)
        {
            int sumOfLeftNodes = 0;
            if (root is null)
            {
                return 0;
            }
            if (root.left != null)
            {
                if (root.left.left is null && root.left.right is null)
                    sumOfLeftNodes += root.left.val;
                else
                    sumOfLeftNodes += sumOfLeftNodesDfsImp(root.left);

            }
            if (root.right != null)
            {
                //this is not a leaf but a tree branch
                if (root.right.left != null || root.right.right != null)
                    sumOfLeftNodes += sumOfLeftNodesDfsImp(root.right);
            }

            return sumOfLeftNodes;

        }

        private static int sumOfLeftNodesDfsImpStack(TreeNode node)
        {
            if (node is null)
            {
                return 0;
            }

            int sum = 0;
            Stack<TreeNode> stackTree = new Stack<TreeNode>();
            stackTree.Push(node);
            while (stackTree.Count > 0)
            {
                TreeNode root = stackTree.Pop();
                if (root.left != null)
                {
                    if (root.left.left is null && root.left.right is null)
                    {
                        sum += root.left.val;
                    }
                    else
                    {
                        stackTree.Push(root.left);
                    }
                }
                if (root.right != null)
                {
                    if (root.right.left != null && root.right.right != null)
                    {
                        stackTree.Push(root.right);
                    }
                }
            }

            return sum;

        }


        public static string reverseCharOnlyStringV1()
        {
            string r = "a-bc-def-ghij";
            Stack<char> schars = new Stack<char>();
            for (int i = 0; i < r.Length; i++)
            {
                if (char.IsLetter(r[i]))
                {
                    schars.Push(r[i]);
                }
            }
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < r.Length; i++)
            {
                if (!char.IsLetter(r[i]))
                {
                    res.Append(r[i]);
                }
                else
                {
                    res.Append(schars.Pop());
                }
            }
            string output = res.ToString();
            return output;
        }

        public static string reverseCharOnlyString()
        {
            string r = "a-bc-def-ghij";
            StringBuilder sb = new StringBuilder();
            int j = r.Length - 1;

            for (int i = 0; i < r.Length; i++)
            {
                if (char.IsLetter(r[i]))
                {
                    while (!char.IsLetter(r[j]))
                    {
                        j--;
                    }
                    sb.Append(r[j]);
                    j--;
                }
                else
                {
                    sb.Append(r[i]);
                }
            }
            var rrr = sb.ToString();
            return rrr;
        }

        public static List<int> SprialMatrixesV1()
        {
            List<int> res = new List<int>();

            int[][] matrix = new int[][] {
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 6, 7, 8, 9, 10 },
            new int[] { 11, 12, 13, 14, 15 },
            new int[] { 16, 17, 18, 19, 20 }
            //new int[] { 21, 22, 23, 24, 25 }
        };
            int start_row = 0, end_row = matrix.Length - 1;
            int start_col = 0, end_col = matrix[0].Length - 1;

            while (start_row <= end_row && start_col <= end_col)
            {
                for (int i = start_col; i <= end_col; i++)
                {
                    res.Add(matrix[start_row][i]);
                }
                start_row++;
                for (int i = start_row; i <= end_row; i++)
                {
                    res.Add(matrix[i][end_col]);
                }
                end_col--;

                for (int i = end_col; i >= start_col; i--)
                {
                    res.Add(matrix[end_row][i]);
                }
                end_row--;


                for (int i = end_row; i >= start_row; i--)
                {
                    res.Add(matrix[i][start_col]);
                }
                start_col++;
            }
            return res;

        }

        public static int[][] SprialMatrixes()
        {

            int[][] matrix = new int[][] {
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 6, 7, 8, 9, 10 },
            new int[] { 11, 12, 13, 14, 15 },
            new int[] { 16, 17, 18, 19, 20 }
            //new int[] { 21, 22, 23, 24, 25 }
        };
            int l = matrix[0].Length;
            int[][] res = new int[matrix.Length][];

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new int[matrix[i].Length];
            }
            int count = 1;
            int row_start = 0, row_end = matrix.Length - 1, col_start = 0, col_end = matrix[0].Length - 1;

            while (row_start <= row_end && col_start <= col_end)
            {
                for (int i = col_start; i <= col_end; i++)
                {
                    res[row_start][i] = count++;
                }
                row_start++;

                for (int i = row_start; i <= row_end; i++)
                {
                    res[i][col_end] = count++;
                }   
                col_end--;

                for (int i = col_end; i >= col_start; i--)
                {
                    res[row_end][i] = count++;
                }
                row_end--;

                for (int i = row_end; i >= row_start; i--)
                {
                    res[i][col_start] = count++;
                }
                col_start++;


            }
            for (int i = 0;i < res.Length;i++)
            {
                for (int j = 0; j < res[i].Length; j++)
                {
                    Console.Write($"{res[i][j]}, ");
                }
                Console.WriteLine();
            }
            return res;
        }

        public static int numOfUniqueEmails()
        {
            string[] emails = {
            "test.email+alex@leetcode.com",
            "test.e.mail+bob.cathy@leetcode.com",
            "testemail+david@lee.tcode.com",
            "zahid@kjk.euidheuid.com"
        };

            HashSet<string> uniqueEmail = new HashSet<string>();
            foreach (var e in emails)
            {
                string domain = e.Split("@")[0];
                string host = e.Split("@")[1];

                if (domain.Contains("+"))
                    domain = domain.Split("+")[0];

                string final = (domain + host).Replace(".", "");
                uniqueEmail.Add(final);
            }
            return uniqueEmail.Count();
        }
        public static int MorseCode()
        {
            string[] morseCodes = {
            ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---",
            "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-",
            "..-", "...-", ".--", "-..-", "-.--", "--.."
        };
            string[] words = { "gin", "zen", "gig", "msg" };
            
            HashSet<string> uniqueWords = new HashSet<string>();
            foreach (var w in words)
            {
                StringBuilder temp = new StringBuilder();
                foreach (var c in w)
                {
                    int index = c - 'a';
                    temp.Append(morseCodes[index]);
                }
                uniqueWords.Add(temp.ToString());
            }
            return uniqueWords.Count;

        }

        public static int[] sortArrayByParityV1()
        {
            int[] A = { 3, 1, 2, 4 ,7,8};

            int[] B = new int[A.Length];

            for (int i = 0, j = A.Length - 1, k = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    B[k] = A[i];
                    k++;
                }
                else
                {
                    B[j] = A[i];
                    j--;
                }
            }
            return B;

        }

        public static int[] sortArrayByParity()
        {
            int[] A = { 3, 1, 2, 4, 7, 8 };
            //2 pointer
            int left = 0; int right = A.Length - 1;
            while (left < right)
            {
                //odd even
                if (A[left] % 2 > A[right] % 2)
                {
                    //swap
                    int temp = A[left];
                    A[left] = A[right];
                    A[right] = temp;
                }
                if (A[left] % 2 == 0)
                {
                    left++;
                }
                if (A[right] % 2 != 0)
                {
                    right--;
                }
            }
            
             
            
            return A;

        }

        //single num with no extra space 
        /// <summary>
        /// number appear 2 times except 1 number 
        /// find that number 
        /// </summary>
        /// <returns>
        /// element xor with 0 element 
        /// element xor element = 0
        /// </returns>
        public static int singleNumberNoExtraSpace()
        {
            int[] A = { 4,2,1,1,2};
            int res = 0;
            foreach (int a in A)
            {
                res ^= a;
            }
            return res;
        }

        public static List<int> selfDividingNumber()
        {
            List<int> A = new List<int>();
            int left = 1, right = 22;
            List<int> res = new List<int>();
            for(int i = left; i<= right; i++)
            {
                if (selfDividing(i))
                {
                    res.Add(i);
                }
            }
            return res;

        }
        private static bool selfDividing(int num)
        {
            int temp = num;
            while (temp > 0)
            {
                int rem = temp % 10;
                if (rem != 0)
                {
                    if (num % rem != 0)
                    {
                        return false;
                    }
                }
                
                temp /= 10;
            }
            return true;
        }

    }

}
