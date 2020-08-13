using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ClassMembers_and_Object_Members_ie_Static_vs_Non_Static
{
    public class BSCS_VD
    {
        //non static members/Members of Object ... Every object has its own Name and RegID
        public string Name { set; get; }
        public int RegID { set; get; }
        //static member ie member of class ... the class has a Student List
        public static LinkedList<BSCS_VD> StudentList { get; set; } = new LinkedList<BSCS_VD>();
        /*Why StudentList is Static?
         Student list is member of class because one student does not have a student list
        The class has a list of students hence it is member of class ie static*/
        public BSCS_VD()
        {

        }
        public BSCS_VD(string Name, int RegID)    //parameterized constructor to initialize object and add name and reg
        {
            this.Name = Name;
            this.RegID = RegID;
            StudentList.AddLast(this);  //Constructor also adds the current object to the student list
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BSCS_VD[] students = new BSCS_VD[5];    //array of objects
            students[0] = new BSCS_VD("Kaleem <3 Khan", 170344);
            students[1] = new BSCS_VD("Mateen Ahmed", 170360);  //initialized using constructor
            students[2] = new BSCS_VD("Hidayat ur Rehman", 170288);
            students[3] = new BSCS_VD("Shazeel Khalil Ahmed", 170420);
            students[4] = new BSCS_VD();
            students[4].Name = "Awais Abbas Kazmi"; students[4].RegID = 170364;   // initialized using setter ... members of Object
            BSCS_VD.StudentList.AddLast(students[4]);   //Here static member is called by class name whereas non static members are called by object in above line

            //Displaying all students using the member of class students list
            foreach (var AllStudentsList in BSCS_VD.StudentList)
            {
                Console.WriteLine("Name: " + AllStudentsList.Name);
                Console.WriteLine("RegID: " + AllStudentsList.RegID);
            }
        }
    }
}
