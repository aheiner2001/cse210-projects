class Tip{

    private int _requiredLevel;
    private string _tipName;

    private string _tipLink;
    public Tip(int level, string name, string link){
        _requiredLevel = level;
        _tipName = name;
        _tipLink = link;

    }

    public string getName(){
        string Name = _tipName;
        return Name;
    }
    public int getRequiredLevel(){
      return _requiredLevel;
    }
    public string getLink(){
 return _tipLink;
    }
    
}

// be able to unlock different videos when you reach a certain experience.