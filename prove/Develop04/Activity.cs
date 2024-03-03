using System;
using System.Dynamic;
using System.Threading;

class Activity
{
    public string _name;
    public string _description;

   
     public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void loadAnimation()
    {
        int load_speed = 200;
        int i = 0;

        while (i < 5)
        {
            Console.Write("-");
            Thread.Sleep(load_speed);
            Console.Write("\b \b"); 

            Console.Write("\\");
            Thread.Sleep(load_speed);
            Console.Write("\b \b"); 

            Console.Write("|");
            Thread.Sleep(load_speed);
            Console.Write("\b \b"); 

            Console.Write("/");
            Thread.Sleep(load_speed);
            Console.Write("\b \b");
            i++;
        }
    }

   
    public void getReady()
    {
        Console.Clear();
        Console.WriteLine("Get Ready...");
        loadAnimation();
    }

   
    public void begin_countdown()
    {
        int i = 5;
        Console.Write($"You may begin in: ");
        while (i != 0)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i--;
        }
    }

    public void endOfActivity(int sec, string activity_name)
    {
        Console.WriteLine("\n\nWell Done!!");
        Console.WriteLine($"\nYou have completed another {sec} seconds of the {activity_name} activity!");
        loadAnimation();
        loadAnimation();
    }

    public int getTime()
    {
        string seconds = "";
        Console.Write("How long, in seconds, would you like for your session? ");
        seconds = Console.ReadLine();
        int secs = int.Parse(seconds);
        return secs;
    }

    public DateTime getEndtime(int sec)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(sec);
        return endTime;
    }
    public void getIntro(string name, string description){
         Console.Clear();
         Console.WriteLine($"Welcome to the {name} activity.\n");
         Console.WriteLine($"{description}\n");
      }
}
