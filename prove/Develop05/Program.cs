using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static bool running = true;
    static int total_points = 0;

    static void Main(string[] args)
    {
        Console.Clear();
        while (running)
        {
            displayMenu();
        }
    }

    static void displayMenu()
    {
        Console.WriteLine($"\nYou have {total_points} points\n");
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Create New Goals");
        Console.WriteLine(" 2. List Goals");
        Console.WriteLine(" 3. Save Goals");
        Console.WriteLine(" 4. Load Goals");
        Console.WriteLine(" 5. Record Event");
        Console.WriteLine(" 6. Quit");
        Console.Write("Select a choice from the menu:");
        string response = Console.ReadLine();
        switch (response)
        {
            case "1":
                string option = goalOptions();
                if (option == "1")
                {
                    SimpleGoal simple = new SimpleGoal();
                    goals.Add(simple);
                }
                else if (option == "2")
                {
                    EternalGoal eternal = new EternalGoal();
                    goals.Add(eternal);
                }
                else if (option == "3")
                {
                    ChecklistGoal checklist = new ChecklistGoal();
                    goals.Add(checklist);
                }
                else
                {
                    Console.WriteLine("Did not understand");
                }
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("\nGoals:");
                foreach (Goal thing in goals)
                {
                    Console.WriteLine($"{thing}");
                }
                break;
            case "3":
                Console.WriteLine("What would you like to name the file: ");
                string filename = Console.ReadLine();
                foreach (Goal goal in goals)
                {
                    goal.SaveGoals(filename);
                }
                using (StreamWriter outputFile = new StreamWriter(filename, true))
                {
                    outputFile.WriteLine($"{total_points}");
                }
                break;
            case "4":
                Console.Write("From which file would you like to load your goals?");
                filename = Console.ReadLine();
                string[] lines = System.IO.File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] parts = line.Split("||");
                    if (parts.Length > 2)
                    {
                        string type = parts[0];
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);

                        switch (type)
                        {
                            case "SimpleGoal":
                                bool booly = bool.Parse(parts[4]);
                                SimpleGoal simple = new SimpleGoal(name, description, points, booly);
                                goals.Add(simple);
                                break;
                            case "EternalGoal":
                                EternalGoal eternal = new EternalGoal(name, description, points);
                                goals.Add(eternal);
                                break;
                            case "ChecklistGoal":
                                int Bonus = int.Parse(parts[4]);
                                int length = int.Parse(parts[5]);
                                int timescompleted = int.Parse(parts[6]);
                                ChecklistGoal checklist = new ChecklistGoal(name, description, points, Bonus, length, timescompleted);
                                goals.Add(checklist);
                                break;
                            default:
                                Console.WriteLine("Error: check spelling of txt");
                                break;
                        }
                    }
                    else
                    {
                        total_points += int.Parse(parts[0]);
                    }
                }
                break;
            case "5":
                Console.WriteLine("The Goals are:");
                int i = 1;
                foreach (Goal goal in goals)
                {
                    Console.WriteLine($"{i}. {goal.Name}");
                    i++;
                }
                Console.Write("Which goal did you accomplish? ");
                string input = Console.ReadLine();
                int selection = int.Parse(input) - 1;
                total_points += goals[selection].recordEvent();
                break;
            case "6":
                running = false;
                break;
            default:
                Console.WriteLine("Please select a valid option");
                break;
        }
    }

    static string goalOptions()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of Goal would you like to create? ");
        return Console.ReadLine();
    }
}
