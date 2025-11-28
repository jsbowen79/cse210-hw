public class ListingActivity : Activity
{
    protected int _count;
    protected List<string> _prompts;

    public ListingActivity(string name)
    {
        _name = name;
        _count = 0;
        _duration = 0;
        _description = "This activity will help you reflect on the good things in your life by having you list\n"
        + " as many things as you can in a certain area.";
        _prompts = new List<string>
        {
            "Who are people that you appreciate?", "What are personal strengths of yours?",
        "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?", "What are the best things that have happened to you?",
        "Who are the people who have supported you most and how?"
        };
    }

    public void Run()
    {
        Console.Write("\x1b[2J\x1b[H");
        string prompt = GetRandomPrompt(); 
        Console.WriteLine(prompt);
        Delay.DelayWithCountdown(5);
        Console.WriteLine($"Please list as many answers to the prompt as possible in {_duration} seconds.");
        Console.Write("Begin in ");
        Delay.DelayWithCountdown(5);

        GetListFromUser(prompt); 
        Counter counter = Counter.GetCounter();
        int listingCount = counter.GetListingCount();
        int listingTime = counter.GetListingTime();
        counter.SetListingCount(listingCount + 1);
        counter.SetListingTime(listingTime + _duration);
        Console.WriteLine($"You made {_count} entries.");
        Delay.DelayWithWheel(5);
    }

    public string GetRandomPrompt()
    {
  

        RandomIndex listingIdexObject = new RandomIndex();
        string randomPrompt = _prompts[RandomIndex.ChooseUnusedRandom(listingIdexObject, _prompts.Count - 1)];
        return randomPrompt; 
    }
    
    public void GetListFromUser(string prompt)
    {
        List<string> responseStrings = new List<string>();
        string entry;
        DateTime endTime = StopTime.GetStopTime(_duration);

        while (DateTime.Now < endTime)
        {
            int secondsLeft = (int)(endTime - DateTime.Now).TotalSeconds;
            if (secondsLeft <= 0) break;
            entry = Console.ReadLine();
            _count ++; 
            responseStrings.Add(entry);
            Console.Write("\x1b[2J\x1b[H");
            Console.WriteLine(prompt);
        }


           
    }
}