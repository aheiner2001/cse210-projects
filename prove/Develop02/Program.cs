using System;
using System.ComponentModel.Design;
using System.Data;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


class Journal
{
    // add entry
    private List<Entry> entries = new List<Entry>();
    public void addEntry(string prompt, string response)
    {
        
        Entry entry = new Entry(prompt,response);
        
        entries.Add(entry);
    
    }

    public string prompt()
    {
            List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "Describe a moment that made you laugh today.",
            "What was the most challenging aspect of your day?",
            "Write about a goal you accomplished today, big or small.",
            "How did you practice self-care today?",
            "Reflect on a decision you made and its impact on your day.",
            "What is a new thing you learned or discovered today?",
            "Write about a moment of gratitude from today.",
            "If you could change one thing about today, what would it be?",
            "Describe a place you visited or wish to visit in the future.",
            "Reflect on a conversation that left an impression on you today."
        };

    return prompts[new Random().Next(prompts.Count)];
     
        
    }

    public void DisplayEntries()
    {
        
        foreach(Entry entry in entries)
        {
            Console.Write($"{entry.Date} {entry.Prompt} \n{entry.Response}");
            
        }
//         }
//         public override string ToString()
// {
//     return $"Date: {Date} - Prompt: {Prompt} - Response: {Response}\n";
// }
    }

    public void LoadFile(string filename)
{
    entries.Clear();
    string[] lines = System.IO.File.ReadAllLines(filename);

    List<Entry> loadedEntries = new List<Entry>();

    foreach (string line in lines)
    {
        string[] parts = line.Split("|");

        if (parts.Length >= 3)
        {
            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];

            Entry entry = new Entry(prompt, response);
            entry.Date = date;
            loadedEntries.Add(entry);
        }
    }

    entries.AddRange(loadedEntries);
}


    public void SaveFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
         {
            foreach (Entry entry in entries){
                outputFile.WriteLine(entry);
            }
       
                    
    }

    // display
    // load
    // save
}
class Entry{
    public string Date {get; set;}
    public string Prompt {get; set;}
    public string Response {get; set;}

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        DateTime theCurrentTime = DateTime.Now;
        Date = theCurrentTime.ToShortDateString();
    }

   public override string ToString()
    {
        return $"Date:{Date}- |Promt:{Prompt} |{Response} \n";
    }
    

   
 }
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

       

        Console.WriteLine("Welcome to the Journal Program!");
        bool running = true;

        while (running)
        {
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Write ");
            Console.WriteLine("2. Display ");
            Console.WriteLine("3. Load ");
            Console.WriteLine("4. Save ");
            Console.WriteLine("5. Quit ");
            Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    string prompt = journal.prompt();
                    Console.WriteLine(prompt);
                    string response = Console.ReadLine();
                    journal.addEntry(prompt, response);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.WriteLine("Which file would you like to load?: ");
                    string filename = Console.ReadLine();
                    journal.LoadFile(filename);
                    break;

                case "4":
                    Console.WriteLine("Which file would you like to save?: ");
                    string save_as = Console.ReadLine();
                    journal.SaveFile(save_as);
                   
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }
}
}
