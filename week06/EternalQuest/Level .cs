using System.Collections;


public class Level
{
    private string _oldLevel;
    private string _newLevel;
    public string OldLevel
    {
        get => _oldLevel;
        set => _oldLevel = value;
    }
    public string NewLevel
    {
        get => _newLevel;
        set => _newLevel = value;
    }


    public static Level UpdateLevel(int score, Level level)
    {
       
        if (score <= 500)
        {
            level._newLevel = "Tree Mouse – White Belt\n";
        }
        else if (score > 500 && score <= 1500)
        {
            level._newLevel = "Wiggly Squirrel – White Belt\n";
        }
        else if (score > 1500 && score <= 2500)
        {
            level._newLevel = "Confused Turtle – White Belt\n";
        }
        else if (score > 2500 && score <= 3500)
        {
            level._newLevel = "Mildly Annoyed Duck – Yellow Belt\n";
        }
        else if (score > 3500 && score <= 4500)
        {
            level._newLevel = "Over-caffeinated Chipmunk – Yellow Belt\n";
        }
        else if (score > 4500 && score <= 5500)
        {
            level._newLevel = "Determined Garden Rabbit – Orange Belt\n";
        }
        else if (score > 5500 && score <= 6500)
        {
            level._newLevel = "Spinning House-cat – Orange Belt\n";
        }
        else if (score > 6500 && score <= 7500)
        {
            level._newLevel = "Rampaging Goose – Green Belt\n";
        }
        else if (score > 7500 && score <= 8500)
        {
            level._newLevel = "Snapping Iguana – Green Belt\n";
        }
        else if (score > 8500 && score <= 9500)
        {
            level._newLevel = "Thunder - Punching Penguin – Blue Belt\n";
        }
        else if (score > 9500 && score <= 10500)
        {
            level._newLevel = "Sky - Diving Coyote – Blue Belt\n";
        }
        else if (score > 10500 && score <= 11500)
        {
            level._newLevel = "Whirlwind Baboon – Blue Belt\n";
        }
        else if (score > 11500 && score <= 12500)
        {
            level._newLevel = "Laser - Eyed Wolverine – Purple Belt\n";
        }
        else if (score > 12500 && score <= 13500)
        {
            level._newLevel = "Mountain - Shattering Ram – Purple Belt\n";
        }
        else if (score > 13500 && score <= 14500)
        {
            level._newLevel = "Fire - Breathing Buffalo – Purple Belt\n";
        }
        else if (score > 14500 && score <= 15500)
        {
            level._newLevel = "Tempest - Charging Boar – Low-Brown Belt\n";
        }
        else if (score > 15500 && score <= 16500)
        {
            level._newLevel = "Volcano - Fist Dragon-hawk – Brown-Red Belt\n";
        }
        else if (score > 16500 && score <= 17500)
        {
            level._newLevel = "Earth - Cracking Thunder-bear – High Brown Belt\n";
        }
        else if (score > 17500 && score <= 18500)
        {
            level._newLevel = "Shadow - Storm Tiger – Black Belt\n";
        }
        else if (score > 20000)
        {
            level._newLevel = "Celestial Doom Phoenix – Grand Master Black Belt\n";
        }
        if (level._newLevel != level._oldLevel)
        {
            Console.WriteLine($"****Congratulations****\n\nYou have been promoted to a {level._newLevel}");
            level._oldLevel = level._newLevel;
        }
        return level; 

    }
}

    









