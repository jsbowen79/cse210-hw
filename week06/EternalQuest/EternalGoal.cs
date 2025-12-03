public class EternalGoal : Goal
{
    private int _completedCount = 0;

    public int CompletedCount
    {
        get => _completedCount;
        set => _completedCount = value;
    }
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    public EternalGoal()
    {
        
    }
    public override int RecordEvent()
    {
        Console.Clear(); 
        Console.WriteLine("You have chosen to record completion of an Eternal Goal.");
        Console.WriteLine($"The Goal you are updating is:\n\n ");
        Console.WriteLine($"{GetDetailsString()}\n\n");
        Console.WriteLine("Would you like to complete this goal? (Y/N)");
        string validatedResponse = Verification.yesNoVerification();

        if (validatedResponse == "Y")
        {
            Console.WriteLine($"You have completed this goal {_completedCount} times!");
            Console.WriteLine($"Congratulations!  You have earned {_points} points.");
            _completedCount += 1;

            return _points;
        }
        else return 0;


    }

}