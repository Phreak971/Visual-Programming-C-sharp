using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Console_OOP_Access_Modifiers_and_Properties
{
    public class Book
    {
        //internal access is limited to the current project (default access modifier)
        internal static float TaxPercentage { set; get; } = 12; //Property of Class ... It is static beacuse tax percentage remains same for all books
        //public access is not restricted
        public string BookName { get; set; }    //Book Name is a public property with a default getter setter to access it
        public string AuthorName { set; get; } //protected property with default getter and setter
        public double OrignalPrice { get; set; }    //orignal Price is a public property with a default getter setter
        public double MarketPrice { get { return OrignalPrice + (OrignalPrice * (TaxPercentage / 100)); } }  //public property with Custom getter ... setter wasn't required otherwise we can make a custom or defaultsetter as well
        //private access is limited to the containing class
        private static int NoOfBooks { get; set; }  //private property accessible only inside this class
        //protected access is limited to the containing class or child class
        protected int noOfPages;    //accessible inside this class and child class where inherited

    }
    public class Pages : Book
    {
        public void AccessProtected()
        {

            noOfPages = 459;   //protected property AurtorName of parent is being accessed inside the child class because it is inherited ... we cannot access it from outside child class even with its object
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Book MyBook = new Book();
            MyBook.BookName = "The Alchemist";
            MyBook.AuthorName = "Paulo Coelho";
            MyBook.OrignalPrice = 799.99;
            Console.WriteLine("Book Name: " + MyBook.BookName);
            Console.WriteLine("Author Name: " + MyBook.AuthorName);
            Console.WriteLine("Orignal Price: " + MyBook.OrignalPrice);
            Console.WriteLine("Market Price: " + Math.Round(MyBook.MarketPrice, 2));   //Orignal + tax ... rounded off to 2 decimal places
            Book.TaxPercentage = 15;    // Accesing inernal member of Class with class name
            Console.WriteLine("Market Price: " + Math.Round(MyBook.MarketPrice, 2)); // Market Price after tax Increase
        }
    }
}
/*  Access is same as the above namespace
namespace another_NameSpace_To_Test_Access
{
    public class test
    {
        public void fun()
        {
            Console_OOP_Access_Modifiers_and_Properties.Book bookObj = new Console_OOP_Access_Modifiers_and_Properties.Book(); //object of Book class from  Console_OOP_Access_Modifiers_and_Properties namespace
            Console.WriteLine(bookObj.AuthorName);
            Console.WriteLine(bookObj.BookName);
            Console.WriteLine(bookObj.MarketPrice);
            Console.WriteLine(bookObj.OrignalPrice);                                                                                                                           
            Console.WriteLine(Console_OOP_Access_Modifiers_and_Properties.Book.TaxPercentage);
        }
    }
}
*/
