using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Data_Structures_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] BSCS_V = new string[3] { "Section A", "Section B", "Section C" };  //creating array of 3 size and initializing
            //array can be left uninitialized like string[] BSCS_F17 = new string[3];
            Console.WriteLine("Before:");
            for (int i = 0; i < BSCS_V.Length; i++) //treverse the array using for loop
            {
                Console.WriteLine(BSCS_V[i]);
            }
            //This time there is also a 4th Section is BSCS V ... now where to add that?
            Array.Resize<string>(ref BSCS_V, 4);    //Resizing Array    //Array.Resize<DataTypeOfArray>(reference of Array, newSize);
            BSCS_V[3] = "Section D";
            //The mehtod above is named resize but It doesnot resize the array instead it creates a new array of size 4, copies its elements
            //and replaces it with the old one
            Console.WriteLine("After:");
            foreach (string i in BSCS_V) //we can also treverse the array using foreach loop
            {
                Console.WriteLine(i);
            }
        }
    }
}
