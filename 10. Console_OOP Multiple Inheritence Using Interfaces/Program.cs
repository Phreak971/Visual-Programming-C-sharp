
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Console_OOP_Multiple_Inheritence_Using_Interfaces
{
    //We Create Interfaces for Both Parent classes and Implement them in the parent classes
    #region Parent Interfaces
    public interface IParent1
    {
        int Parent1member { set; get; }
        void Parent1_Function();
    }
    public interface IParent2
    {
        int Parent2member { set; get; }
        void Parent2_Function();
    }
    #endregion
    #region Parent Classes
    class Parent1 : IParent1
    {
        public int Parent1member { set; get; }
        public void Parent1_Function()
        {
            Console.WriteLine("Parent 1 Function called");
        }
    }
    class Parent2 : IParent2
    {
        public int Parent2member { set; get; }
        public void Parent2_Function()
        {
            Console.WriteLine("Parent 2 Function called");
        }
    }
    #endregion

    class Child : IParent1, IParent2    // A class can be inherited from 2 interface ... but it has to implment all members of both the interfaces
    {
        private Parent1 parent1 = new Parent1();
        private Parent2 parent2 = new Parent2();
        public int Parent1member { set; get; } = 1;
        public void Parent1_Function()  //Now call Parent Class Functions from here
        {
            parent1.Parent1_Function();
        }
        public int Parent2member { set; get; } = 2;
        public void Parent2_Function()  //Now call Parent Class Functions from here
        {
            parent2.Parent2_Function();
        }
    }
    /* Not Possible
class Child : Parent1, Parent2
{

}*/
    class Program
    {
        static void Main(string[] args)
        {
            //Now we can access both parent1 class and Parent 2 class members and mehtods from child class object
            Child ChildObject = new Child();
            Console.WriteLine(ChildObject.Parent1member);
            ChildObject.Parent1_Function();
            Console.WriteLine(ChildObject.Parent2member);
            ChildObject.Parent2_Function();
        }
    }
}
/*	About			
				                        class Parent1	   class Parent2
                                                  \	     	/																	/
                                                   \       /				
           As we know that                          \     /         Not Possible in C#
               inheriting a class from               \   /
              2 classes is not possible               \ /
                                                  class Child
                   Is Program me intefaces ko use krke hum multiple inheritence ko achieve krenge
*/
