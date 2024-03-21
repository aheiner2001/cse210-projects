class Drill{
    
    private string _name;
    private string _description;

    private int _points;
    private string _setup;
    private string _objective;
    private string _execution;
public Drill(string name, string description, int points, string Setup, string objective, string execution){
    _name = name;
    _description = description;
    _points = points;
    _setup = Setup;
    _objective= objective;
    _execution= execution;
    Console.WriteLine($"{_name}:\n{_description}\nYou will recieve {_points} experience by completing this practice");
    Console.Write("Press Enter to begin. ");
    Console.ReadLine();
    runDrill();
}


public void runDrill(){
    Console.Clear();
    loadAnimation();
    Console.WriteLine(_name);
    Console.WriteLine(_objective);
    enterContinue();
    
    Console.WriteLine(_setup);
    
  

    Console.WriteLine(_execution);
    loadAnimation();
    Console.WriteLine($"You have completed the {_name}. You have recieved {_points} experience points");

}


 public void loadAnimation()
    {
        int load_speed = 200;
        int i = 0;

        while (i < 5)
        {
            Console.Write("-");
            Thread.Sleep(load_speed);
            Console.Write("\b \b"); 

            Console.Write("\\");
            Thread.Sleep(load_speed);
            Console.Write("\b \b"); 

            Console.Write("|");
            Thread.Sleep(load_speed);
            Console.Write("\b \b"); 

            Console.Write("/");
            Thread.Sleep(load_speed);
            Console.Write("\b \b");
            i++;
        }
    }

    public void enterContinue(){
            Console.Write("Press Enter to Continue. ");
    Console.ReadLine();
    }
}