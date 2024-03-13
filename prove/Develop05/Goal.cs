using System;

abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _complete;

    public Goal(){
        Console.Write("What is the name of your goal?");
        _name  = Console.ReadLine();
         Console.Write("What is a short description of your goal?");
        _description =  Console.ReadLine();
       
        
    }

    // public string GetName()
    // {
        
    // }

    // public string GetDescription()
    // {
       
    // }

    public void SetPoints()
    {
        // Implement logic to set points
    }

    public void SaveGoals()
    {
        // Implement logic to save goals
    }

    public void LoadGoals()
    {
        // Implement logic to load goals
    }
}
