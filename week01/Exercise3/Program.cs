using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Console.Write("What is the magic Number?  ");
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        Boolean wrong = true;
        int numberOfGuesses = 0; 

        while (wrong)
        {
            Console.Write("What is your guess?  ");
            int userGuess = int.Parse(Console.ReadLine());

            if (userGuess > magicNumber)
            {
                Console.WriteLine("Your guess is too high.  Guess lower.");
                numberOfGuesses += 1; 
            }
            else if (userGuess < magicNumber)
            {
                Console.WriteLine("Your guess is to low.  Guess higher.");
                numberOfGuesses += 1; 
            }
            else
            {
                numberOfGuesses += 1;
                Console.WriteLine($"You guessed it.  The Magic Number is {magicNumber}!");
                Console.WriteLine($"It took you {numberOfGuesses} guesses. ");

                while (true)
                {
                    Console.WriteLine("Do you want to play again? Press 'y' for yes and 'n' for no.");
                    string response = Console.ReadLine().ToUpper();

                    if (response == "Y" || response == "YES")
                    {
                        numberOfGuesses = 0;
                        magicNumber = randomGenerator.Next(1, 100);
                        break;
                    }
                    else if (response == "N" || response == "NO")
                    {
                        Console.WriteLine("Thank you for playing.  Have a nice Day!");
                        wrong = false;
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Please enter a 'Y' for yes or an 'n' for no. ");
                    }
                }

            }
        }

    }
}