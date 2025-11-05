using System;
/*This is a journal program.  In addition to the minimum requirements, this program
contains error handling for file handling.  If a user enters a bad file name or if a 
user doesn't enter a file name, the program will continue and prompt the user for a 
valid response.  The program also has error handling for the menu.  Additionally, the 
program contains two extra options for saving and loading an encrypted file.  Users who are
worried about others reading their journal can use the encryption options to ensure that only
the user who was logged on when the file was saved can open the file. Lastly, the program
maintains the DateTime data type in the List.  It also maintains those data types across 
saves and loads ensuring that the original data types are always in tact.   */
class Program
/*This is the main program class.  It will introduce the user to the program and call the 
menu.  It will also say goodbye to the user when they wish to stop the program. */
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        Console.WriteLine("Welcome to MyJournal by Joseph Bowen");
        Menu.DisplayMenu();
        Console.WriteLine("Thank you for using MyJournal.\nHave a nice Day!\n\n");


    }
}