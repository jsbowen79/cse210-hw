public class Verification
{

    public static int ListIntVerification(int low, int high)
    {
        int input;
        while (true)
        {
            try
            {
                input = int.Parse(Console.ReadLine());
                if (input >= low && input <= high)
                    return input;
                else
                {
                    Console.WriteLine($"Invalid entry.  Please select a number {low} to {high}. ");
                    continue;
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Invalid entry.  Please select a number {low} to {high}. ");
                continue;
            }
        }
    }

    public static int IntVerification()
    {
        int input;
        while (true)
        {
            try
            {
                input = int.Parse(Console.ReadLine());
                return input;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entry.  Please select a valid number. ");
                continue;
            }
        }
    }
    
    public static string yesNoVerification()
    {
        while (true)
        {    
        string input = Console.ReadLine().ToUpper();

            if (input == "Y" || input == "N") return input;
            else Console.WriteLine($"'{input}' is an invalid entry.  Please type 'Y' for yes or 'N' for no. "); 
        
        }

    }

}

