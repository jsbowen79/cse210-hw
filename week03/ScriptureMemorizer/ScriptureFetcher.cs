using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ScriptureFetcher
{
    private static readonly HttpClient client = new HttpClient();

    public class VerseDetail
    {
        public int verse { get; set; }
        public string text { get; set; }
        
    }

    public class BibleApiResponse
    {
        public string reference { get; set; }
        public string text { get; set; }
        public string translation_name { get; set; }
        public VerseDetail[] verses { get; set; }
        

    }
    

    public static async Task<Dictionary<int, List<string>>> GetScriptureTextAsync(string _reference)
    {
        try

        {
            Console.WriteLine($"URL: https://bible-api.com/{Uri.EscapeDataString(_reference)}?translation=kjv");
            string url = $"https://bible-api.com/{Uri.EscapeDataString(_reference)}";
            string response = await client.GetStringAsync(url);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var dictionary = new Dictionary<int, List<string>>();

            var scripture = JsonSerializer.Deserialize<BibleApiResponse>(response, options);
            if (scripture?.verses != null)
            {
                foreach (var v in scripture.verses)
                {
                    List<string> words = new List<string>(v.text.Split("", StringSplitOptions.RemoveEmptyEntries));
                    Console.WriteLine(words);
                    Console.WriteLine(v.verse); 
                    dictionary[v.verse] = words; 
                }
            } 

            return dictionary;
        }
        catch (Exception)
        {
            return new Dictionary<int, List<string>>();
        }
    }
}