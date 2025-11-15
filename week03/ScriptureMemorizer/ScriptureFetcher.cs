using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class ScriptureFetcher
/* This class is responsible for fetching a scripture from the openscripture API and saving it into a Dictionary in the 
form required for the rest of the program to use it.  */
{
    private static readonly HttpClient _client = new HttpClient();

    public static async Task<Dictionary<int, List<string>>> GetScriptureTextAsync(ScriptureReference reference)
    {
        string book = reference.GetBook();
        int chapter = reference.GetChapter();
        int beginningVerse = reference.GetBeginningVerse();
        int? endingVerse = reference.GetEndingVerse();
        List<string> verses = new List<string>();
        Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();

        try

        {
            string url = $"https://openscriptureapi.org/api/scriptures/v1/lds/en/book/{book}/{chapter}";
            if (beginningVerse > 0)
            {
                url += $"?verseStart={beginningVerse}";

                if (endingVerse != null)
                {
                    url += $"&verseEnd={endingVerse}";
                }


                string response = await _client.GetStringAsync(url);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var root = JsonSerializer.Deserialize<OpenScriptureRoot>(response, options);


                if (root?.Chapter?.Verses == null)
                {
                    return dict;
                }

                int lastVerse = endingVerse ?? beginningVerse;

                for (int verseNumber = beginningVerse; verseNumber <= lastVerse; verseNumber++)
                {
                    string text = root.Chapter.Verses[verseNumber - 1].Text;

                    verses = text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                    dict[verseNumber] = verses;
                }

                return dict;
            }
            return dict;
        }
        catch
        {
            return dict;
        }
    }


}
              

