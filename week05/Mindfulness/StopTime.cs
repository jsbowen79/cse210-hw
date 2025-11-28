public class StopTime
{
    public static DateTime GetStopTime(int length)
    {
        DateTime startTime = DateTime.Now;
        DateTime stopTime = startTime.AddSeconds(length);
        return stopTime; 
    }
}