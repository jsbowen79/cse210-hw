using System;
using System.Collections.Generic; 

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<int> numbers = new List<int>();
        int userInput = 0;
        double average = 0;
        int largest = 0;
        int sum = 0;
        int smallestPositive = 0; 

        Console.WriteLine("Enter a list of integers.  Type '0' when finished.");

        while (true)
        {

            Console.Write("Enter a number: ");

            while (true)
            {
                try

                {
                    userInput = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please limit your entries to integers. ");
                    Console.WriteLine("Enter a list of integers.  Type '0' when finished.\nEnter a number: ");
                    continue;
                }
            }
            if (userInput == 0)
            {
                break;
            }
            else
            {
                numbers.Add(userInput);
            }

        }

        foreach (int number in numbers)
        {
            sum += number;

            if (largest == 0 ||  number > largest)
            {
                largest = number;
            }
            if (number > 0)
            {
                if (smallestPositive == 0)
                {
                    smallestPositive = number;
                }
                else if (number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }

        }
        numbers.Sort();
        average = (double)sum / numbers.Count;
        Console.WriteLine($"The sum is:  {sum} ");
        Console.WriteLine($"The average is:  {average}");
        Console.WriteLine($"The largest number is: {largest}");
        if (smallestPositive == 0)
        {
            Console.WriteLine("There were no positive numbers entered.");
        }
        else
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        Console.WriteLine($"The sorted list is: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}