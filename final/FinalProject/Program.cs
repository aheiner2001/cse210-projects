using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;

class Program
{   static bool running = true;
    static List<Player> players = new List<Player>();
    static List<Tip> tips = new List<Tip>()
    {
        new Tip(1,"Tip 1", "https://www.youtube.com/watch?v=fsgJa0OgeRE"),
        new Tip(2,"Tip 2", "https://www.youtube.com/watch?v=Jgr4Yo9JrO4"),
        new Tip(3,"Tip 3", "https://www.youtube.com/watch?v=-raCQ4em4Lc"),
        new Tip(4,"Tip 4", "https://www.youtube.com/watch?v=ZkYLOfyAUr8"),
        new Tip(5,"Tip 5", "https://www.youtube.com/watch?v=5bnLUkNb7PA")
    };


    static void Main(string[] args)
    {
        
        foreach(Tip tip in tips){
            Console.WriteLine($"{tip.getName}");
        }

        Console.Clear();
        Console.WriteLine("Welcome to the pickleball trainer\n\nIn this program you will be able to track your progress on your pickleball journey\n\nAs you complete training sessions, level up your shots to improve your game. You will be able to log your games to keep track of scores.  ");
        Console.Write("Press enter to continue: ");
        Console.ReadLine();
        
        Console.Clear();
        while (running){
            Console.WriteLine("\n");
            displayMenu();
            

        }


    }




static void openLink(string link){
 string url = link;

        // Open the URL in the default web browser
        try
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
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
    Console.WriteLine("9. Show list of players");
    Console.Write("\nWhat would you like to do? ");
    string response =  Console.ReadLine();

    switch(response){
        case "1":
            Console.Write("How many players would you like to add? ");
            string respose  = Console.ReadLine();
            int playersToAdd = int.Parse(respose);
            int i = 0 ;
            while (i < playersToAdd){
            Player player = new Player();
            players.Add(player);
            Console.WriteLine();
            i++;
            }
    
            break;
        
        case "2":

            Console.WriteLine("1. Forehand");
            Console.WriteLine("2. Backhand");
            Console.WriteLine("3. DropShot");
            Console.Write("\nWhich shot would you like to practice? ");
            response = Console.ReadLine();
            Console.Clear();

            if (response == "1") {
                ForehandDrill drill  = new ForehandDrill();
            }
            else if (response == "2") {
                BackhandDrill drill  = new BackhandDrill();

            }
            else if (response == "3") {
                DropShotDrill drill  = new DropShotDrill(); 
            }
            else{
                Console.WriteLine("No entiendo");
            }


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

        case "9":
    
        foreach (Player person in players){
            string info = person.displayInfo();
            Console.WriteLine($"{info}");
            
        }
            break;
        
    }
}
}




// @startuml
// abstract class Shot {
//     - _shotLevel: int
//     - _shotName: string
//     - _shotDescription: string
// }

// class ForehandShot {
//     - _shotName: string = "ForehandShot"
// }

// class BackhandShot {
//     - _shotName: string = "BackhandShot"
// }

// class DropShot {
//     - _shotName: string = "DropShot"
// }

// abstract class Drill {
//     - _drillName: string
//     - _drillDescription: string
//     - _completionPoints: int
//     + abstract runDrill(): void
// }

// class ForehandDrill {
//     + runDrill(): void
// }

// class BackhandDrill {
//     + runDrill(): void
// }

// class DropShotDrill {
//     + runDrill(): void
// }



// class Game {
//     - _opponentScore: int
//     - _yourScore: int
//     - description: string
//     + getDescription(): string
// }

// class SinglesGame {
//     // properties and methods
// }

// class DoublesGame {
//     // properties and methods
// }

// class Program {
//     - running: bool
//     - players: List<Player>
//     - tips: List<Tip>
//     + Main(string[] args): void
//     + openLink(string link): void
//     + displayMenu(): void
// }

// class Player {
//     - _name: string
//     - _age: string
//     - _experience: int
//     + Player()
//     + Player(string name, string age, int experience)
//     + displayInfo(): string
//     + getName(): string
//     + getAge(): string
//     + getExperience(): int
// }

// class Tip {
//     - _requiredLevel: int
//     - _tipName: string
//     - _tipLink: string
//     + Tip(int level, string name, string link)
//     + getName(): string
//     + getLink(): string
// }

// Program --> Player
// Program --> Tip
// Shot <|-- ForehandShot
// Shot <|-- BackhandShot
// Drill <|-- ForehandDrill
// Drill <|-- BackhandDrill
// Drill <|-- DropShotDrill
// Shot <|-- DropShot
// Game <|-- SinglesGame
// Game <|-- DoublesGame

// @enduml
