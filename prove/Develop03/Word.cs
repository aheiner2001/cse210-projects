class Word {

    private string _word;

    private bool _isHidden;


  
    public bool IsHidden { get { return _isHidden; } }

   
    public Word(string word){
        _word = word;
        _isHidden = false;
        
    }


    
    // 
    public void Hide()
    {
        
        _isHidden = true;
        
    }
    // 



    public string GetRenderedText()
    {   string blanks = "";
        int length = _word.Length;
        if(_isHidden) {
            for (int i = 0; i < length; i++){
                blanks += "_";
            }
            return blanks;
        }
        else{
            return _word;
        }
    }
    
}
