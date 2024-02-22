using System;
using System.Collections.Generic;
using System.Threading;

class ReflectingActivity : Activity
{
    private string name = "Reflecting";
    private string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use in other aspects of your life.";

    public void runactivity()
    {
        getIntro(name, description);
        int sec = getTime();
        activity(sec);
        endOfActivity(sec, name);
    }

    private void activity(int sec)
    {
        getReady();

        List<string> prompts = new List<string>();
        prompts.Add("Think of a time when you stood up for someone else.");
        prompts.Add("Think of a time when you did something really difficult.");
        prompts.Add("Think of a time when you helped someone in need.");
        prompts.Add("Think of a time when you did something truly selfless.");

        List<string> reflectionQuestions = new List<string>();
        reflectionQuestions.Add("Why was this experience meaningful to you?");
        reflectionQuestions.Add("Have you ever done anything like this before?");
        reflectionQuestions.Add("How did you get started?");
        reflectionQuestions.Add("How did you feel when it was complete?");
        reflectionQuestions.Add("What made this time different than other times when you were not as successful?");
        reflectionQuestions.Add("What is your favorite thing about this experience?");
        reflectionQuestions.Add("What could you learn from this experience that applies to other situations?");
        reflectionQuestions.Add("What did you learn about yourself through this experience?");
        reflectionQuestions.Add("How can you keep this experience in mind in the future?");

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
