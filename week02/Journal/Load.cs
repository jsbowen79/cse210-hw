using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Load
{
    public string _fileName = "";
    public string _toDeserialize = "";

    public static List<EntryItems> LoadFile()
    {
        Load file = new Load();
        string cwd = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
       
        while (true)
        {
            Console.Write("Please enter the name of the file you would like to load (e.g., journal.json): ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("You must enter a valid file name. Please try again.");
                continue;
            }

            file._fileName = Path.Combine(cwd, input);

            try
            {
                file._toDeserialize = File.ReadAllText(file._fileName);
                List<EntryItems>? journal = JsonSerializer.Deserialize<List<EntryItems>>(file._toDeserialize);

                if (journal != null)
                {
                    Console.WriteLine($"File '{file._fileName}' loaded successfully!");
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
