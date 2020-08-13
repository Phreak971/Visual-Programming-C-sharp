using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Delegates are Like Pointers to Functions
namespace Delegates
{
    //Suppose this scenario where there are more than one grading criteria ... So the result class becomes unusable if we code the logic of grading inside it
    class Results
    {
        public string name { set; get; }
        public double marks { set; get; }
        public void Show_Result(Grades getGrade)
        {
            Console.WriteLine("Name: {0}\nMarks: {1}\nGrade: {2}", name, marks, getGrade(marks));
        }
    }
    delegate char Grades(double marks);  //We create a delegate that points to the required Criteria
    class Program
    {
        static void Main(string[] args)
        {
            Grades getGrade = new Grades(GradingCriteria_1);    //pointing towards first criteria
            //getGrade(result.marks);
            Results result = new Results();
            result.name = "Mateen";
            result.marks = 88;
            result.Show_Result(getGrade);   //grades displayed by criteria 1
            getGrade = new Grades(GradingCriteria_2);   //pointing towards second criteria
            result.Show_Result(getGrade);   //grades displayed by criteria 2
        }
        public static char GradingCriteria_1(double marks)
        {
            if (marks > 85 && marks < 100) { return 'A'; }
            else if (marks > 75) { return 'B'; }
            else if (marks > 65) { return 'C'; }
            else if (marks > 50) { return 'D'; }
            else if (marks < 50) { return 'F'; }
            else { return '\0'; }
        }
        public static char GradingCriteria_2(double marks)
        {
            if (marks > 90 && marks < 100) { return 'A'; }
            else if (marks > 70) { return 'B'; }
            else if (marks > 50) { return 'C'; }
            else if (marks > 40) { return 'D'; }
            else if (marks < 40) { return 'F'; }
            else { return '\0'; }
        }
    }
}
