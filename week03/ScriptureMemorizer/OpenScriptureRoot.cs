public class OpenScriptureRoot
/*This class creates an OpenScriptureRoot object to store the information obtained from the Json string retrieved 
from the api by the ScriptureFetcher class.*/
{
    private Chapter _chapter;

    public Chapter Chapter
    {
        get => _chapter;
        set => _chapter = value;
    }

}
