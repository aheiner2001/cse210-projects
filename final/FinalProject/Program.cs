using System;
using System.Diagnostics;

class Program
{   static bool running = true;
    static void Main(string[] args)
    {

        Console.Clear();
        Console.WriteLine("Welcome to the pickleball trainer\n\nIn this program you will be able to track your progress on your pickleball journey\n\nAs you complete training sessions, level up your shots to improve your game. You will be able to log your games to keep track of scores.  ");
        Console.Write("Press enter to continue: ");
        Console.ReadLine();
        

        while (running){
            displayMenu();
            

        }


    }











static void displayMenu(){
    Console.WriteLine("Menu: ");
    Console.WriteLine("1. Create Player");
    Console.WriteLine("2. Guided Pracitce");
    Console.WriteLine("3. Log Matches");
    Console.WriteLine("4. View Matches");
    Console.WriteLine("5. View Stats");
    Console.WriteLine("6. Tip Store");
    Console.WriteLine("7. Load");
    Console.WriteLine("8. Save and Quit");
    Console.Write("\nWhat would you like to do? ");
    string response =  Console.ReadLine();

    switch(response){
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
            break;
        
        case "7":
            break;
        
        case "8":
            break;
        
    }
}
}




