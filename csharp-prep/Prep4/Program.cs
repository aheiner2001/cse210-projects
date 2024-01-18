using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string user_input = "";

       
  
    
        
        int input;
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        Console.Write("Enter number: ");
        user_input =  Console.ReadLine();
        input = int.Parse(user_input);

        while(input != 0){
            numbers.Add(input);
            Console.Write("Enter number: ");
            user_input =  Console.ReadLine();
            input = int.Parse(user_input);
        }
        int sum = 0;
        int largest_num = 0;
        foreach (int num in numbers) {
             sum += num;  
             if (num >largest_num){
                largest_num = num;
             }

        }
        float average = ((float)sum / numbers.Count);

        Console.WriteLine($"The sume is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest_num}");

    }
}


//   
//   

//   The sum is: 131
//   The average is: 18.714285714285715
//   The largest number is: 48
  