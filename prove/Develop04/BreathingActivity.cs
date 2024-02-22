using System.Security.Cryptography.X509Certificates;

class BreathingActivity : Activity
{   private string name = "Breathing";
    public void runactivity(){
    
    getReady();
    Console.WriteLine("\nWelcome to the breathing activity. \n");
    Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.\n");
    getReady();
    int sec = getTime();
    DateTime endTime = getEndtime(sec);


   while (DateTime.Now < endTime){
        int i = 4;
        Console.Write("\n\nBreathe in ...");
        while (i != 0) {
        Console.Write($"{i}");
        Thread.Sleep(1000);
        Console.Write("\b \b"); 
        i--;
        }


        i = 6;
        Console.Write("\nNow breathe out...");
        while (i != 0) {
        Console.Write($"{i}");
        Thread.Sleep(1000);
        Console.Write("\b \b"); 
        i--;
        }
   }
    endOfActivity(sec, name);
    loadAnimation();
 }
}