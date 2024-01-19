using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
       DisplayWelcome();
       string user_name = PromptUsernName();
       int num = PromptUserNumber();
       int sqaure = SqaureNumber(num);
       DisplayResult(user_name, sqaure);

     static void DisplayWelcome()
    {
    Console.WriteLine("Welcome to the Program!");
    }  
    
        static string PromptUsernName()
    {
    Console.Write("Please enter your name: ");
    string user_name = Console.ReadLine();
    return user_name;
    }  
    
        static int PromptUserNumber()
    {
    Console.Write("Please enter your favorite number: ");
    string input = Console.ReadLine();
    int num = int.Parse(input);
    return num;
    }
    
    static int SqaureNumber(int num)
    {
        int Sqaure = num * num;
        return Sqaure;
    }
    static void DisplayResult(string user_name, int sqaure)
    {
        Console.WriteLine($"{user_name}, the square of your number is {sqaure}");
    }
}
}


// SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
// DisplayResult - Accepts the user's name and the squared number and displays them.