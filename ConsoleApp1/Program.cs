using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
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

        static void Main(string[] args)
        {
            //    char[][] grid = new char[][] {
            //    new char[] { '1', '1', '1', '0', '0' },
            //    new char[] { '1', '1', '0', '1', '0' },
            //    new char[] { '1', '1', '0', '0', '0' },
            //    new char[] { '0', '0', '1', '0', '1' }
            //};

            //var wxs = Solution.NumIslands(grid);
            //Console.WriteLine(wxs);
            //var s = Solution.Pascal_Triangle(0);
            //for (int i = 0; i < s.Count; i++)
            //{
            //    Console.Write("List" + (i + 1) + ": ");
            //    foreach (var num in s[i])
            //    {
            //        Console.Write(num + " ");
            //    }
            //    Console.WriteLine();
            //}
            //int[] nums = { 1, 2, 3, 5 };
            //var y = Solution.Contains_Duplicate(nums);
            //Console.WriteLine(y);

            //ListNode head = new ListNode(1);
            //head.next = new ListNode(2);
            //head.next.next = new ListNode(3);
            //head.next.next.next = new ListNode(4);
            //head.next.next.next.next = new ListNode(5);
            //Solution.reverseListNode(null);

            //int[] numbers = { 0, 0, 0, 0, 0 , 1 , 1 , 1};
            //int[] numbers = { 1, 2, 3, 4, 5 };
            //var e = Solution.twoSum(numbers , 9);
            //var e = Solution.Palindrome_ListNode();
            //if (e)
            //{
            //    Console.Write("Yes");
            //}
            //else
            //{
            //    Console.Write("No");
            //}
            //var s = Solution.flatten_Tree();
            //if (s)
            //{
            //    Console.WriteLine("Perfect");
            //}
            //else
            //{
            //    Console.WriteLine("Not Perfect");
            //}
            //var Ss = Solution.BinarySearch(numbers , 8);
            Solution.TransposeMatrix();
            //Class1 c = new Class1();
            //int[] arr = new int[] { 1, 1000, 3001, 3002 };
            //foreach(int a in arr)
            //{
            //    c.Ping(a);
            //}


        }
    }
}
