using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");

        Assignment test = new Assignment("Joseph Bowen", "How to take a test");

        Console.WriteLine(test.GetSummary());

        MathAssignment mathHomework = new MathAssignment("Joseph", "Algebra 2", "6.3", "1-100");
        Console.WriteLine(mathHomework.GetHomeworkList());

        WritingAssignment paper = new WritingAssignment("Joseph Bowen", "English 101", "10 Tips for Getting an A on that Test");
        Console.WriteLine(paper.GetWritingInformation()); 
    }
}