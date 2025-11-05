using System;

class Program
{
    static void Main(string[] args)
    {
        List<EntryItems> journal = new List<EntryItems>();
        journal =Load.LoadFile(); 
        Entry input = new Entry(); 
        Console.WriteLine("Hello World! This is the Journal Project.");
        Prompt todaysPrompt = new Prompt();

        Console.WriteLine($"{todaysPrompt.GetPrompt()}");
        journal.Add(input.journalEntries());
        foreach (EntryItems journalEntry in journal)
        {
            Console.WriteLine($"Date: {journalEntry._entryDate.ToShortDateString()} Entry: {journalEntry._entry}");
        }
        // Save.SaveFile(journal); 


    }
}