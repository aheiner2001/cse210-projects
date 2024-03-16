using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

class ChecklistGoal : Goal
{
    private int _checklistlength;
    private int _bonus;
    private int _timesCompleted;

    public ChecklistGoal() : base()
    {
        Console.Write("How many times does this goal need to be completed to be accomplished? ");
        _checklistlength = int.Parse(Console.ReadLine());

        Console.WriteLine("What is the bonus for accomplishing it that many times? ");
        _bonus = int.Parse(Console.ReadLine());
    }

    public ChecklistGoal(string name, string description, int points, int bonus, int length, int timesdone) : base(name, description, points)
    {
        if (length == timesdone)
        {
            MarkComplete();
        }
        _bonus = bonus;
        _timesCompleted = timesdone;
        _checklistlength = length;
    }

    public override string ToString()
    {
        string box = drawcheckBox();
        return $"{box} {Name} ({Description}) -- Currently completed: {_timesCompleted}/{_checklistlength}\n";
    }

    public override void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            outputFile.WriteLine($"ChecklistGoal||{Name}||{Description}||{Points}||{_bonus}||{_checklistlength}||{_timesCompleted}");
        }
    }

    public override int recordEvent()
    {
        if (!Complete)
        {
            Console.WriteLine($"Congratulations!! You have earned {Points} points!");
            if (_timesCompleted == _checklistlength - 1)
            {
                MarkComplete();
                Console.WriteLine($"You have earned {_bonus} bonus points!");
                _timesCompleted +=1;
                return Points + _bonus;
                
            }
            else
            {
                _timesCompleted += 1;
                return Points;
            }
        }
        else
        {
            Console.WriteLine("This Goal has already been Completed, create another goal to earn more points!");
            return 0;
        }
    }
}
