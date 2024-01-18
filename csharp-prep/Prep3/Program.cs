using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the guessing game!");
        Console.WriteLine("Guess the rigth number in the least amount of tries as possible");
        Console.WriteLine("The number will be between 1-100");

 string user_input;
 Random randomGenerator = new Random();
 int magic_number = randomGenerator.Next(1, 100);
 int input;
    do
    {
         Console.Write("Your Guess? ");
        user_input = Console.ReadLine();
        input = int.Parse(user_input);
        Console.WriteLine();
        if (input == magic_number){
            Console.WriteLine("Goofy Job, you guessed the magic numebr, welcome to goof town, where gafs are meant to florish");
        }
        else if (input > magic_number){
            Console.WriteLine("Lower");
        }
        else if (input < magic_number){
            Console.WriteLine("Higher");
        }
        
        Console.WriteLine();
    } while (input != magic_number);

        Console.WriteLine($"You guessed {user_input}");
    }
}

