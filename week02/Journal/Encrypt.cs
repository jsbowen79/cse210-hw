using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

public static class Encrypt
/*This Class will contain all the tools necessary to create encrypted 
files for people who are worried about the security of their journal.  
The encryption will utilize the Windows Data Protection API to ensure that 
the only person who can activate open the encrypted files is the person who 
was signed on when the file was encrypted.*/
{
    private static readonly string oneDrivePath = Environment.GetEnvironmentVariable("OneDrive")
        ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive");

    private static readonly string filePath = Path.Combine(oneDrivePath, "securedata.json");

    public static void SaveProtectedJson(List<EntryItems> list)
    /*This method will use the JsonSerializer to save the list of journal
    entries that is passed to it to a Json string.  The JsonSerializer will retain the data 
    types of DateTime and string contained in the list.  The method will 
    then encrypt the Jsonstring and save it in a secure file.*/
    {
        string jsonString = JsonSerializer.Serialize(list);
        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        File.WriteAllBytes(filePath, encrypted);
        Console.WriteLine($"File saved securely to {filePath}");
    }

    public static List<EntryItems> LoadProtectedJson()
    /*This method will load a previously saved encrypted file and decrypt
    back to a json string containing the list of journal entries that was 
    originally saved and encrypted.  Data types will be retained as DateTime
    and String objects by the JsonSerializer.
    Returns: List<EntryItems> */
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No secure file found.");
            return new List<EntryItems>();
        }

        byte[] encrypted = File.ReadAllBytes(filePath);
        byte[] decrypted = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.CurrentUser);
        string jsonString = Encoding.UTF8.GetString(decrypted);
        List<EntryItems>? journal = JsonSerializer.Deserialize<List<EntryItems>>(jsonString);
        Console.WriteLine("Encrypted File Successfully Loaded"); 
        return journal ?? new List<EntryItems>();
    }
}
