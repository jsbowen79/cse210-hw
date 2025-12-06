public abstract class Activity
{
    protected DateTime _date;
    protected double _lengthTime;
    protected string _activityName; 
    public Activity(DateTime date, double time)
    {
        _date = DateTime.Now.Date;
        _lengthTime = time;
        _activityName = ""; 
    }

    public virtual double FindDistance()
    {
        return FindSpeed() * _lengthTime / 60;
    }

    public virtual double FindSpeed()
    {
        return FindDistance() / (_lengthTime / 60);
    }

    public virtual double FindPace()
    {
        return 60 / FindSpeed();
    }
    
    public string GetSummary()
    {
        string dateString = _date.ToString("dd MMM yyyy");
        double distance = FindDistance();
        double speed = FindSpeed();
        double pace = 60 / speed; 
        return $"{dateString} {_activityName} ({_lengthTime} min): Distance {distance} miles, Speed: {speed} mph, Pace: {pace} min per mile "; 
    }
}