

public class Verse
{

    private static List<string> _verseText = new List<string>();

    private static Dictionary<int, List<string>> _scriptureVerses = new Dictionary<int, List<string>>();

    public static Dictionary<int, List<string>> CreateScripture(ScriptureReference currentReference)
    /*This method prompts the user for the text of the scripture one verse at a time.  It saves the entry
    in a Dictionary with the verse number as a key.  The words in the verse are separated into a list of 
    strings so that each word can be managed individually.  This method  ensures that the verse number and
    the associated text are always kept together and that individual words can be changed and kept in their 
    propper place. */
    {
      

        int begin = currentReference.GetBeginningVerse();
        int? end = currentReference.GetEndingVerse();

        if (end != null)
        {
            for (int i = begin; i <= end; i++)
            {
                List<string> verseStrings = new List<string>(); 
                Console.WriteLine($"Please enter the text of verse {i}.");
                string text = Console.ReadLine();
                string[] splitStringArray = text.Split(" ");
                foreach (string word in splitStringArray)
                {
                    verseStrings.Add(word);
                }
                _scriptureVerses.Add(i, verseStrings);
            }
        }
        else
        {
            Console.WriteLine($"Please enter the text of verse {begin}.");
            string text = Console.ReadLine();
            string[] splitStringArray = text.Split(" ");
            foreach (string word in splitStringArray)
            {
                _verseText.Add(word);
            }
            _scriptureVerses.Add(begin, _verseText);
        }


        return _scriptureVerses;
    }
}