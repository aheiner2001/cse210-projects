using System;

class Program
{
    static void Main(string[] args)
    {
        string option = "";
        while (option != "4")
        {
            printMenu();
            option = Console.ReadLine();
            if (option == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.runactivity(); // Execute the main activity
                 // Finish the activity
            }
            else if (option == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.runactivity(); // Execute the main activity
               ; // Finish the activity
            }
            else if (option == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.runactivity(); // Execute the main activity
               ; // Finish the activity
            }
           else if (option =="4"){
            break;
           }
            else
            {
                Console.WriteLine("Did not Understand. Please type a valid response.");
                Thread.Sleep(2000);
            }
        }
    }

    static void printMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Start breathing activity");
        Console.WriteLine(" 2. Start reflecting activity");
        Console.WriteLine(" 3. Start listing activiy");
        Console.WriteLine(" 4. Quit");
        Console.Write(" Select a choice from the menu: ");
    }
}
