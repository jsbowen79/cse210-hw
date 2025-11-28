public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0; 
    }

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _duration = duration;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }
    
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"{_name} allows you to: ");
        Console.WriteLine(_description);
        GetDuration.SetDuration(this); 
      
        Console.Write("\x1b[2J\x1b[H");
        Console.WriteLine($"Excellent!  Please prepare to begin {_name}!\n\n");

        Delay.DelayWithCountdown("You will begin in 5 seconds.", 5);
        Console.Write("\x1b[2J\x1b[H");
    }

    public void DisplayEndingMessage()
    {
        Console.Write("\x1b[2J\x1b[H");
        Delay.DelayWithWheel("Well Done!\n\n", 3);
        Delay.DelayWithWheel($"You have completed the {_name}"
        + $" for {_duration} seconds!\n\n", 3);
        Delay.DelayWithWheel(3);
    }

}

