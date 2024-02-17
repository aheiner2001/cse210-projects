using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string response = "";

        string[] referencetext = Program.getScripture().Split("||");
        Reference reference = new Reference(referencetext[0]);

        string[] words = referencetext[1].Split(' ');

        Scripture scripture = new Scripture(words);

        while (response != "quit" && !scripture.AllWordsHidden)
        {
            // Display the scripture
            Console.WriteLine("\n\nPress enter to continue or type 'quit' to finish: ");
            response = Console.ReadLine();
            if (response == "quit")
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.Write(reference.ToString());
                Console.Write(scripture.GetRenderedText());

                // Hide a few random words
                scripture.HideRandomWords();
            }
        }
    }



  static string getScripture()
{
    string[] scriptures = {
        "Romans 8:28 - And we know that in all things God works for the good of those who love him, who have been called according to his purpose.",
                "Isaiah|41|0| || So do not fear, for I am with you; do not be dismayed, for I am your God. I will strengthen you and help you; I will uphold you with my righteous right hand.",
                "Matthew|6|33| || But seek first his kingdom and his righteousness, and all these things will be given to you as well.",
                "Jeremiah|9|11| || For I know the plans I have for you,” declares the LORD, “plans to prosper you and not to harm you, plans to give you hope and a future.",
                "John|14|6| || Jesus answered, 'I am the way and the truth and the life. No one comes to the Father except through me.'",
                "Psalm|46|10| || He says, 'Be still, and know that I am God; I will be exalted among the nations, I will be exalted in the earth.'",
                "Ephesians|2|8|9| ||  For it is by grace you have been saved, through faith—and this is not from yourselves, it is the gift of God— not by works, so that no one can boast.",
                "Proverbs|16|9| ||  In their hearts humans plan their course, but the LORD establishes their steps.",
                "Romans|12|2| || Do not conform to the pattern of this world, but be transformed by the renewing of your mind. Then you will be able to test and approve what God’s will is—his good, pleasing and perfect will."
    };
    
    if (scriptures.Length == 0)
    {
        // Handle the case when scriptures array is empty
        throw new InvalidOperationException("Scriptures array is empty.");
    }
    
    Random random = new Random();
    return scriptures[random.Next(scriptures.Length)];
}
}

class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;
    private string _end_verse;

    public Reference(string text)
    {
        string[] parts = text.Split("|");
        _book = parts[0];
        _chapter = parts[1];
        _verse = parts[2];
        _end_verse = parts.Length > 3 ? parts[3] : "";
    }

    public override string ToString()
    {
        if (_end_verse != "")
        {
            return _book + " " + _chapter + ":" + _verse + "-" + _end_verse + "\n";
        }
        else
        {
            return _book + " " + _chapter + ":" + _verse + "\n";
        }
    }
}

class Scripture
{
    private Word[] _words;
    private bool _allWordsHidden;

    public bool AllWordsHidden { get { return _allWordsHidden; } }

    public Scripture(string[] words)
    {
        _words = new Word[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            _words[i] = new Word(words[i]);
        }
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, 4); // Choose 1 to 3 words to hide

        List<int> indicesToHide = new List<int>();
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(_words.Length);
            if (!_words[index].IsHidden) // Ensure word is not already hidden
            {
                _words[index].Hide();
                indicesToHide.Add(index);
            }
        }

        _allWordsHidden = _words.All(word => word.IsHidden);

        // Redisplay scripture with hidden words
        Console.WriteLine("\nScripture with hidden words:");
        foreach (Word word in _words)
        {
            Console.Write(word.GetRenderedText() + " ");
        }
    }

    public string GetRenderedText()
    {
        string renderedText = "";
        foreach (Word word in _words)
        {
            renderedText += word.GetRenderedText() + " ";
        }
        return renderedText;
    }
}

class Word
{
    private string _word;
    private bool _isHidden;

    public bool IsHidden { get { return _isHidden; } }

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetRenderedText()
    {
        return _isHidden ? "____" : _word;
    }
}
