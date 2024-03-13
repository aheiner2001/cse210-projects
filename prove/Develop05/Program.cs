using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

class Program
{   
    static bool running = true;
    static void Main(string[] args)
    {
        
        
        while (running){
            displayMenu();
        }
      

    SimpleGoal goal = new SimpleGoal();

     
  
    }


    
   static void displayMenu(){
        int points = 0;
            Console.WriteLine($"\nYou have {points} points\n");
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
              
                    break;
                case "2":
                   
                    break;
                case "3":
                   
                    break;
                case "4":
                    
                    break;
                case "5":
                    
                    break;
                case "6":
                    running = false;
                    break;
                
                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
       
        }
    static void goalOptions(){
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of Goal would you like to create? ");
      
    }


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