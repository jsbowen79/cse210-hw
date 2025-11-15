public class AutoVerse
/*This class creates an Autoverse object with public getters and setters to be utilized by the ScriptureFetcher class.
*/
{
    private string _text;
    private List<AutoVerse> _verses;

    public string Text
    {
        get => _text;
        set => _text = value;
    }

    public List<AutoVerse> Verses
    {
        get => _verses;
        set => _verses = value;
    }
}