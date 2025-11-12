using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;

public class RemoveWords
{
        private static Random _random = new Random();
        private static Dictionary<int, List<int>> _removedIndexes = new Dictionary<int, List<int>>(); 

    // private static List<int> _wordsToRemove = new List<int>();
    public static List<int> IdentifyWords(List<string> scripture, int verseKey)
    /*This method identifies the words to be converted to underscores.  It does so by choosing 
    random integers between 0 and the length of the list of words contained in the scripture.  The 
    method checks those indexes against a list of indexes that have previously been removed from the 
    associated verse.  If the index has already been removed, another index is generated until either 
    two indexes which have not been removed are generated or all index numbers present within the scripture
    have been removed.  At that point, it returns the list of up to 2 indexes.*/
    {
        List<int> newIndexes = new List<int>(); 
        int listLength = scripture.Count();
        List<int> alreadyRemoved = new List<int>(); 


        for (int i =0; i < 2; )
        {

            int randomIndex = _random.Next(listLength);
            if (scripture.All(w => w == new string('_', w.Length)) || Enumerable.Range(0,listLength).All(i=>_removedIndexes[verseKey].Contains(i)) )
            {
                return newIndexes; 
            }
            else
            {
                if (_removedIndexes[verseKey].Contains(randomIndex))
            {
                continue;
            }
            else
            {
                newIndexes.Add(randomIndex);
                _removedIndexes[verseKey].Add(randomIndex);
                if (scripture.All(w => w == new string('_', w.Length)))
                {
                    i = 2;
                }
                else
                {
                    i++;
                }     
            }
                
            }
        }    
        return newIndexes; 

    }

    public static Dictionary<int, List<string>> ReplaceWords(Dictionary<int, List<string>> dictionaryItem)
    /*This method identifies the word matching the indexes of the list returned by the IdentifyWords method. 
    It then converts every character in those words to an underscore "_" and returns the new string to the list 
    of words in the scripture in the same place from which it came.  */
    {

        foreach (KeyValuePair<int, List<string>> entry in dictionaryItem)
        {
            int verseKey = entry.Key; 
            if (!_removedIndexes.ContainsKey (verseKey))
            {
                _removedIndexes[verseKey] = new List<int>(); 
            }
             
            List<string> scripture = new List<string>();
            scripture = entry.Value;
            List<int> wordsToRemove;

        wordsToRemove= IdentifyWords(scripture, verseKey);

            foreach (int index in wordsToRemove)
            {
                string word = scripture[index];
                List<string> wordLetters = new List<string>();
                wordLetters = word.Select(c => "_").ToList();
                word = string.Join("", wordLetters);
                scripture[index] = word;
                dictionaryItem[entry.Key] = scripture;
            }
            
        }
        return dictionaryItem;  
             
    }
    
}