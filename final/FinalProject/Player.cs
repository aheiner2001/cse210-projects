using System.Runtime.InteropServices.Marshalling;

class Player
{
    private string _name;
    private string _age;
    private decimal _experience;
    private ForehandShot forhand;
    private BackhandShot backhand;
    private DropShot dropshot;
    private static List<Shot> shots;

    private int _singlesWon;
    private int _doublesWon;
   

    public Player()
    {
        Console.Write("Name: ");
        _name = Console.ReadLine();

        Console.Write("Age: ");
        _age = Console.ReadLine();

        _experience = 0;
        forhand = new ForehandShot();
        backhand = new BackhandShot();
        dropshot = new DropShot();
        
        shots = new List<Shot>();
        _singlesWon = 0;
        _doublesWon = 0;
        shots.Add(forhand);
        shots.Add(backhand);
        shots.Add(dropshot);

      
    }

    public void SinglesWon(){
        _singlesWon+=1;
    }
    public void DoublessWon(){
        _singlesWon+=1;
    }
    

public int getGamesWonSingles(){
    return _singlesWon;
}
public int getGamesWonDoubles(){
    return _doublesWon;
 
}

    public Player(string name, string age, decimal experience, decimal fore, decimal back, decimal drop, int singlessWon, int doublesWon)
    {
        _name = name;
        _age = age;
        _experience = experience;
        forhand = new ForehandShot(fore);
        backhand = new BackhandShot(back);
        dropshot = new DropShot(drop);
        shots = new List<Shot>();
        _singlesWon = singlessWon;
        _doublesWon = doublesWon;
        
        shots.Add(forhand);
        shots.Add(backhand);
        shots.Add(dropshot);

    }

    public string displayInfo()
    {
        return $"{_name} \n   Age: {_age} \n   Experience: {_experience}\n";
    }
    

    public string getName()
    {
        return _name;
    }

    public string getAge()
    {
        return _age;
    }

    public decimal getExperience()
    {
        return _experience;
    }

    public void setExperience(decimal num)
    {
        _experience += num * 0.050m;
    }

    public List<Shot> getShots()
    {
        return shots;
    }

    public void savePlayer(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            outputFile.WriteLine($"Player||{_name}||{_age}||{_experience}||{forhand.getShotLevel()}||{backhand.getShotLevel()}||{dropshot.getShotLevel()}||{_singlesWon}||{_doublesWon}");
        }
    }
}
