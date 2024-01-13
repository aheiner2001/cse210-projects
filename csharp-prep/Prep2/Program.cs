using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {


// Assume that you must have at least a 70 to pass the class. After determining the letter grade and printing it out. Add a separate if statement to determine if the user passed the course, and if so display a message to congratulate them. If not, display a different message to encourage them for next time.

// Change your code from the first part, so that instead of printing the letter grade in the body of each if, elif, or else block, instead create a new variable called letter and then in each block, set this variable to the appropriate value. Finally, after the whole series of if-elif-else statements, have a single print statement that prints the letter grade once.
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int grade_num = int.Parse(grade);
        string grade_letter;

        if (grade_num >= 90)
        {
            grade_letter = "A";
        }
        else if (grade_num >= 80)
        {
            grade_letter = "B";
        }
        else if (grade_num >= 70)
        {
            grade_letter = "C";
        }
        else if (grade_num >= 60)
        {
            grade_letter = "D";
        }
        else
        {
            grade_letter = "F";
        }

        
        
        Console.WriteLine($"Your letter grade is {grade_letter}");
    }
}