using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_OOP_Abstract
{
    public abstract class Quadrilateral //class is abstract because it contains an abstract method/function ... but we cannot make object of abstract class directly
    {

        public abstract double FindArea();  //abstract function ... each child has own implementation of FindArea function so it is abstract
        //Abstract class can also have Non-Abstract ie Normal Functions/Data Members
        protected string ShapeName { set; get; }
        public void PrintShapeName()
        {
            Console.WriteLine("This is a " + ShapeName);
        }
    }
    public class Square : Quadrilateral
    {
        public Square()
        {
            ShapeName = "Square";
        }
        public double SideLength { get; set; }
        public override double FindArea()   //Abstract methods are implemented using override keyword
        {
            return SideLength * SideLength;
        }

    }
    public class Rectangle : Quadrilateral
    {
        public Rectangle()
        {
            ShapeName = "Rectangle";
        }
        public double Length { get; set; }
        public double Width { get; set; }
        public override double FindArea()   //Abstract methods are implemented using override keyword
        {
            return Length * Width;
        }
    }
    public class Parallelogram : Quadrilateral
    {
        public Parallelogram()
        {
            ShapeName = "Parallelogram";
        }
        public double Length { get; set; }
        public double Height { get; set; }
        public override double FindArea()   //Abstract methods are implemented using override keyword
        {
            return Length * Height;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Square
            Square square = new Square();   
            square.SideLength = 5.9;
            Console.WriteLine("Area of Square " + square.FindArea());
            SayName(square);    //SayName function accepts any child of Quadrilateral Class
            //Rectangle
            Rectangle rectangle= new Rectangle();
            rectangle.Length = 5.9;
            rectangle.Width = 7.9;
            Console.WriteLine("Area of Rectangle " + rectangle.FindArea());
            SayName(rectangle); //SayName function accepts any child of Quadrilateral Class this time we sent rectangle
            //similarly we can access Parallelogram

            Quadrilateral obj = new Square();
            obj.PrintShapeName();
            obj = new Parallelogram();  //same concept is applied in SayName function
            obj.PrintShapeName();
        }
        public static void SayName(Quadrilateral sq_rec_para_anyObject) //SayName function accepts any child of Quadrilateral Class
        {
            sq_rec_para_anyObject.PrintShapeName();
        }
    }
}
