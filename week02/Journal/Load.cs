using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Load
/*This class contains all of the tools necessary to load a previously saved file. */
{
    
    public static List<EntryItems> LoadFile()
    /*This function will ask the user for the file name and attempt to load the identified
    file.  The function has error handling in case the file doesn't exist or the file
    load experiences a problem.  In that case, the user will be able to try again. The 
    function then opens the file and saves the Jsonstring inside.  It then DeSerializes the 
    Jsonstring turning it back into the original List<EntryItems> that was saved.  The
    function maintains the original data types of DateTime, string, string. */
    {
        string toDeserialize = ""; 
        string fileName = ""; 
        string cwd = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
        string fileExtension = ".json"; 
        while (true)
        {
            Console.Write("Please enter the name of the file you would like to load (e.g., journal.json): ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("You must enter a valid file name. Please try again.");
                continue;
            }

            fileName = Path.Combine(cwd, input) + fileExtension;

            try
            {
                toDeserialize = File.ReadAllText(fileName);
                List<EntryItems>? journal = JsonSerializer.Deserialize<List<EntryItems>>(toDeserialize);

                if (journal != null)
                {
                    Console.WriteLine($"File '{fileName}' loaded successfully!");
                    return journal;
                }
                else
                {
                    Console.WriteLine("File loaded but contained no entries.");
                    return new List<EntryItems>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Your file did not load. Exception type: {ex.GetType().Name}");
                Console.WriteLine("Please try again.");
            }
        }
    }
}
