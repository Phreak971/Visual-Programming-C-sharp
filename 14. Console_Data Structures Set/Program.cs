using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Data_Structures_Set
{
    class Program
    {   //Interface->   ISet     ->  ISet<datatype> set = new HashSet<datatype>(); or ISet<datatype> set = new SortedSet<datatype>();
        //Class    ->   SortedSet->  SortedSet<datatype> set = new SortedSet<datatype>();
        //Class    ->   HashSet  ->  HashSet<datatype> set = new HashSet<datatype>();
        static void Main(string[] args)
        {
            /*SortedSet sorts the values in the set in ascending order*/
            //SortedSet Implements ISet Interface
            Console.WriteLine("Sorted Set");
            SortedSet<string> mySet = new SortedSet<string>();     //ISet<string> mySet = new SortedSet<string>(); is also valid
            mySet.Add("D"); //adding value to set
            display(mySet); // D
            mySet.Add("A");
            display(mySet); //  A D  
            mySet.Add("C");
            display(mySet); //  A   C   D
            mySet.Add("B");
            display(mySet); //  A   B   C   D

            //Hash Set is unordered set
            Console.WriteLine("Hash Set");
            //HashSet also Implements ISet Interface
            HashSet<string> hashSet = new HashSet<string>();    //ISet<string> hashSet = new HashSet<string>(); is also valid
            hashSet.Add("D"); //adding value to set
            display(hashSet); // D
            hashSet.Add("A");
            display(hashSet); //  D   A  
            hashSet.Add("C");
            display(hashSet); //  D   A   C
            hashSet.Add("B");
            display(hashSet); //  D   A   C   B

            //Same Display Function is being used for both sets as the function takes Parent Interface Object to catch reference
            //As Both SortedSet and HashSet implement the ISet Interface the display Function is valid for both
        }
        static void display(ISet<string> set)
        {
            foreach (string s in set)   //treversal using foreach loop
            {
                Console.Write(s + ", ");
            }
            Console.WriteLine();
        }
    }
}
