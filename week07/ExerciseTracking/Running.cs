public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, double time, double distance) : base(date, time)
    {
        _distance = distance;
        _activityName = "Running"; 
    }
    public override double FindDistance()
    {

        return _distance;
    }

}