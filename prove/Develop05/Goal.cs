using System;
using System.IO;

abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _complete;

    public Goal()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of point associated with this goal? ");
        string points = Console.ReadLine();
        _points = int.Parse(points);
    }

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int Points { get { return _points; } }
    public bool Complete { get { return _complete; } }

    public override string ToString()
    {
        string _checkbox = drawcheckBox();
        return $"{_checkbox} {_name}({_description}) \n";
    }
// I found another method to get and set above, but I kept both in as a remind that both work.
    public string getName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int getPoints()
    {
        return _points;
    }

    public void MarkComplete()
    {
        _complete = true;
    }

    public void addGoal()
    {
        Console.WriteLine("add goal");
    }

    public virtual void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            outputFile.WriteLine($"EternalGoal||{Name}||{Description}||{Points}");
        }
    }

    public virtual int recordEvent()
    {
        Console.WriteLine($"Congratuations!! You have earned {_points} points!");
        return _points;
    }

    public string drawcheckBox()
    {
        return _complete ? "[X]" : "[ ]";
    }


}
