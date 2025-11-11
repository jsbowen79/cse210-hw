using System;
using System.Xml.Schema;


class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(6, 7); 

        Console.WriteLine("Hello World! This is the Fractions Project.");
        Console.WriteLine($"Fraction(): {f1.GetDecimalValue()}");
        Console.WriteLine($"Fraction(): {f1.GetFractionString()}");
        Console.WriteLine($"Fraction(): {f2.GetDecimalValue()}");
        Console.WriteLine($"Fraction(): {f2.GetFractionString()}");
        Console.WriteLine($"Fraction(): {f3.GetDecimalValue()}");
        Console.WriteLine($"Fraction(): {f3.GetFractionString()}");
    }
}