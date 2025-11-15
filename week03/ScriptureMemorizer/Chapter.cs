public class Chapter
/*This class creates a Chapter object with getters and setters to be used by the ScriptureFetcher class. */
{
    private List<AutoVerse> _verses { get; set; }

    public List<AutoVerse> Verses
    {
        get => _verses;
        set => _verses = value;
    }
}