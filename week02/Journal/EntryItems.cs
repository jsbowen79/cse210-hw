using System;
using System.Dynamic;
public class EntryItems
{
    public DateTime _entryDate{get; private set; }
    public string _entry {get; private set; }

    public static EntryItems CreateEntryListItem(DateTime eventDate, string input)
    {
        EntryItems item = new EntryItems();
        item._entryDate = eventDate;
        item._entry = input;
        return item;
    }
    
}