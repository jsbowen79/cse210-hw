public class AutoVerse
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