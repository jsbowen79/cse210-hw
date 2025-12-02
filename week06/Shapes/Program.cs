using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        Square square = new Square("yellow", 10);
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());  

        Rectangle rectangle = new Rectangle("blue", 10, 11);
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());  


        Circle circle = new Circle("red", 1);
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());

        List<Shape> shapeList = new List<Shape> { square, rectangle, circle };
        

        foreach (Shape shape in shapeList)
        {
            Console.WriteLine($"Color :  {shape.GetColor()}, Area : {shape.GetArea()} ");
        }
    }
}