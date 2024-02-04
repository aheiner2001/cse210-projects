using System;
using System.Collections.Generic;
using System.IO;

// Class to represent a journal entry
class JournalEntry
{
    // Properties for prompt, response, and date
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    // Constructor to create a new journal entry with a given prompt and response
    public JournalEntry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        // Record the current date and time when the entry is created
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    // Override ToString method to easily display the entry
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

// Class to represent a journal
class Journal
{
    // List to store journal entries
    private List<JournalEntry> entries;

    // Constructor to initialize the list of entries
    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    // Method to add a new entry to the journal
    public void AddEntry(string prompt, string response)
    {
        // Create a new journal entry and add it to the list
        JournalEntry entry = new JournalEntry(prompt, response);
        entries.Add(entry);
    }

    // Method to display all entries in the journal
    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            // Display each entry by calling its ToString method
            Console.WriteLine(entry.ToString());
        }
    }

    // Method to save the journal to a file
    public void SaveToFile(string fileName)
    {
        // Use StreamWriter to write entries to a file
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                // Save each entry in the format: Date|Prompt|Response
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    // Method to load entries from a file into the journal
    public void LoadFromFile(string fileName)
    {
        // Clear existing entries before loading from a file
        entries.Clear();
        try
        {
            // Use StreamReader to read entries from a file
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    // Split each line into parts based on the separator (|)
                    string[] parts = reader.ReadLine().Split('|');
                    if (parts.Length == 3)
                    {
                        // Create a new journal entry and add it to the list
                        JournalEntry entry = new JournalEntry(parts[1], parts[2]);
                        entry.Date = parts[0];
                        entries.Add(entry);
                    }
                }
            }
            Console.WriteLine("Journal loaded from file.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Creating a new journal.");
        }
        
    }
}

// Main program class
class Program
{
    static void Main()
    {
        // Create an instance of the Journal class
        Journal journal = new Journal();
        // Create a Random object for generating random prompts
        Random random = new Random();

        while (true)
        {
            // Display the menu to the user
            Console.WriteLine("\n1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
 
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                // Process the user's choice
                switch (choice)
                {
                    case 1:
                        // Generate a random prompt and ask the user for a response
                        string randomPrompt = GetRandomPrompt();
                        Console.WriteLine($"Prompt: {randomPrompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        // Add a new entry to the journal
                        journal.AddEntry(randomPrompt, response);
                        break;

                    case 2:
                        // Display all entries in the journal
                        journal.DisplayEntries();
                        break;

                    case 3:
                        // Ask the user for a filename and save the journal to that file
                        Console.Write("Enter the filename to save the journal: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveToFile(saveFileName);
                        break;

                    case 4:
                        // Ask the user for a filename and load the journal from that file
                        Console.Write("Enter the filename to load the journal: ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadFromFile(loadFileName);
                        break;

                    case 5:
                        // Exit the program
                        Environment.Exit(0);
                        break;

                    default:
                        // Inform the user of an invalid choice
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                // Inform the user of invalid input
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    // Method to get a random prompt from a predefined list
    static string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        // Return a random prompt from the list
        return prompts[new Random().Next(prompts.Count)];
    }
}
