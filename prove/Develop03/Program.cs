using System;
using System.Net;

// notes
//  why do I need the word class? to track each individual word,so that means I should hide them first in the word class and then use that list 
// how can I hide only the words that need to be hidden?
// 
// 

class Program
{
    static void Main(string[] args)
    {
        string response = "";
        
        
      
      
        string[] referencetext = Program.getScripture().Split("||");
        Reference reference = new Reference(referencetext[0]);
        
        string[] words = referencetext[1].Split(' ');
       
        Scripture scripture = new Scripture(words);
        
        Console.Write(reference.toString());
        Console.Write(scripture.GetRenderedText());
        while (response != "quit" && scripture.WordsHidden() == false )
        {
            // Dislpay the scripture
            Console.WriteLine("\n\nPress enter to continue or type 'quit' to finish: ");
            response  = Console.ReadLine();
            if (response == "quit"){
                break;
            }
            else{
                
                if (scripture.WordsHidden()){
                    response = "quit";
                }
                scripture.HideRandomWords();
                Console.Clear();
                Console.Write(reference.toString());
                Console.Write(scripture.GetRenderedText());

                // Hide a few random words
                
                
                
          

            }
        }
    }
    static string getScripture()
    {
        string [] scriptures = {"Romans |8|28| || And we know that in all things God works for the good of those who love him, who have been called according to his purpose.",
                    "Isaiah|41|0| || So do not fear, for I am with you; do not be dismayed, for I am your God. I will strengthen you and help you; I will uphold you with my righteous right hand.",
                    "Matthew|6|33| || But seek first his kingdom and his righteousness, and all these things will be given to you as well.",
                    "Jeremiah|9|11| || For I know the plans I have for you,” declares the LORD, “plans to prosper you and not to harm you, plans to give you hope and a future.",
                    "John|14|6| || Jesus answered, 'I am the way and the truth and the life. No one comes to the Father except through me.'",
                    "Psalm|46|10| || He says, 'Be still, and know that I am God; I will be exalted among the nations, I will be exalted in the earth.'",
                    "Ephesians|2|8|9| ||  For it is by grace you have been saved, through faith—and this is not from yourselves, it is the gift of God— not by works, so that no one can boast.",
                    "Proverbs|16|9| ||  In their hearts humans plan their course, but the LORD establishes their steps.",
                    "Romans|12|2| || Do not conform to the pattern of this world, but be transformed by the renewing of your mind. Then you will be able to test and approve what God’s will is—his good, pleasing and perfect will."
    };
    Random random = new Random();
    return scriptures[random.Next(scriptures.Length)];
}
}