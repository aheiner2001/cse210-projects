using System;
using System.Threading;

class BreathingActivity : Activity
{   
    private string name = "Breathing";
    private string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";

    public void runactivity()
    {
        getIntro(name, description);
        int sec = getTime();
        getReady();
        DateTime endTime = getEndtime(sec);
        activity(endTime);
        endOfActivity(sec, name);
    }

    private void activity(DateTime endTime)
    {
        while (DateTime.Now < endTime)
        {
            int i = 4;
            Console.Write("\n\nBreathe in ...");
            while (i != 0)
            {
                Console.Write($"{i}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                i--;
            }

            i = 6;
            Console.Write("\nNow breathe out...");
            while (i != 0)
            {
                Console.Write($"{i}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                i--;
            }
        }
    }
}
