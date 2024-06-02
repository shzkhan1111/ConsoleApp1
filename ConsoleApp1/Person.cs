using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void PrintDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }

        private void SecretMethod()
        {
            Console.WriteLine("This is a secret method.");
        }
        private void setValuesandprint(int a, int b)
        {
            Console.WriteLine($"{a + b}");
        }
    }
}
