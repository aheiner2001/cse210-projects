
class Game
{
    protected int _team1score{ get; set; }
    protected int _team2score{ get; set; }
    protected string player1 { get; private set; }
    protected string player2 { get; private set; }
    public Game(string one, string two)
    {
        Console.Write("What was the score of team one: ");
        _team1score = int.Parse(Console.ReadLine());

        Console.Write("What was the score of team two: ");
        _team2score = int.Parse(Console.ReadLine());

        player1 = one;
        player2 = two;
    }

    public Game(string one, int score1, string two, int score2){

        player1 = one;
        player2 = two;
        _team1score = score1;
        _team2score = score2;

       
    }
  public int getScoreTeam1(){
        return _team1score;
    }
  public int getScoreTeam2(){
        return _team2score;
    }
    public override string ToString()
    {
        return $"{player1}({_team1score}) : {player2}({_team2score})";
    }

     public virtual void saveGame (string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            outputFile.WriteLine($"SinglesGame||{player1}||{_team1score}||{player2}||{_team2score}");
        }
    }
}