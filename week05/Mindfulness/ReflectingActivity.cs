public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    public ReflectingActivity(string name) 
    {
        _prompts = new List<string>
        { 
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", 
            "Think of a time when you did something truly selfless.", "Think of a moment when you surprised yourself with how strong you were.",
            "Think of a difficult experience that has shaped you into a stronger person today.",
            "Think of an experience that taught you lessons that could help you with something in your life today."
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?", "Have you ever done anything like this before?",
            "How did you get started?", "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        _name = name; 
        _description ="This activity will help you reflect on times in your life"
        + " when you have shown strength and resilience.\nThis will help you recognize the power you"
        + " have and how you can use it in other aspects of your life";
    }
    public void Run()
    {
        DisplayPrompt();
        Console.WriteLine();
        Delay.DelayWithWheel(10);

        DateTime endTime = StopTime.GetStopTime(_duration - 10);

        while (DateTime.Now < endTime)
        {
            int secondsLeft = (int)(endTime - DateTime.Now).TotalSeconds;
            if (secondsLeft <= 0) break;

            DisplayQuestions();
            Console.WriteLine("\n");
            Delay.DelayWithWheel(Math.Min(secondsLeft, 10));
        }
        Counter counter = Counter.GetCounter();
        int reflectionCount = counter.GetReflectionCount();
        int reflectionTime = counter.GetReflectionTime();
        counter.SetReflectionCount(reflectionCount + 1);
        counter.SetReflectionTime(reflectionTime + _duration);
    }

    public string GetRandomPrompt()
    {
        RandomIndex indexObject = new RandomIndex();
        int index = RandomIndex.ChooseUnusedRandom(indexObject, _prompts.Count() - 1);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        RandomIndex indexObject = new RandomIndex();
        int index = RandomIndex.ChooseUnusedRandom(indexObject, _questions.Count() - 1);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.Write("\x1b[2J\x1b[H");
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine();
        Delay.DelayWithWheel(10);
    }

    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
        Console.WriteLine("\n");
    }

}