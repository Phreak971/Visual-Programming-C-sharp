using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Functions_and_Passing_by_Ref_or_Value
{
    class Program
    {
        int class_integer;
        void change(int Simple_Integer, ref int simple_Integer2, int[] Array, Program Class_Oject)
        {
            Simple_Integer = 100;
            simple_Integer2 = 100;
            Array = new int[] { 1, 2, 3, 4, 5 };
            Class_Oject.class_integer = 100;
        }
        static void Main(string[] args)
        {
            int num = 5;    
            int num2 = 10;
            int[] arr = new int[] { 5, 5, 5, 5 };
            Program obj = new Program();
            obj.class_integer = 5;
            Console.WriteLine("Initial Values:");
            Console.WriteLine(num);
            Console.WriteLine(num2);
            Console.WriteLine(string.Join(",", arr));
            Console.WriteLine(obj.class_integer);
            obj.change(num,ref num2/*pass by ref*/, arr, obj);
            Console.WriteLine("After Function Call Values:");
            Console.WriteLine(num); //same
            Console.WriteLine(num2);    //changed because passed by ref
            Console.WriteLine(string.Join(",", arr));   //same
            Console.WriteLine(obj.class_integer);   //changed beacuse class objct is passed as ref
        }
    }
}