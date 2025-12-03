public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {

    }
    
    public SimpleGoal(){}

    public override int RecordEvent()
    {
        Console.WriteLine("You have chosen to record completion of a Simple Goal.");
        Console.WriteLine($"The Goal you are updating is:\n\n ");
        Console.WriteLine($"{GetDetailsString()}\n\n");
        Console.WriteLine("Would you like to complete this goal? (Y/N)");
        string validatedResponse = Verification.yesNoVerification();

        if (validatedResponse == "Y")
        {
            Console.WriteLine($"Congratulations!  You have earned {_points} points.");
            _complete = true;
            return _points;
        }
        else return 0; 


    }

   
  

}