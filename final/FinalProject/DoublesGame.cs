class DoublesGame : Game
{
    private string player3;
    private string player4;

    public DoublesGame(string one, string two, string three, string four) : base(one, two)
    {
        player3 = three;
        player4 = four;
    }

    public override string ToString()
    {
        return $"{player1} and {player2}({_team1score}) : {player3} and {player4}({_team2score})";
    }

     public override void saveGame (string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            outputFile.WriteLine($"DoublesGame||{player1}||{player2}||{_team1score}||{player3}||{player4}||{_team2score}");
        }
    }
}