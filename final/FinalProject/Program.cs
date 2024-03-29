using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Collections.Generic;

class Program
{   static bool running = true;
    static List<Player> players = new List<Player>();
    static List<Tip> tips = new List<Tip>()
    
    {
        new Tip(2,"Tip 1", "https://www.youtube.com/watch?v=fsgJa0OgeRE"),
        new Tip(5,"Tip 2", "https://www.youtube.com/watch?v=Jgr4Yo9JrO4"),
        new Tip(7,"Tip 3", "https://www.youtube.com/watch?v=-raCQ4em4Lc"),
        new Tip(9,"Tip 4", "https://www.youtube.com/watch?v=ZkYLOfyAUr8"),
        new Tip(12,"Tip 5", "https://www.youtube.com/watch?v=5bnLUkNb7PA")
    };
    static List<Game> games = new List<Game>();


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
    Console.WriteLine("1. Create Player");  //complete
    Console.WriteLine("2. Guided Pracitce");  //complete
    Console.WriteLine("3. Log Game"); // complete
    Console.WriteLine("4. View Games");  //complete
    Console.WriteLine("5. View Stats");   //comp;ete
    Console.WriteLine("6. Tip Store"); //complete
    Console.WriteLine("7. Load");
    Console.WriteLine("8. Save and Quit");
    Console.WriteLine("9. Show list of players"); //complete
    Console.Write("\nWhat would you like to do? "); //complete
    string response =  Console.ReadLine();

    switch(response){
        case "1":
            Console.WriteLine(" How many players would you like to add? ");
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
            int responsy = int.Parse(Console.ReadLine());
            Console.Clear();
            int j = 1;
            foreach(Player player in players){
                    Console.WriteLine($"{j}. {player.getName()}");
                    j++;
                }
                Console.Write("Which player is completing the practice: ");
                int input = int.Parse(Console.ReadLine()) - 1;
                Player student  = players[input];
            if (responsy == 1) {
                

                 ForehandDrill drill  = new ForehandDrill();
                
                student.setExperience(drill.getPoints());
                var shots = student.getShots(); 
                var shot = shots[responsy - 1];
                shot.upDateShotLevel(drill.getPoints());

                

            }
            else if (responsy == 2) {
                BackhandDrill drill  = new BackhandDrill();
                student.setExperience(drill.getPoints());
                var shots = student.getShots(); 
                var shot = shots[responsy - 1];
                shot.upDateShotLevel(drill.getPoints());

            }
            else if (responsy == 3) {
                DropShotDrill drill  = new DropShotDrill(); 
                student.setExperience(drill.getPoints());
                var shots = student.getShots(); 
                var shot = shots[responsy - 1];
                shot.upDateShotLevel(drill.getPoints());
            }
            else{
                Console.WriteLine("No entiendo");
            }


            break;
        
        case "3":
            Console.WriteLine("1. Singles");
            Console.WriteLine("2. Doubles");
            Console.Write("Which type of game do you want to log? ");
            int inputy = int.Parse(Console.ReadLine());
            if (inputy == 1){
             
            
                Console.WriteLine("who is the first player? ");
                string player1 = playerSelection();
                

                Console.WriteLine("who is the second player? ");
                string player2 = playerSelection();

                    SinglesGame singles = new SinglesGame(player1, player2);
                    
                    games.Add(singles);
                    Console.WriteLine(singles);
                    if (singles.getScoreTeam1() > singles.getScoreTeam2()){
                        foreach(Player player in players){
                            if(player.getName() == player1){
                                player.setExperience(.25m);
                            }
                              if(player.getName() == player1){
                                if (player.getExperience() >= .0125m){
                                player.setExperience(-.25m);
                                  }
                            }
                            
                        }

                    }
                    else if (singles.getScoreTeam1() < singles.getScoreTeam2()){
                        foreach(Player player in players){
                            if(player.getName() == player2){
                                player.setExperience(.25m);
                            }
                            if(player.getName() == player1){
                                if (player.getExperience() >= .0125m){
                                player.setExperience(-.25m);
                                  }
                            }
                            
                            
                        }

                    }

                }
            else if( inputy ==2){
                Console.WriteLine("who is the first player? ");
                string player1 = playerSelection();

                Console.WriteLine("who is the second player? ");
                string player2 = playerSelection();

                Console.WriteLine("who is the first player? ");
                string player3 = playerSelection();

                                Console.WriteLine("who is the second player? ");
                string player4 = playerSelection();

                DoublesGame doubles = new DoublesGame(player1, player2, player3, player4);
                games.Add(doubles);
                Console.WriteLine(doubles);
                 if (doubles.getScoreTeam1() > doubles.getScoreTeam2()){
                        foreach(Player player in players){
                            if(player.getName() == player1 || player.getName() == player2){
                                
                                player.setExperience(.25m);
                            }
                            if(player.getName() == player3|| player.getName() == player4){
                                if (player.getExperience() >= .0125m){
                                player.setExperience(-.25m);
                                }
                            }
                            
                        }

                    }
                    else if (doubles.getScoreTeam1() < doubles.getScoreTeam2()){
                        foreach(Player player in players){
                            if(player.getName() == player3 || player.getName() == player4){
                                player.setExperience(.25m);

                            }
                             if(player.getName() == player1 || player.getName() == player2){
                                if (player.getExperience() >= .0125m){
                                player.setExperience(-.25m);
                                }

                            }

                            
                            
                            
                        }

                    }

            }


            break;
        
        case "4":
                int gameNum = 1;
                foreach(Game game in games){
                    Console.WriteLine($"Game #{gameNum} {game}");
                    gameNum++;
                }
            break;
        
        case "5":

            foreach(Player player in players){
                Console.WriteLine($"{player.getName()} Level:{player.getExperience()} ");
                List<Shot> shots = player.getShots();
                foreach (Shot shot in shots){
                    Console.WriteLine($"    {shot.getName()}: {shot.getShotLevel()}");
                }
                Console.WriteLine();
                
            
            }
            break;
        
        case "6":
            Console.Clear();
            j = 1;
            foreach(Player player in players){
                    Console.WriteLine($"{j}. {player.getName()}");
                    j++;
                }
            if (players.Count() == 0 ){
                Console.WriteLine("Create a player first");
                break;
            }
            Console.Write("Which Player? ");
            input = int.Parse(Console.ReadLine()) - 1;
            student  = players[input];
            decimal level = student.getExperience();
            int h = 1;
            foreach(Tip tip in tips){
                Console.WriteLine();
                if (level >= tip.getRequiredLevel()){
                    Console.WriteLine($"{h}. {tip.getName()}");
                   
                }
                else{
                    Console.WriteLine($"{h}. Get to level {tip.getRequiredLevel()} to unlock this tip");
                }
                h++;
            }
            Console.Write("Which tip would you like to learn? ");
            int selection = int.Parse(Console.ReadLine())-1;

            if (level >= tips[selection].getRequiredLevel()){
                openLink(tips[selection].getLink());
                   
            }
            else{
                Console.WriteLine("Need more experience");
            }
          




            
            break;
        
        case "7":
            string filename = "TennisProgram.txt";
                string[] lines = System.IO.File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] parts = line.Split("||");
                    string type = parts[0];

