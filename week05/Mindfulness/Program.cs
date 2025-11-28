using System;

class Program
/*I added several improvements to the program.  First, the program has error handling to ensure that invalid user entries don't crash the program. 
Second, the program tracks the questions asked and will not repeat them until they have all been used in a session.  Third I created a counter that 
keeps track of both the number of times and the amount of time that a user spends on each activity per session.  Fourth, I utilized both a spinner and 
a countdown under different situations.  Fifth, I left the user with a message letting them know exactly what they accomplished during the session.  
*/
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");


        Menu.DisplayMenu(); 

    }
        
}