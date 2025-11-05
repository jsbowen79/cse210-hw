using System;

public class Menu
/*This class will contain the tools necessary to provide the user facing menu.  */
{
    public List<EntryItems> _journal = new List<EntryItems>();
    public static void DisplayMenu()
    /*This function will present the user with a menu that provides the user with 
    options.  The function will then call the code necessary to carry out the user's 
    request.  The function will continue running until the user decides to quit.  */
    {
        Menu mainMenu = new Menu();

        while (true)
        {
            Console.WriteLine("What would you like to do?\n\n");
            Console.WriteLine("Press 1 to Save your file");
            Console.WriteLine("Press 2 to Load a file. ");
            Console.WriteLine("Press 3 to Write in your journal.");
            Console.WriteLine("Press 4 to Review your journal. ");
            Console.WriteLine("Press 5 to Quit.");
            Console.WriteLine("Press 6 to Encrypt and save.");
            Console.WriteLine("Press 7 to Load Encrypted file.\n\n ");


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
                    continue;
                case "5":
                    return;
                case "6":
                    Encrypt.SaveProtectedJson(mainMenu._journal);
                    continue;
                case "7":
                    mainMenu._journal = Encrypt.LoadProtectedJson();
                    Console.WriteLine("\n\n");
                    continue;
                default:
                    Console.WriteLine("Please make a valid selection.");
                    continue;

            }
        }


    }
}