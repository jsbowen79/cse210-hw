public class GetDuration
{
    public static void SetDuration(Activity activity)
    {
        bool invalid = true;
        string input;
        int validInt = 0;
        while (invalid)
        {
            Console.WriteLine($"\nHow many seconds would you like to use {activity.GetName()}");
            input = Console.ReadLine();

            try
            {
                validInt = int.Parse(input);
                activity.SetDuration(validInt);
                invalid = false;
            }
            catch (Exception)
            {
                Console.WriteLine($"{input} is an invalid entry.  Please enter an integer.");
                continue;
            }
        }
    }
}