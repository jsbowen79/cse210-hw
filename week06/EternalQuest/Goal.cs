using System.ComponentModel;

public class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    protected bool _complete;

    public string ShortName
    {
        get => _shortName;
        set => _shortName = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    public int Points
    {
        get => _points;
        set => _points = value;
    }

    public bool Complete
    {
        get => _complete;
        set => _complete = value;
    }

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _complete = false;
    }

    public Goal()
    {
        _shortName = "";
        _description = "";
        _points = 0;
    }

    public virtual int RecordEvent()
    {
        return 0;
    }
    public bool IsComplete()
    {
        {
            if (_complete) return true;
            else return false;
        }
    }

    public virtual string GetDetailsString()
    {
        string detailString = $"{(_complete ? "[X]" : "[ ]"),-9} {_shortName,-20} {_description, -40}{"", -10}";
        return detailString;
    }
}