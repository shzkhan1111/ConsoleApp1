﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            //Solution.LeastDistFromStop();
            //if (t)
            //{
            //    Console.WriteLine("Yes");
            //}
            //else
            //{
            //    Console.WriteLine("No");
            //}
            Solution.sortColors();
            //var ss = Solution.sortColors();
            //TicTakToe ticTakToe = new TicTakToe();
            //int row = 0;
            //int col = 0;
            //int player = 0;
            //do
            //{
            //    Console.WriteLine("Enter value for row and column");
            //    row = (Console.ReadKey().KeyChar - '0');
            //    col = (Console.ReadKey().KeyChar - '0');
            //    player++;
            //} while (!ticTakToe.makeAMove(row, col, player % 2));
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //Type type = assembly.GetType("ConsoleApp1.Person");
            //object personInstance = Activator.CreateInstance(type);
            //PropertyInfo nameProperty = type.GetProperty("Name");
            //nameProperty.SetValue(personInstance, "Hello someone");
            //PropertyInfo ageproperty= type.GetProperty("Age");
            //ageproperty.SetValue(personInstance, 30);

            //MethodInfo secretMethod = type.GetMethod("SecretMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            //secretMethod.Invoke(personInstance, null);

            //MethodInfo setValuesAndPrintMethod = type.GetMethod("setValuesandprint", BindingFlags.NonPublic | BindingFlags.Instance);
            //setValuesAndPrintMethod.Invoke(personInstance, new object[] {10, 20});



        }
    }
}
