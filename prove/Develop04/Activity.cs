using System.Drawing;

class Activity{
// Welcome to the *** Activity:
  public void loadAnimation(){
        int load_speed = 200;
        int i = 0;

        while (i < 10){

        Console.Write("-");
        Thread.Sleep(load_speed);
        Console.Write("\b \b"); // Erase the + character

        Console.Write("\\"); 
        Thread.Sleep(load_speed);
        Console.Write("\b \b"); // Erase the + character

        Console.Write("|"); 
        Thread.Sleep(load_speed);
        Console.Write("\b \b"); // Erase the + character

        Console.Write("/"); 
        Thread.Sleep(load_speed);
        Console.Write("\b \b"); // Erase the + character
        i++;
        }
    }

public void getReady(){
    Console.WriteLine("Get Ready...");
    loadAnimation();

}



public void endOfActivity(){
    Console.WriteLine("Well Done!!");
    Console.WriteLine($"You have completed the name");
}
}