using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{
    private string name = "Listing";
    private string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    public void runactivity()
    {
      getIntro(name, description);
        int sec = getTime();
        activity(sec);
        endOfActivity(sec, name);
    }

    private void activity(int sec)
    {
        int items = 0;
        getReady();

        List<string> prompts = new List<string>();
        prompts.Add("Who are people that you appreciate?");
        prompts.Add("What are personal strengths of yours?");
        prompts.Add("Who are people that you have helped this week?");
        prompts.Add("When have you felt the Holy Ghost this month?");
        prompts.Add("Who are some of your personal heroes?");

        Random rand = new Random();
        int randomIndex = rand.Next(0, prompts.Count);
        string prompt = prompts[randomIndex];
        Console.WriteLine("List as many responses as you can to the following prompt: ");
        Console.WriteLine($"--- {prompt} ---");

        begin_countdown();

        Console.WriteLine();

        DateTime endTime = getEndtime(sec);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            items++;
        }
        Console.WriteLine($"You listed {items} items");
    }
}
