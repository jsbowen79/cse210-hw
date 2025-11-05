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

        Console.WriteLine($"Welcome to your Journal.\nToday's date is {_currentDate}");
        Console.WriteLine("Your topic for today is: ");
        Console.WriteLine(todaysPrompt.GetPrompt());
        Console.Write("Please begin your Journal Entry: ");
        _todaysEntry = Console.ReadLine();

        _journalEntry = EntryItems.CreateEntryListItem(_currentDate, _todaysEntry);
        return _journalEntry; 
    }
}