using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Multithreading
{
    //When We want a task to be perfromed parallel to the main thread we create a worker thread and assign that task to the worker thread
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am Main Thread");
            Thread worker = new Thread(Task);   //create thread on function Task
            worker.Start(); //call 
            Thread worker2 = new Thread(Task1); //for parameterized function
            worker2.Start("Worker 2");  // worker 2 string is passed as parameter to the thread
        }
        static void Task()
        {
            Console.WriteLine("Worker Thread");
        }
        static void Task1(object a) //can have only one parameter with object type which can accept any type
        {
            Console.WriteLine(a);
        }
    }
}
