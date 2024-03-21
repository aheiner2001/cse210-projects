using System.Runtime.InteropServices.Marshalling;

class Player{
    private string _name;
    private string _age;

    private int _experience;



    public Player(){
        Console.Write("Name: ");
        _name = Console.ReadLine();

        Console.Write("Age: ");
        _age = Console.ReadLine();

        _experience = 0;

        ForhandShot forhand  = new ForhandShot();
        BackhandShot backhand  = new BackhandShot();
        DropShot dropshot  = new DropShot();

       
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
    public int getExperience(){
        return _experience;
    }
}
    
