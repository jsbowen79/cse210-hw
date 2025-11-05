using System;
using System.Collections.Generic;

public class Entry
/*This class contains all of the tools necessary to create an entry to be saved in the 
Journal*/
{
    DateTime _currentDate = DateTime.Today;
    string _todaysEntry = "";
    EntryItems _journalEntry = new EntryItems();

    public EntryItems journalEntries()
    /*This function extracts a prompt from the Prompt class and presents the user with the 
    prompt.  It then takes the user's entry and puts it together with the date and the 
    prompt that was offered in a standardized format to be saved in the Journal.
    Returns: _journalEntry(DateTime, string, string) */
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