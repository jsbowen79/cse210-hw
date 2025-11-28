public class BreathingActivity : Activity
{
    public BreathingActivity(string name) 
    {
        _name = name;
        _description = "This activity will help you relax by walking your through breathing in and out slowly.\n"
        + "The Square Breathing activity is completed in multiples of 16 seconds.  Clear your mind and focus on your breathing.";
        _duration = 0; 
    }

    public BreathingActivity()
    {
        _name = "";
        _description = "";
        _duration = 0; 
    }
    
    public void Run()
    {
        bool fraction;
        int duration = _duration;
        if (duration % 16 != 0) { fraction = true; } else { fraction = false; }
        if (fraction) { duration = (duration / 16 * 16) + 16; } else { duration = duration / 16 * 16; }
       _duration = duration;

        DateTime endTime = StopTime.GetStopTime(duration - 1);

        while (DateTime.Now < endTime)
        {
            Console.Write("\x1b[2J\x1b[H");
            Console.Write("Breathe in through your nose...");
            Delay.DelayWithCountdown(4);
            Console.Write("\x1b[2J\x1b[H");
            Console.Write("Hold...");
            Delay.DelayWithCountdown(4);
            Console.Write("\x1b[2J\x1b[H");
            Console.Write("Breathe out through your mouth...");
            Delay.DelayWithCountdown(4);
            Console.Write("\x1b[2J\x1b[H");
            Console.Write("Hold...");
            Delay.DelayWithCountdown(4);
            Console.Write("\x1b[2J\x1b[H");

        }
        Counter counter = Counter.GetCounter();
        int breathingCount = counter.GetBreathingCount();
        int breathingTime = counter.GetBreathingTime();
        counter.SetBreathingCount(breathingCount + 1);
        counter.SetBreathingTime(breathingTime + _duration);
    }
}