using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

public class Delay
{
    public static void DelayWithCountdown(string message, int delay)
    {
        Console.CursorVisible = false; 
        Console.WriteLine(message);

        for (int i = delay; i > 0; i--)
        {
            string s = i.ToString();

            Console.Write(s);
            Thread.Sleep(1000);

            Console.Write(new string('\b', s.Length));
            Console.Write(new string(' ', s.Length));
            Console.Write(new string('\b', s.Length));

        }
        Console.CursorVisible = true; 
    }

    public static void DelayWithCountdown(int delay)
    {
        Console.CursorVisible = false;

        for (int i = delay; i > 0; i--)
        {
            string s = i.ToString();

            Console.Write(s);
            Thread.Sleep(1000);

            Console.Write(new string('\b', s.Length));
            Console.Write(new string(' ', s.Length));
            Console.Write(new string('\b', s.Length));
        }
        Console.CursorVisible = true; 
    }


    public static void DelayWithWheel(string message, int delay)
    {
        Console.CursorVisible = false; 

        List<string> symbolList = new List<string>();
        symbolList.Add("|");
        symbolList.Add("/");
        symbolList.Add("-");
        symbolList.Add("\\");

        Console.WriteLine(message);

        DateTime endTime = StopTime.GetStopTime(delay);

        while (DateTime.Now < endTime)
        {
            foreach (string item in symbolList)
            {
                Console.Write(item);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
        Console.CursorVisible = true; 
    }

    public static void DelayWithWheel(int delay)
    {
        Console.CursorVisible = false; 
        List<string> symbolList = new List<string>();
        symbolList.Add("|");
        symbolList.Add("/");
        symbolList.Add("-");
        symbolList.Add("\\");

        DateTime delayEndTime = StopTime.GetStopTime(delay);

        while (DateTime.Now < delayEndTime)
        {
            foreach (string item in symbolList)
            {
                Console.Write(item);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
        Console.CursorVisible = true; 
    }
} 