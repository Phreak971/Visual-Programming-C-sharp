//This Program reads inputs from Console and Convert them to Required Datatypes
//We can only take input as string from console
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Taking_Inputs_And_Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a String");
            string input = Console.ReadLine();      //reads input from console
            Console.WriteLine("This is a string: " + input);  //concatenating with hard coded string "This is a string: "

            Console.WriteLine("Enter an Integer");
            try
            {
                int int_input = Int32.Parse(Console.ReadLine());    //read integer and parse to int
            }
            catch
            {
                Console.WriteLine("Not an Integer");    //throw exception if parsing fails
                /*parsing fails when the input is null
                the input is not in a valid format
                the input contains a number that procudes an overflow*/
            }
            //similarly we can parse to float by using float.parse(string_input)
        }
    }
}
