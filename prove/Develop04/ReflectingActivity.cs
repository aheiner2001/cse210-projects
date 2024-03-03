using System;
using System.Collections.Generic;
using System.Threading;

class ReflectingActivity : Activity
{
    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void runactivity()
    {
        getIntro(_name, _description);
        int sec = getTime();
        activity(sec);
        endOfActivity(sec, _name);
    }

    private void activity(int sec)
    {
        getReady();

        List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        List<string> reflectionQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        Random rand = new Random();
        int randomIndex = rand.Next(0, prompts.Count);
        string prompt = prompts[randomIndex];

        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine($"\n--- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue");
        Console.ReadLine();
        Console.WriteLine("Now Ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        begin_countdown();
        Console.Clear();

        DateTime endTime = getEndtime(sec);
        while (DateTime.Now < endTime)
        {
            rand = new Random();
            randomIndex = rand.Next(0, reflectionQuestions.Count);
            string question = reflectionQuestions[randomIndex];
            Console.Write($"\n> {question}");
            loadAnimation();
            loadAnimation();
        }
    }
}

