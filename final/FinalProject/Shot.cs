class Shot{
    private decimal _shotLevel;
    private string _shotName;
    


    public Shot(string name){
        _shotLevel = 0;
        _shotName = name;

    }

public decimal getShotLevel(){
    return _shotLevel;

}


public void upDateShotLevel(decimal num){
    _shotLevel += num * .025m;
    }
public string getName(){
    return _shotName;
}
}


