public class Swimming : Activity
{
    private double _laps;

    public Swimming(DateTime date, double time, double laps) : base(date, time)
    {
        _laps = laps;
        _activityName = "Swimming";
    }

    public override double FindDistance()
    {
        return _laps * 50 / 1000 * .62;
    }


    

}
