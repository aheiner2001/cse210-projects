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
      public void loadAnimation2(){
        int load_speed = 25;
        int i = 0;

        int num_dots = 25;
        int j = 0;

        while (i < 10){

        Console.Clear();
        while(j < num_dots){
        Console.Write(".");
        Thread.Sleep(load_speed);
        j++;
        }
        
        i++;
        }
    }

public void getReady(){
    Console.WriteLine("Get Ready...");
    loadAnimation();
    loadAnimation2();

}



public void endOfActivity(){
    Console.WriteLine("Well Done!!");
    Console.WriteLine($"You have completed the name");
}
}