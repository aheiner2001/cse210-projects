using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        Job job1 = new Job();
        job1._company = "microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2020;
        

        Job job2 = new Job();
        job2._company = "apple";
        job2._jobTitle = "Programmer";
        job2._startYear = 2020;
        job2._endYear = 2022;
        
    // create a new resume
    Resume resume = new Resume();

// add name instance
    resume._name = "Howl Slamo";

    // add two jobs to the list
    resume._Jobs.Add(job1);
    resume._Jobs.Add(job2);
    // and then displau
      
    resume.display();

    
    }
}