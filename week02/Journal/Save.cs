using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;

public class Save
{
    public string _fileName = "";

    public static String SaveFile(List<EntryItems> journal)
    {
        Save file = new Save();
        string cwd = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
       
        while (true)
        {
            Console.Write("Please enter the name of the file you would like to save (e.g., journal.json): ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("You must enter a valid file name. Please try again.");
                continue;
            }

            file._fileName = Path.Combine(cwd, input);

            try
            {
                string jsonString = JsonSerializer.Serialize(
                    journal,
                    new JsonSerializerOptions { WriteIndented = true }
                );
               
                File.WriteAllText(file._fileName, jsonString);
                Console.WriteLine($"File saved successfully to {file._fileName}");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Your file did not save. Please try again. Exception type: {ex.GetType().Name}");
            }
        }
    }
}
