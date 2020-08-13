using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Data_Structures_List
{
    class Program
    {
        /*Lists
          Interface-> IList<> IList<int> ListObject = new List<>();
          Classe->    List<>  List<int> ListObject = new List<>(); 
          Classes->   ArrayList<> ArrayList<int> ListObject = new ArrayList<>();  can have multiple data Types
          Other Lists
          Classes->  LinkedList<>   LinkedList<int> ListObject = new LinkedList<>();
        */
        static void Main(string[] args)
        {
            Console.WriteLine("List");
            //List Implements Interface IList
            List<int> ListObject = new List<int>();  //IList<int> ListObject = new List<int>(); can also be used to create it
            ListObject.Add(23);
            ListObject.Add(34);  //Adding values to List
            ListObject.Add(75);
            DisplayList(ListObject);
            ListObject.Remove(75);  //value 75 will be removed from list if 75 does not exist noting will happen to list
            DisplayList(ListObject);
            ListObject.Clear(); //clears List
            DisplayList(ListObject);    //nothing will be displayed
            //LinkedList Implements ICollection<T>
            Console.WriteLine("\nLinkedList");
            LinkedList<string> StudentsList = new LinkedList<string>();// ICollection<string> StudentsList = new LinkedList<string>(); can also be used to create
            StudentsList.AddLast("Mateen");
            StudentsList.AddLast("Abdur Rehman");
            StudentsList.AddLast("Shazeel");
            StudentsList.AddLast("Awais");
            StudentsList.AddLast("Paris");
            Console.WriteLine("\nSize of LinkedList: " + StudentsList.Count + " ... Displaying List:");
            foreach (var v in StudentsList)   //Treversing list with foreach loop
            {
                Console.Write(v + ", ");
            }
            Console.WriteLine("\n\nArrayList");
            //List Implements Interface IList
            ArrayList ArrayListRandom = new ArrayList();    //IList ArrayListRandom = new ArrayList(); can also be used to create it
            ArrayListRandom.Add("Pakistan");
            ArrayListRandom.Add(1947);  //An arraylist can have various types of data in it
            ArrayListRandom.Add(true);
            Console.WriteLine("\nSize of ArrayList: " + ArrayListRandom.Count + " ... Showing ArrayList");
            foreach (var v in ArrayListRandom)  //treversal
            {
                Console.Write(v + ", ");
            }
            Console.WriteLine();
            ArrayListRandom.Reverse();  //Reversing ArrayList
            Console.WriteLine("\nSize of ArrayList: " + ArrayListRandom.Count + " ... Showing ArrayList");
            for (int i = 0; i < ArrayListRandom.Count; i++) //we can also display it using for loop
            {
                Console.Write(ArrayListRandom[i] + ", ");
            }
        }


        static void DisplayList(List<int> objOfList)    //dispays list
        {
            Console.WriteLine("\nSize of List: " + objOfList.Count + " ... Displaying List:");
            foreach (var v in objOfList)   //trevering list with foreach loop
            {
                Console.Write(v + ", ");
            }
        }
    }
}
