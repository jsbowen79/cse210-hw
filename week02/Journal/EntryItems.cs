using System;
using System.Dynamic;
public class EntryItems
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
        set { _promptField = value;  }
    }

    public static EntryItems CreateEntryListItem(DateTime eventDate, string prompt, string input)
    {
        EntryItems item = new EntryItems();
        item._entryDate = eventDate;
        item._entry = input;
        item._prompt = prompt; 
        return item;
    }
    
}