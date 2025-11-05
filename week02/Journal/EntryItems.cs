using System;
using System.Dynamic;
public class EntryItems
/*This class will contain all the tools necessary to create a list that contains the 
variable types DateTime, string, string.  This list will be utilized to hold the information
contained within journal entries.  */
{
    private DateTime _entryDateField;
    public DateTime _entryDate
    {
        get { return _entryDateField; }
        set { _entryDateField = value; }
    }
    private string _entryField = "";
    public string _entry
    {
        get { return _entryField; }
        set { _entryField = value; }
    }

    private string _promptField = "";
    public string _prompt
    {
        get { return _promptField; }
        set { _promptField = value; }
    }

    public static EntryItems CreateEntryListItem(DateTime eventDate, string prompt, string input)
    /* This function will be called by the Entry class to create the actual list item to 
    be saved in the journal list.  The list item will contain the date of the entry in DateTime 
    format, the prompt that was presented to the user for the entry, and the user's response
    or journal entry. 
    Arguments: DateTime eventDate - the date the entry was made. 
               string prompt - the prompt presented to user. 
               string input - the user's response or journal entry. 
    Returns: EntryItem object of type DateTime, string, string. */
    {
        EntryItems item = new EntryItems();
        item._entryDate = eventDate;
        item._entry = input;
        item._prompt = prompt;
        return item;
    }

}