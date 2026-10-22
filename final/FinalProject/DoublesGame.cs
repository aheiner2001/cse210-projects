using System;
using System.Collections.Generic;

/// <summary>
/// Represents a 2-on-2 Doubles pickleball match.
/// Demonstrates OOP Principle: Inheritance & Polymorphism.
/// </summary>
public class DoublesGame : Game
{
    private readonly string _team1Player1;
    private readonly string _team1Player2;
    private readonly string _team2Player1;
    private readonly string _team2Player2;

    public DoublesGame(
        string team1Player1, 
        string team1Player2, 
        int team1Score, 
        string team2Player1, 
        string team2Player2, 
        int team2Score)
        : base("Doubles", team1Score, team2Score)
    {
        _team1Player1 = team1Player1;
        _team1Player2 = team1Player2;
        _team2Player1 = team2Player1;
        _team2Player2 = team2Player2;
    }

    public string Team1Player1 => _team1Player1;
    public string Team1Player2 => _team1Player2;
    public string Team2Player1 => _team2Player1;
    public string Team2Player2 => _team2Player2;

    public override IReadOnlyList<string> GetTeam1Players() => new[] { _team1Player1, _team1Player2 };
    public override IReadOnlyList<string> GetTeam2Players() => new[] { _team2Player1, _team2Player2 };

    public override string ToString()
    {
        return $"[Doubles] {_team1Player1} & {_team1Player2} ({_team1Score}) vs {_team2Player1} & {_team2Player2} ({_team2Score})";
    }

    public override string ToSerializedString()
    {
        return $"DoublesGame||{_team1Player1}||{_team1Player2}||{_team1Score}||{_team2Player1}||{_team2Player2}||{_team2Score}";
    }
}
