using System;

class Program
/*To exceed the requirements, I limited the number of points that can be assigned to each goal so that a levelling 
system could be used.  I provided error handling for all user inputs.  I created a leveling system based on score.
The Level class will display a congratulatory message each time a user levels up.  I stored all needed variables 
in a JSON string and restored them from the JSON string.  This allows me to continue using them in their original 
form instead of saving them as strings.  I also listed the specific goal that was chosen for update and asked the 
user if that was the goal they intended to update.  I created a verification class to handle data validation.    
*/
{

    static void Main(string[] args)

    {
        Console.WriteLine("Welcome to EternalQuest where we help you achieve your goals!");
        GoalManager.Start();


    }
}