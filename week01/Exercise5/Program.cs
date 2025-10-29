using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }    
        
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }
        
        static int PromptUserNumber()
        {
            while (true)
            {

                Console.Write("Please enter your favorite number: ");
                try

                {
                    int number = int.Parse(Console.ReadLine());
                    return number;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid integer. ");
                }
            }
        }
        
        static int SquareNumber(int number)
        {
            int squareNumber = number * number;
            return squareNumber;
        }
        
        static void DisplayResult (string name, int number)
        {
            Console.WriteLine($"{name}, the square of your number is {number}");
        }

        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber(); 
        int squareNumber = SquareNumber(number);
        DisplayResult(name, squareNumber);

    }
}