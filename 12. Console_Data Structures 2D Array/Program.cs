using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Data_Structures_2D_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[3, 3];   //2D array Created
            //We can also initialize it with initializer list like ... int[,] arr = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            arr[0, 0] = 11;
            arr[0, 1] = 12;
            arr[0, 2] = 13;
            arr[1, 0] = 21;
            arr[1, 1] = 22; //assigning values
            arr[1, 2] = 23;
            arr[2, 0] = 31;
            arr[2, 1] = 32;
            arr[2, 2] = 33;
            for (int i = 0; i < arr.GetLength(0); i++)  //GetLength(0) returns lenth of first dimension
            {
                for (int j = 0; j < arr.GetLength(1); j++)  //GetLength(1) returns lenth of second dimension
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            foreach (int i in arr)  //For simple treversal foreach can also be used
            {
                Console.Write(i + ",");
            }
            //  int[,,,] _4Array = new int[2, 3, 4, 6]; //similarly there can be many dmensions of array like 3D array 4D 
        }
    }
}
