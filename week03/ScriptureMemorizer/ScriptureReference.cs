
public class ScriptureReference
{
    private string _book = ""; 
   
    private int _beginningVerse;

    private int? _endingVerse;

    private int _chapter;

    public  int GetBeginningVerse()
    {
        return _beginningVerse;
    }

    public int? GetEndingVerse()
    {
        return _endingVerse;
    }

    public string GetBook()
    {
        return _book;
    }
    
    public int GetChapter()
    {
        return _chapter; 
    }


    public ScriptureReference(string book, int chapter, int beginningVerse, int? endingVerse)
    /*Creates a Scripture Reference Object for use in the program.  The object contains the book, chapter, 
    beginning verse, and ending verse.  The endingVerse parameter is optional and can remain null without 
    breaking the program.  This allows for entries of multiple verses without multiple constructors. */
    {
        _book = book;
        _chapter = chapter; 
        _beginningVerse = beginningVerse;
        _endingVerse = endingVerse; 
    }

    public static ScriptureReference EnterScriptureReference()
    /*This method prompts the user to enter their scripture reference and contains error handling to 
    ensure that data is entered in the proper format. */
    {
        while (true)
        {
            Console.WriteLine("Please use the format 'Book: [Beginning Verse] - [Ending Verse]'.");
            Console.WriteLine("The '- Ending Verse' may be omitted if not required.");
            Console.WriteLine();
            Console.Write("Please enter the scripture reference you would like to memorize: "); 
            string input = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.  Please enter a Scripture.");
                continue;
            }
            int colonIndex = input.IndexOf(":");
            int dashIndex = input.IndexOf("-");


            if (colonIndex != -1)
            {
                string bookAndChapter = input.Substring(0, colonIndex).Trim();
                int spaceIndex = bookAndChapter.LastIndexOf(" ");
                string book = bookAndChapter.Substring(0, spaceIndex).Trim();

                string versePart = input.Substring(colonIndex + 1).Trim();

                int beginningVerse;
                int? endingVerse = null;

                try
                {
                    if (dashIndex != -1)
                    {
                        string[] parts = versePart.Split('-');
                        beginningVerse = int.Parse(parts[0].Trim());
                        endingVerse = int.Parse(parts[1].Trim());
                    }
                    else
                    {
                        beginningVerse = int.Parse(versePart);
                    }
                    int chapter = int.Parse(bookAndChapter.Substring(spaceIndex).Trim());
                    
                    Console.WriteLine("Scripture added Successfully");
                    return new ScriptureReference (book, chapter, beginningVerse, endingVerse);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Invalid input1 Please input your scripture in the proper format. 'Book: [Beginning Verse] - [Ending Verse]'!  Exception: {e}");
                }
            }
        }
    }

    public override string ToString()
    /*This method formats and simplifies the printing of the ScriptureReference Objects. */
    {
        return _endingVerse == null
            ? $"{_book} {_chapter}:{_beginningVerse}"
            : $"{_book} {_chapter}:{_beginningVerse}-{_endingVerse}";
    }
}