using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Class1
    {
        Queue<int> queue;
        public Class1()
        {
            queue = new Queue<int>();
        }
        public int Ping(int t)
        {
            queue.Enqueue(t);
            while (queue.Peek() < t-3000)
            {
                queue.Dequeue();
            }

            return queue.Count;
        }

        
    }
}
