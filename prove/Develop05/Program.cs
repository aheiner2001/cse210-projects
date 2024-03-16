using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

class Program
{   static List<Goal> goals = new List<Goal>();
    static bool running = true;
    static int total_points = 0;
    static void Main(string[] args)
    {
        Console.Clear();
;        {
            
        }
        
        while (running){
            displayMenu();
        }
      



     
  SimpleGoal goal = new SimpleGoal();
    }


    
   static void displayMenu(){
        
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
                        if (option == "1"){
                            SimpleGoal simple = new SimpleGoal();
                            goals.Add(simple);
                        }
                        else if (option == "2"){
                            EternalGoal eternal = new EternalGoal();
                            goals.Add(eternal);
                          
                        }
                        else if (option == "3"){
                            ChecklistGoal checklist = new ChecklistGoal();
                            goals.Add(checklist);
                            
        
                        }
                        else{
                            Console.WriteLine("Did not understand");
                        }
                    
                        
                
                    break;
                case "2":
                Console.Clear();
                    Console.WriteLine("\nGoals:");
                    foreach(Goal thing in goals){
                        Console.WriteLine($"{thing}");
                    }
                   
                    break;
                case "3":
                    Console.WriteLine("What would you like to name the file: ");
                    string filename = Console.ReadLine();
                    foreach (Goal goal in goals){
                        
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
                            // simple goal: 5 parts
                            // eteernal goal: 4 parts
                            // checklist e goal: 7part
                        string[] parts = line.Split("||");
                        if (parts.Length > 2) {
                        string type = parts[0];
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);

                        switch (type) {
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
                        else{
                            total_points = int.Parse(parts[0]);

                        }
                    


        }
                    
                    break;
                case "5":
                    Console.WriteLine("The Goals are:");
                    int i = 1;
                    foreach (Goal goal in goals){
                        Console.WriteLine($"{i}. {goal.Name}");
                        i++;
                    }
                    Console.Write("Which goal did you accmplish? ");
                    string input  = Console.ReadLine();
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
    static string  goalOptions(){
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of Goal would you like to create? ");
        return Console.ReadLine();
      
    }
 
    

//      -simople:dfsdf Points: 10 Complete: False

//  -eteneral:adajf Points: 23 Complete: False

//  -Checklist Points: 10 Complete: False




//Your program must do the following:

// Provide for simple goals that can be marked complete and the user gains some value.
// For example, if you run a marathon you get 1000 points.
// Provide for eternal goals that are never complete, but each time the user records them, they gain some value.
// For example, every time you read your scriptures you get 100 points.
// Provide for a checklist goal that must be accomplished a certain number of times to be complete. Each time the user records this goal they gain some value, but when they achieve the desired amount, they get an extra bonus.
// For example, if you set a goal to attend the temple 10 times, you might get 50 points each time you go, and then a bonus of 500 points on the 10th time.
// Display the user's score.
// Allow the user to create new goals of any type.
// Allow the user to record an event (meaning they have accomplished a goal and should receive points).
// Show a list of the goals. This list should show indicate whether the goal has been completed or not (for example [ ] compared to [X]), and for checklist goals it should show how many times the goal has been completed (for example Completed 2/5 times).
// Allow the user's goals and their current score to be saved and loaded.
}