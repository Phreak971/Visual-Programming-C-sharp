using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Console_OOP_Virtual
{
    class Program
    {
        public class Animal
        {
            protected string Name { set; get; }
            public void NotVirtualFunction() //A simple Function
            {
                Console.WriteLine("I am an Animal");
            }
            public virtual void AVirtualFunction()
            {
                Console.WriteLine("I am an Animal");
            }
        }
        public class Cat : Animal
        {
            new public void NotVirtualFunction()    //I want to change the implementation of the function in parent class
            {
                Console.WriteLine("I am a Cat");
            }
            public override void AVirtualFunction()
            {
                Console.WriteLine("I am a Cat");
            }
        }
        public class Dog : Animal
        {
            new public void NotVirtualFunction()    //override keyword cannot be used with normal functions so we reimplement it with new keyword
            {
                Console.WriteLine("I am a Dog");
            }
            public override void AVirtualFunction()
            {
                Console.WriteLine("I am a Dog");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("For Non Virtual Function");
            Animal animal = new Animal();
            animal.NotVirtualFunction(); //i am an animal
            animal = new Cat(); //dynamic binding?
            animal.NotVirtualFunction(); //i am an animal? but we changed the function using new keyword in Cat class
            animal = new Dog();
            animal.NotVirtualFunction();    //still i am an animal?
            Console.WriteLine("For Virtual Function");
            Animal animal1 = new Animal();
            animal1.AVirtualFunction(); //i am an animal
            animal1 = new Cat();
            animal1.AVirtualFunction(); //i am an cat
            animal1 = new Dog();
            animal1.AVirtualFunction();  //i am an dog

            /*It is optional to reimplement a virtual function it is not necessary to
             Reimplement it the child class can also use it like a normal function
             Hum virtual isliye likhte hain function k sath taake agr hum koi new class 
             banayen aur usme humain parent k function ko change krke use krna ho toh humain parent me 
             changes nah krni paren hum parent walay ko override kr len 
             Agr Dog class me AVirtual wala function hata den toh b uske pass wo function mojud hoga
             aur uski implementation animal class wwali hogi jese normal cases me hota ha*/

        }
    }
}
