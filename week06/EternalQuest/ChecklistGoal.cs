using System.ComponentModel;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;

    private int _bonus;

    public int AmountCompleted
    {
        get => _amountCompleted;
        set => _amountCompleted = value;
    }

    public int Target
    {
        get => _target;
        set => _target = value;
    }

    public int Bonus
    {
        get => _bonus;
        set => _bonus = value;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;

    }

    public ChecklistGoal() { }
    
    public override int RecordEvent()
    {
        int earnedPoints = 0;
        Console.Clear();
        Console.WriteLine("You have chosen to record completion of a Checklist Goal.");
        Console.WriteLine($"The Goal you are updating is:\n\n ");
        Console.WriteLine($"{GetDetailsString()}\n\n");
        Console.WriteLine("Would you like to complete this goal? (Y/N)");
        string validatedResponse = Verification.yesNoVerification();

        if (validatedResponse == "Y")
        {
            _amountCompleted += 1; 
            Console.WriteLine($"You have completed {_amountCompleted} of {_target} instances of this Goal!");
            Console.WriteLine($"Congratulations!  You have earned {_points} points.");
            earnedPoints += _points;

            if (_amountCompleted == _target)
            {
                _complete = true;
                earnedPoints += _bonus;
                Console.WriteLine($"Congratulations! You have earned an additional {_bonus} points.");
                Console.WriteLine("Would you like to Complete this goal again?  Press 'Y' for yes or 'N' for no.");
                validatedResponse = Verification.yesNoVerification();
                if (validatedResponse == "Y") { _amountCompleted = 0; _complete = false; }
                return earnedPoints;
            }
            else return earnedPoints; 
        }
        else return 0;
    }

    public override string GetDetailsString()
    {
        string detailString = $"{(_complete ? "[X]" : "[ ]"),-9} {_shortName,-20}{_description, -40}  Completed {_amountCompleted}/{_target}";
        return detailString;
    }

}