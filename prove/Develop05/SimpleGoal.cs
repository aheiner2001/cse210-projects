using System;
using System.Collections.Generic;

class SimpleGoal : Goal
{
    public SimpleGoal() : base()
    {
    }

    public SimpleGoal(string name, string description, int points, bool status) : base(name, description, points)
    {
        if (status == true)
        {
            MarkComplete();
        }
    }

    public override void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            outputFile.WriteLine($"SimpleGoal||{Name}||{Description}||{Points}||{Complete}");
        }
    }

    public override int recordEvent()
    {
        if (!Complete)
        {
            Console.WriteLine($"Congratulations!! You have earned {Points} points!");
            MarkComplete();
            return Points;
        }
        else
        {
            Console.WriteLine("This Goal has already been Completed, create another goal to earn more points!");
            return 0;
        }
    }
}
