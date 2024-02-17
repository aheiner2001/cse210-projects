using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;



// complete
class Reference{
    private string _book;
    private string _chapter;
    private string _verse;
    private string _end_verse;
    private string _ref;

    public Reference(string text)
    {
        string[] parts = text.Split("|");
        if (parts.Length > 3){
        _book = parts[0];
        _chapter = parts[1];
        _verse = parts[2];
        _end_verse = parts[3];
        }
        else{
            _book = parts[0];
            _chapter = parts[1];
            _verse = parts[2];
        }

       
    }
    public string toString() {
        if (_end_verse == "") {
            _ref = $"{_book} {_chapter}:{_verse}-{_end_verse} ";
        }
        else {
            _ref = $"{_book} {_chapter}:{_verse} ";
        }
        return _ref;
        } 
    }

    



