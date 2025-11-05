using System;

public class Menu
{
    public List<EntryItems> _journal = new List<EntryItems>();
    public static void DisplayMenu()
    {
        Menu mainMenu = new Menu(); 

        while (true)
        {
            Console.WriteLine("What would you like to do?\n\n");
            Console.WriteLine("Press 1 to Save your file");
            Console.WriteLine("Press 2 to Load a file. ");
            Console.WriteLine("Press 3 to Write in your journal.");
            Console.WriteLine("Press 4 to Review your journal. ");
            Console.WriteLine("Press 5 to Quit.\n\n ");


            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    Save.SaveFile(mainMenu._journal);
                    continue; 
                case "2":
                    mainMenu._journal = Load.LoadFile();
                    continue;
                case "3":
                    Entry journalEntry = new Entry();
                    mainMenu._journal.Add(journalEntry.journalEntries());
                    continue; 
                case "4":
                    foreach (EntryItems item in mainMenu._journal)
                    {
                        Console.WriteLine($"Date: {item._entryDate.ToShortDateString()} Entry: {item._entry}");
                    }
                    Console.WriteLine("\n\n");
                    continue;
                case "5":
                    return;
                default:
                    Console.WriteLine("Please make a valid selection.");
                    continue;  

            }
        }


    }
}