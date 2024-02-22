class ReflectingActivity: Activity
{
    private string name = "Reflecting";
    private string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use in other aspects of your life.";

    public void runactivity(){
    Console.Clear();
    Console.WriteLine($"Welcome to the {name} activity. \n");
    Console.WriteLine($"{description}\n");
    int sec = getTime();
    getReady();
    activity(sec);
    endOfActivity(sec, name);
    loadAnimation();
 }


    private void activity(int sec){
        int items = 0;
    
    
    string prompt = "why are you running";
       Console.WriteLine("List as many responses as you can to the following prompt: ");
       Console.WriteLine($"--- {prompt} ---");
       int i = 3;

       Console.Write($"You may begin in: ");
        while (i != 0) {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b"); 
            i--;
        }

        Console.WriteLine();
        
        DateTime endTime = getEndtime(sec);
        while (DateTime.Now < endTime){
            Console.Write("> ");
            Console.ReadLine();
            items ++;
        }
        Console.WriteLine($"You listed {items} items");
}
}