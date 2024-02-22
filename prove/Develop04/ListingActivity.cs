class ListingActivity: Activity
{
   private string name = "Listing";
    private string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

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
      Console.WriteLine("listing");
    }
}