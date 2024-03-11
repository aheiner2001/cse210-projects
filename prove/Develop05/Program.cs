using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        displayMenu();



       
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

        }
}