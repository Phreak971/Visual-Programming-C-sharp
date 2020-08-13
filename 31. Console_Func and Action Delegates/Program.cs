using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Func_and_Action_Delegates
{
    //C# has built in generic delegates Action delegate and Func Delegate
    //Action delegate is used for functions with no return values
    //Func Delegate is used for functions with a return type
    class SumFunctions
    {
        public static void ShowSumIntergers(int a, int b)  //for action delegate
        {
            Console.WriteLine(a + b);
        }
        public static void ShowSumDoubles(double a, double b)    //for action delegate
        {
            Console.WriteLine(a + b);
        }
        public static int AddIntegers(int a, int b)    //for func delegate
        {
            return a + b;
        }
        public static double AddDoubles(double a, double b)    //for func delegate
        {
            return a + b;
        }
    }
    class Program
    {
        
        //delegate T getSum<T>(T a, T b); we will not create our own we will use Action and Func
        static void Main(string[] args)
        {
            //Action
            //The Two <int, int> means the datatype of parameters in the function ShowSumIntegers
            Action<int, int> action = new Action<int, int>(SumFunctions.ShowSumIntergers);
            action(5, 6);   //11
            //The Two <double, double> mean the datatype of parameters in the function ShowSumDoubles
            Action<double, double> action1 = new Action<double, double>(SumFunctions.ShowSumDoubles);
            action1(5.44, 6.03);   //11.47
            //Func
            //The First two ints mean paramerters and last int means the return type of function Add Intergers
            Func<int, int, int> func = new Func<int, int, int>(SumFunctions.AddIntegers);
            Console.WriteLine(func(5, 6));
            //parameter 1 = double parameter 2 = double return type = double
            Func<double, double, double> func1 = new Func<double, double, double>(SumFunctions.AddDoubles);
            Console.WriteLine(func1(5.44, 6.03));
        }
    }
}