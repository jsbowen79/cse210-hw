using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        Running todaysRun = new Running(DateTime.Now, 60, 2);
        Cycling todaysRide = new Cycling(DateTime.Now, 60, 2);
        Swimming todaysSwim = new Swimming(DateTime.Now, 60, 64.51);

        Console.WriteLine(todaysRun.GetSummary());
        Console.WriteLine(todaysRide.GetSummary());
        Console.WriteLine(todaysSwim.GetSummary()); 

    }
}