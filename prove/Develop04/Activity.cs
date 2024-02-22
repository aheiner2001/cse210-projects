using System.Drawing;

class Activity{
// Welcome to the *** Activity:
  public void loadAnimation(){
        int load_speed = 200;
        int i = 0;

        while (i < 5){

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
    //  

public void getReady(){
    Console.Clear();
    Console.WriteLine("Get Ready...");
    loadAnimation();
    

}
 public void runactivity(){

    Console.WriteLine("eat");
 }



public void endOfActivity(int sec, string activity_name){
    Console.WriteLine("Well Done!!");
    Console.WriteLine($"\nYou have completed another {sec} seconds of the {activity_name} activity!");
}

public int getTime(){
        string seconds = "";
        Console.Write("How long, in seconds, would you like for your session? ");
        seconds = Console.ReadLine();
        int secs= int.Parse(seconds); 
        return secs;
    }
public DateTime getEndtime(int sec){
    
    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(sec);
    return endTime;
    }
}





//  public void loadAnimation2(){
//     //     int load_speed = 25;
//     //     int i = 0;

//     //     int num_dots = 25;
//     //     int j = 0;

//     //     while (i < 10){

//     //     Console.Clear();
//     //     while(j < num_dots){
//     //     Console.Write(".");
//     //     Thread.Sleep(load_speed);
//     //     j++;
//     //     }
        
//     //     i++;
//     //     }
//     // }