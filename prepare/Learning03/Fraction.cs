class Fraction{

    private int _top;
    private int _bottom;
    

//     Constructor that has no parameters that initializes the number to 1/1.

    public Fraction(){
        _top = 1;
        _bottom = 1;
    }
// Constructor that has one parameter for the top and that initializes the denominator to 1. So that if you pass in the number 5, the fraction would be initialized to 5/1.
    public Fraction(int wholenumber){
        _top = wholenumber;
        _bottom = 1;
    }
// Constructor that has two parameters, one for the top and one for the bottom.
    public  Fraction(int top, int bottom){
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString(){
        string fraction = $"{_top}/{_bottom}";
        return fraction;
    }
    public double GetDecimalValue(){
        return (double)_top/ (double)_bottom;
    }
}
