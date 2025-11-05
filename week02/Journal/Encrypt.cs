using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

public static class Encrypt
{
    private static readonly string oneDrivePath = Environment.GetEnvironmentVariable("OneDrive")
        ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive");

    private static readonly string filePath = Path.Combine(oneDrivePath, "securedata.json");

    public static void SaveProtectedJson(List<EntryItems> list)
    {
        string jsonString = JsonSerializer.Serialize(list);
        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        File.WriteAllBytes(filePath, encrypted);
        Console.WriteLine($"File saved securely to {filePath}");
    }

    public static List<EntryItems> LoadProtectedJson()
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
        return journal ?? new List<EntryItems>();
    }
}