                        switch (type)
                        {
                            case "Player":
                                string name = parts[1];
                                string age = parts[2];
                             decimal  experience = decimal.Parse( parts[3]);
                                decimal forehand = decimal.Parse( parts[4]);
                                decimal backhand = decimal.Parse( parts[5]);
                                decimal dropshot = decimal.Parse( parts[6]);
                                Player player = new Player(name, age, experience,forehand, backhand, dropshot);
                                players.Add(player);

                                
                                break;
                            case "SinglesGame":
                                string player1 = parts[1];
                                int player1score = int.Parse(parts[2]);
                                string player2 = parts[3];
                                int player2score= int.Parse(parts[4]);
                        
                                SinglesGame singles = new SinglesGame(player1, player1score, player2, player2score);
                                games.Add(singles);

                                break;
                            case "DoublesGame":
                              player1 = parts[1];
                                 player2 = parts[2];
                                 player1score= int.Parse(parts[3]);

                               string player3 = parts[4];
                                string player4= parts[5];
                                 player2score= int.Parse(parts[6]);
                               
                            DoublesGame doubles = new DoublesGame(player1, player2, player1score, player3, player4, player2score);
                                games.Add(doubles);
                             
                                break;
                            default:
                                Console.WriteLine("Error");
                                break;
                        }
                    }
                   
            
                break;
    
        
        case "8":

           
                 filename = "TennisProgram.txt";
                Console.WriteLine("Would you like to overwrite or add to the file? (1)Overwrite (2)Add ");
                Console.WriteLine("Override for if you loaded your previous data, add if you didn't load but want to add to the file.");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                if (choice == "1"){
                    clearFile(filename);
                }

                foreach (Player player in players)
                {
                    player.savePlayer(filename);
                    
                }
                foreach (Game game in games){
                    game.saveGame(filename);
                }
    
            break;

        case "9":
    
        foreach (Player person in players){
            string info = person.displayInfo();
            Console.WriteLine($"{info}");
            
        }
            break;
        
    }
}
static string playerSelection(){
       int j = 1;
            foreach(Player guy in players){
                    Console.WriteLine($"{j}. {guy.getName()}");
                    j++;
                }
        
            Console.Write("Select Player:  ");
            int input = int.Parse(Console.ReadLine()) - 1;
            string player  = players[input].getName();
            return player;

            
}

static void clearFile(string filename)
{
    using (StreamWriter sw = new StreamWriter(filename, false))
    {
        sw.Write("");
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
