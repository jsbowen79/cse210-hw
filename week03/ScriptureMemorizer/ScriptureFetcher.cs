using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ScriptureFetcher
{
    private static readonly HttpClient client = new HttpClient();

    public class BibleApiResponse
    {
        public string reference { get; set; }
        public string text { get; set; }
        public string translation_name { get; set; }

    }
    public static async Task<string> GetScriptureTextAsync(string reference)
    {
        try

        {
            string url = $"https://bible-api.com/{Uri.EscapeDataString(reference)}";
            string response = await client.GetStringAsync(url);
            var scripture = JsonSerializer.Deserialize<BibleApiResponse>(response); 

            return scripture?.text ?? "No text found for that reference.";
        }
        catch (Exception ex)
        {
            return $"Error fetching scripture: {ex.Message}"; 
        }
    }
}