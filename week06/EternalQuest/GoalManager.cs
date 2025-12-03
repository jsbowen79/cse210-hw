using System.Collections;
using System.Runtime;
using System.Text.Json;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.ComponentModel;
using System.Reflection.Metadata;

public class GoalManager
{
    private List<Goal> _goals;

    private int _score;

    private Level _level = new Level();


    public GoalManager()
    {
        _score = 0;
        _goals = new List<Goal>();
    }
    public Level Levels
    {
        get => _level;
        set => _level = value;
    }

    public List<Goal> Goals
    {
        get => _goals;
        set => _goals = value;
    }

    public int Score
    {
        get => _score;
        set => _score = value;
    }
    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers =
                {
                    (info) =>
                    {
                        if (info.Type == typeof(Goal))
                        {
                            info.PolymorphismOptions = new JsonPolymorphismOptions()
                            {
                                TypeDiscriminatorPropertyName = "$type",
                                IgnoreUnrecognizedTypeDiscriminators = true,
                            };

                            info.PolymorphismOptions.DerivedTypes.Add(
                            new JsonDerivedType(typeof(ChecklistGoal), "checklist"));
                            info.PolymorphismOptions.DerivedTypes.Add(
                            new JsonDerivedType(typeof(SimpleGoal), "simple"));
                            info.PolymorphismOptions.DerivedTypes.Add(
                            new JsonDerivedType(typeof(EternalGoal), "eternal"));
                        }
                    }
                }
        }
    };

    public static void Start()
    {
        int input;
        GoalManager currentFile = new GoalManager();
        while (true)
        {

            Console.WriteLine("Please choose an option from the Menu below!\n\n");
            Console.WriteLine("1.  Create a new Goal");
            Console.WriteLine("2.  List My Goals");
            Console.WriteLine("3.  Save My Goals");
            Console.WriteLine("4.  Load My Goals");
            Console.WriteLine("5.  Record Goal Completion");
            Console.WriteLine("6.  I am done for today");

            input = Verification.ListIntVerification(1, 6);



            switch (input)
            {
                case 1:

                    currentFile.CreateGoal();
                    continue;

                case 2:
                    currentFile.PrintGoals();
                    continue;

                case 3:
                    SaveGoals(currentFile);
                    continue;

                case 4:
                    currentFile = currentFile.LoadGoals(currentFile);
                    continue;

                case 5:
                    currentFile.RecordEvent();
                    continue;

                case 6:
                    Console.WriteLine("Would you like to save your file?");
                    string response = Verification.yesNoVerification();
                    if (response == "Y") SaveGoals(currentFile);
                    Console.WriteLine("Thank you for using Eternal Quest!");
                    Console.WriteLine($"Your score is {currentFile._score} points.");
                    Console.WriteLine("Have a wonderful day and we hope to see you again soon!");
                    return; 
                default:
                    Console.WriteLine($"'{input}' is not a valid response.  Please enter the number (1-6) that corresponds with your choice.");
                    continue;
            }

        }

    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your current score is {_score} points!");
    }

    public Dictionary<int, Goal> PrintGoals()
    {
        Dictionary<int, Goal> stringDict = new Dictionary<int, Goal>();
        DisplayPlayerInfo(); 
        Console.WriteLine("Your current goals are: ");


        string headerString = $" {" ", -3}{"Completed",-9} {"Name",-20} {"Description", -40}{"Progress", -10}";
        Console.WriteLine(headerString);

        int i = 1;
        
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i,-3}{goal.GetDetailsString()}");
            stringDict[i] = goal; 
            i+=1;

        }
        return stringDict;
    }

    public void CreateGoal()
    {
        int input;
        Console.WriteLine("The available Goal types are: ");
        Console.WriteLine("1.  Simple Goal --completed once");
        Console.WriteLine("2.  Eternal Goal --goal never ends");
        Console.WriteLine("3.  Checklist Goal --Goal requires multiple instances for completion\n\n");
        Console.WriteLine("Please choose the number 1-3 that corresponds with the goal you would like to create.");

        input = Verification.ListIntVerification(1, 3);

        string name;
        string description;
        int points;

        Console.Write("Please provide the name for your goal: ");
        name = Console.ReadLine();
        Console.Write("Please enter the description for your goal: ");
        description = Console.ReadLine();
        Console.Write("Please enter the number of points your goal is worth: (1-200)");
        points = Verification.ListIntVerification(1, 200);
        Console.Clear();
        

        switch (input)
        {
            case 1:

                SimpleGoal sGoal = new SimpleGoal(name, description, points);
                _goals.Add(sGoal);
                break;
            case 2:
                EternalGoal eGoal = new EternalGoal(name, description, points);
                _goals.Add(eGoal);
                break;

            case 3:
                Console.WriteLine("Please enter the number of times you would like to complete the goal: ");
                int target = Verification.IntVerification();
                Console.WriteLine($"Please enter the number of points that you would like for completing your goal {target} times (1-600): ");
                int bonus = Verification.ListIntVerification(0, 600);
                ChecklistGoal ckGoal = new ChecklistGoal(name, description, points, target, bonus);
                _goals.Add(ckGoal);
                break;
        }
        Console.WriteLine("Goal Created!");
        PrintGoals(); 


    }

    private void RecordEvent()
    {
        Program currentLevel = new Program(); 
        
        Console.Clear(); 
        Console.WriteLine("You have chosen to record an event.");
        Dictionary<int, Goal> currentDict = new Dictionary<int, Goal>(PrintGoals());
        Console.WriteLine("Please enter the number corresponding with the event you would like to update.");

        int input; 
        Goal activeGoal = new Goal();
        while (true)
        {
            input = Verification.IntVerification();

            if (input <= currentDict.Count())
            {
                activeGoal = currentDict[input];
                break;
            }
            else
            {
                Console.WriteLine($"{input} is not a valid selection.  Please choose the number corresponding with the event you would like to update.");
                PrintGoals(); 
            }
        }
        int score = activeGoal.RecordEvent();
        _score += score;
        Console.WriteLine($"You now have {_score} points. \n\n");
        Level.UpdateLevel(_score, _level); 
    }

    public static void SaveGoals(GoalManager currentFile)
    {
        string fileName = "";
        string cwd = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
        string fileExtension = ".json";
        bool unsaved = true;

        while (unsaved)
        {
           
            Console.Write("\n\nPlease enter the name of the file you would like to save with no extension (e.g., goals): ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("You must enter a valid file name. Please try again.");
                continue;
            }

            fileName = Path.Combine(cwd, input) + fileExtension;

            try
            {
                Console.WriteLine(currentFile._goals.Count());

                string jsonString = JsonSerializer.Serialize(currentFile, _options);
                   
                    

                File.WriteAllText(fileName, jsonString);
                Console.WriteLine($"File saved successfully to {fileName}");
                unsaved = false;
                continue;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Your file did not save. Please try again. Exception type: {ex.GetType().Name}");
                continue;
            }
        }
    }


    public GoalManager LoadGoals(GoalManager currentFile)
    { 
        string toDeserialize = "";
        string fileName = "";
        string cwd = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
        string fileExtension = ".json";
        while (true)
        {
            Console.Write("Please enter the name of the file you would like to load without the extension (e.g., goals): ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("You must enter a valid file name. Please try again.");
                continue;
            }

            fileName = Path.Combine(cwd, input) + fileExtension;

            try
            {
                toDeserialize = File.ReadAllText(fileName);




                GoalManager newFile = JsonSerializer.Deserialize<GoalManager>(toDeserialize, _options);

                if (newFile != null)
                {
                    Console.WriteLine($"File '{fileName}' loaded successfully!");
                    return newFile;
                }
                else
                {
                    Console.WriteLine("File loaded but contained no entries.");
                    return new GoalManager();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Your file did not load. Exception type: {ex.GetType().Name}");
                Console.WriteLine("Please try again.");
            }
        }
    }

}