using System.Globalization;

public class Counter
{
    private int _breathingCount;
    private int _listingCount;
    private int _reflectionCount;

    private int _breathingTime;
    private int _listingTime;
    private int _reflectionTime;
    private Dictionary<string, List<int>> _counts;

    private static Counter _globalCounter = new Counter(true);
    private Counter(bool isGlobal)
    {
        _breathingCount = 0;
        _listingCount = 0;
        _reflectionCount = 0;
        _breathingTime = 0;
        _listingTime = 0;
        _reflectionTime = 0;
        List<int> breathing = new List<int> { _breathingCount, _breathingTime };
        List<int> reflection = new List<int> { _reflectionCount, _reflectionTime };
        List<int> listing = new List<int> { _listingCount, _listingTime };
        _counts = new Dictionary<string, List<int>> { { "Breathing", breathing }, { "Listing", listing }, { "Reflection", reflection } };

    }

    public Counter() : this(false){ }

    public static Counter GetCounter()
    {
        return _globalCounter;
    }
    
    public int GetBreathingCount()
    {
        return _breathingCount;
    }

    public void SetBreathingCount(int count)
    {
        _breathingCount = count;
    }
    public int GetListingCount()
    {
        return _listingCount;
    }

    public void SetListingCount(int count)
    {
        _listingCount = count;
    }

    public int GetReflectionCount()
    {
        return _reflectionCount;
    }

    public void SetReflectionCount(int count)
    {
        _reflectionCount = count;
    }

    public int GetBreathingTime()
    {
        return _breathingTime;
    }

    public void SetBreathingTime(int count)
    {
        _breathingTime = count;
    }

    public int GetListingTime()
    {
        return _listingTime;
    }

    public void SetListingTime(int count)
    {
        _listingTime = count;
    }

    public int GetReflectionTime()
    {
        return _reflectionTime;
    }

    public void SetReflectionTime(int count)
    {
        _reflectionTime = count;
    }



}