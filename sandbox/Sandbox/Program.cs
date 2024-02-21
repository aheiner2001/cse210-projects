using System;

class Program
{
    static void Main(string[] args)
    {
        int i = 0;
        while ( i< 6){
Console.Write("+");

Thread.Sleep(500);

Console.Write("\b \b"); // Erase the + character
Console.Write("-"); // Replace it with the - character
            i++;
        }

    }
}