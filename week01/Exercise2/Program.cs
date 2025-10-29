using System;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("What was your grade in percent?  ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        string letter;
        string sign = null; 

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade < 90 && grade >= 80)
        {
            letter = "B";
        }
        else if (grade < 80 && grade >= 70)
        {
            letter = "C";
        }
        else if (grade < 70 && grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        if (grade % 10 >= 7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }
        else if (grade % 10 <= 3 && letter != "A" && letter != "F")
        {
            sign ="-"; 
        }

        Console.Write($"Your letter grade is {letter}{sign}.  ");

        if (grade >= 70)
        {
            Console.WriteLine("Great Job!  You passed the test. ");
        }
        else
        {
            Console.WriteLine("I'm sorry!  You did not pass the test, but you can do it! \n" +
            "We can provide tutors to help!"); 
        }
    }
}