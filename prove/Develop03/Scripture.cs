using System.Dynamic;
using System.Collections.Generic;
class Scripture{
    

    private Word[] _words;
   
    private bool _allWordsHidden;

    public bool AllWordsHidden { get { return _allWordsHidden; } }



     





     public Scripture(string[] words)
    {
        _words = new Word[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            _words[i] = new Word(words[i]);
        }
       
    }

  




public void HideRandomWords()
{
    Random random = new Random();
    int wordsToHide = 3;
    int visibleWordCount = _words.Count(word => !word.IsHidden); 
    int i = 0;
    while (i < wordsToHide && visibleWordCount > 0)
    {
        int index = random.Next(_words.Length);
        if (!_words[index].IsHidden)
        {
            _words[index].Hide();
            i++;
            visibleWordCount--; 
        }
    }
}

    public bool WordsHidden(){
        _allWordsHidden = true;
        foreach (Word word in _words){

            if (!word.IsHidden){
                _allWordsHidden = false;
                return false;
            
            }
        }
        _allWordsHidden = true;
        return true;
        
    

    }






   public string GetRenderedText()
    {
        string renderedText = "";
        foreach (Word word in _words)
        {
            renderedText += word.GetRenderedText() + " ";
        }
        return renderedText;
    }
   

    
 
}