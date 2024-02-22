class ReflectingActivity: Activity
{
    private string name = "Reflecting";
    private string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use in other aspects of your life.";

    public void runactivity(){
    Console.WriteLine($"\nWelcome to the {name} activity. \n");
    Console.WriteLine($"{description}\n");
    int sec = getTime();
    getReady();
    DateTime endTime = getEndtime(sec);
    activity(endTime);
    endOfActivity(sec, name);
    loadAnimation();
 }


    private void activity(DateTime endTime){
       Console.WriteLine("Refleect");
    }
}