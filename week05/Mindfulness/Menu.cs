using System.Globalization;
using System.Reflection;

public class Menu
{
    public static void DisplayMenu()
    {
        bool invalid = true;
        int userChoice = 0;
        // StartMessage startMessage; 

        while (true)
        {
            invalid = true;
            
            Console.WriteLine("Welcome to Mindfulness Matters where we promote a centered lifestyle!\n"
            + "Please choose from one of the following activities.");

            Console.WriteLine("1. Guided Breathing: Relax you mind and body through guided breathing.");
            Console.WriteLine("2. Assisted Reflection: Find your center by reflecting on your life and experiences.");
            Console.WriteLine("3. Positivity Listing: Help maintain positivity by listing the positive aspects of your life.");
            Console.WriteLine("4. Exit: I am finished improving my Mindfulness for now.\n\n");
            Console.WriteLine("Please press the number that corresponds to the activity you would like to complete.\n");
            string input = Console.ReadLine();
            Console.Write("\x1b[2J\x1b[H");

            while (invalid)
            {

                try
                {
                    userChoice = int.Parse(input);
                    invalid = false;
                }
                catch (Exception)
                {
                    Console.WriteLine($"{input} is an invalid entry.  You must enter a number. Please try again.");
                    break; 
                }
            }

            if (!invalid)
            {
                
                switch (userChoice)
                {
                    case 1:
                        BreathingActivity activity = new BreathingActivity("Guided Breathing");
                        activity.DisplayStartingMessage();
                        activity.Run();
                        activity.DisplayEndingMessage(); 
                        break;
                    case 2:
                        ReflectingActivity ReflectActivity = new ReflectingActivity("Assisted Reflection");
                        ReflectActivity.DisplayStartingMessage();
                        ReflectActivity.Run();
                        ReflectActivity.DisplayEndingMessage();
                        break;
                    case 3:
                        ListingActivity ListActivity = new ListingActivity("Positivity Listing");
                        ListActivity.DisplayStartingMessage();
                        ListActivity.Run();
                        ListActivity.DisplayEndingMessage();
                        break;
                    case 4:
                        Counter counter = Counter.GetCounter();
                        Console.WriteLine("Thank you for using Mindfulness Matters.\n\n");
                        Console.WriteLine("You participated in the following Mindfulness activities so far!");
                        Console.WriteLine($"Guided Breathing: {counter.GetBreathingCount()} times for {counter.GetBreathingTime()} total seconds! ");
                        Console.WriteLine($"Assisted Reflection: {counter.GetReflectionCount()} times for {counter.GetReflectionTime()} total seconds! ");
                        Console.WriteLine($"Positivity Listing: {counter.GetListingCount()} times for {counter.GetListingTime()} total seconds!\n\n ");
                        Console.WriteLine("Be Mindful and have a wonderful day!");
                        return;
                    default:
                        Console.WriteLine($"{userChoice} is an invalid selection.  Please choose a number between 1 and 4.");
                        input = Console.ReadLine();
                        invalid = true;
                        continue;

                }
            }
            
        }
    }
}