using System; 
using System.Collections.Generic; 

public class Prompt
{

    List<string> prompts = new List<string>(); 
    public string _prompt =""; 
    
    public string GetPrompt()
    {
        prompts.Add("What emotion did I feel most strongly today, and why?"); 
        prompts.Add("What is one moment from today I'd like to remember a year from now?");
        prompts.Add("What is something I learned about myself?");
        prompts.Add("When did I feel most confident today?");
        prompts.Add("What does my ideal day look like from start to finish?");
        prompts.Add("List three small things that made me smile today.");
        prompts.Add("Who made my life better recently, and how can I show appreciation?");
        prompts.Add("What is something I take for granted that I'm grateful for today?");
        prompts.Add("What is one good thing that happened unexpectedly this week?");
        prompts.Add("How have I seen kindness — either given or received?");
        prompts.Add("What is one goal I'm working toward right now, and what's my next small step?");
        prompts.Add("What habit do I want to build or break this month?");
        prompts.Add("What's one thing I did recently that pushed me out of my comfort zone?");
        prompts.Add("How do I define success today — and has that definition changed?");
        prompts.Add("What advice would I give myself five years ago?");
        prompts.Add("What inspires me to keep going on hard days?");
        prompts.Add("What does “balance” mean to me right now?");
        prompts.Add("If I could talk to my future self 10 years from now, what would I ask?");
        prompts.Add("What am I proud of that I don't celebrate enough?");
        prompts.Add("What's something I've overcome that I once thought I couldn't?");
        prompts.Add("What do I need to let go of right now?");
        prompts.Add("When and where do I feel most at peace?");
        prompts.Add("What worries can I release tonight before I sleep?");
        prompts.Add("What's one way I can be gentler with myself today?");
        prompts.Add("How did I take care of my mind and body today?");
        prompts.Add("If I could spend a day anywhere in the world, where would it be and why?");
        prompts.Add("What would my life look like if fear didn't hold me back?");
        prompts.Add("What story from my life would make a good short film or book?");
        prompts.Add("What song, quote, or piece of art describes how I feel right now?");
        prompts.Add("If today were the first page of a new chapter, what would the title be? ");

        Random random = new Random();
        int selection = random.Next(prompts.Count);
        _prompt = prompts[selection]; 

        return _prompt; 
    }

}