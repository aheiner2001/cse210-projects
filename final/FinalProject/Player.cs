using System.Runtime.InteropServices.Marshalling;

class Player{
    private string _name;
    private string _age;

    private decimal _experience;
         private ForehandShot forhand ;
        private BackhandShot backhand;
       private  DropShot dropshot;
       private static List<Shot> shots;
       

    


    public Player(){
        Console.Write("Name: ");
        _name = Console.ReadLine();

        Console.Write("Age: ");
        _age = Console.ReadLine();

        _experience = 0;
       forhand =  new ForehandShot();
       
       backhand =  new BackhandShot();
        dropshot = new DropShot();
        
        shots = new List<Shot>();
        shots.Add(forhand);
        shots.Add(backhand);
        shots.Add(dropshot);

   

       
    }
    public Player(string name, string age, int experience){
        Console.Write("Name: ");
        _name = name;

        _age = age;

        _experience = experience;
       
    }
    public string displayInfo(){
      return $"{_name} \n   Age: {_age} \n   Experience: {_experience}\n";

    }
    public string getName(){
        return _name;
    }
    public string getAge(){
        return _age;
    }
    public decimal getExperience(){
        return _experience;
    }
    public void setExperience(decimal num){
        _experience += num * .050m;

    }
    
    public List<Shot> getShots(){
        return shots;
    }
    public void savePlayer(string filename){
      using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            outputFile.WriteLine($"Player||{_name}||{_age}||{_experience}||{forhand.getShotLevel()}||{backhand.getShotLevel()}||{dropshot.getShotLevel()}");
        }
    }
}
    
