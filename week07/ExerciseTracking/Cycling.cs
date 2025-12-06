using System.Reflection.Metadata.Ecma335;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, double time, double speed) : base(date, time)
    {
        _speed = speed;
        _activityName = "Cycling"; 
    }


    public override double FindSpeed()
    {
        return _speed;
    }
}