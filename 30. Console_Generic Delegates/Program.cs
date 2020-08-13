using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Generic_Delegates
{   //Lets Say we have two functions for finding sum with different parameters or return values
    //The delegates we used work for functions that had the same parameters and return values
    //To Carry out this task we will use generic delegates
    class Sum
    {
        static int AddIntegers(int a, int b) //1st function
        {
            return a + b;
        }
        static double AddDoubles(double a, double b) //2nd function
        {
            return a + b;
        }
        //now instead of creating different delegates for all functions we will make a generic delegate that works for all of them
        delegate T getSum<T>(T a, T b); //first T means generic return Type 
        static void Main(string[] args)
        {
            getSum<int> sum = new getSum<int>(AddIntegers); //int type for AddIntegers
            int result = sum(10, 20);
            Console.WriteLine(result);
            getSum<double> Dsum = new getSum<double>(AddDoubles);   //double type for doubles
            double dresult = Dsum(5.55, 6.23);  //calling AddDoubles Method
            Console.WriteLine(dresult);
        }
    }
}
