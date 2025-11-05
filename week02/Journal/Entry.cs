using System;
using System.Collections.Generic; 

public class Entry
{
    DateTime _currentDate = DateTime.Today;
    string _todaysEntry = "";
    EntryItems _journalEntry = new EntryItems(); 

    public EntryItems journalEntries()
    {
       
        Prompt todaysPrompt = new Prompt();
        string livePrompt = todaysPrompt.GetPrompt();
        Console.WriteLine($"Welcome to your Journal.\nToday's date is {_currentDate.ToShortDateString()}");
        Console.WriteLine("Your topic for today is: \n");
        
        Console.WriteLine(livePrompt + Environment.NewLine);
        while (true)
        {
            Console.Write("Please begin your Journal Entry: ");
            _todaysEntry = Console.ReadLine();

            if (_todaysEntry != "")
            {
                _journalEntry = EntryItems.CreateEntryListItem(_currentDate, livePrompt, _todaysEntry);
                return _journalEntry;
            }
            else
            {
                Console.WriteLine("You must make an entry. ");
            }
        }    
    }
}