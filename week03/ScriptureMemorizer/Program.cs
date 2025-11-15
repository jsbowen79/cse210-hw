using System;
using System.Collections.Generic;
using System.Threading.Tasks; 

class Program
/*This program asks the user for a scripture reference and the text of the scripture.  The 
program allows for scriptures with unlimited numbers of consecutive verses in the same chapter.
The program removes two words at a time from each verse to help the user memorize the verses in the 
given selection.  The program only removes words that have not already been removed.  The program 
ends when the user types quit or when the last word in each verse has been hidden.*/
{
    static async Task Main(string[] args)
    {
        Dictionary<int, List<string>> scriptureToMemorize;
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");


        ScriptureReference scripture = ScriptureReference.EnterScriptureReference();
        string autoLoad = scripture.ToString();
        Console.WriteLine($"Autoload: {autoLoad}"); 
        scriptureToMemorize = await ScriptureFetcher.GetScriptureTextAsync(scripture);
        if (scriptureToMemorize.Count() == 0)
        {
            Console.WriteLine("Scripture AutoLoad failed. Switch to Manual Loading");
            scriptureToMemorize = Verse.CreateScripture(scripture);
        }


        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
        Console.Write("Your Scripture is:");
        Console.WriteLine(scripture);

        foreach (KeyValuePair<int, List<string>> entry in scriptureToMemorize)
        {
            {
                Console.Write($"{entry.Key}: ");
                Console.Write(string.Join(" ", entry.Value));
            }
            Console.WriteLine();
        }
        bool again = true;
        while (true)
        {
            bool completed = scriptureToMemorize.SelectMany(kv => kv.Value).Any(w => w != new string('_', w.Length));
                if (completed) 
                {
                    again = true;
                }
                else
                {
                    Console.WriteLine("Thank you for using Scripture Memorizer");
                    again = false;
                }
            
            if (again)
            {
                Console.WriteLine("Type 'Quit' to stop or press Enter to continue.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("Thank you for using Scripture Memorizer.");
                    break;
                }
                else
                {
                    if (!Console.IsOutputRedirected)
                    {
                        Console.Clear();
                    }
                    Dictionary<int, List<string>> editedDict = RemoveWords.ReplaceWords(scriptureToMemorize);
                    
                    Console.WriteLine($"{scripture}:");
                    foreach (KeyValuePair<int, List<string>> entry in scriptureToMemorize)
                    {
                        Console.Write($"{entry.Key}: ");
                        Console.WriteLine(string.Join(" ", entry.Value));
                    }
                }
            }
            else
            {
                break;
            }
        }
    }
}
