using System;
using System.Collections.Generic;

/// <summary>
/// Represents a 1-on-1 Singles pickleball match.
/// Demonstrates OOP Principle: Inheritance & Polymorphism.
/// </summary>
public class SinglesGame : Game
{
    private readonly string _player1;
    private readonly string _player2;

    public SinglesGame(string player1, int player1Score, string player2, int player2Score)
        : base("Singles", player1Score, player2Score)
    {
        _player1 = player1;
        _player2 = player2;
    }

    public string Player1 => _player1;
    public string Player2 => _player2;

    public override IReadOnlyList<string> GetTeam1Players() => new[] { _player1 };
    public override IReadOnlyList<string> GetTeam2Players() => new[] { _player2 };

    public override string ToString()
    {
        return $"[Singles] {_player1} ({_team1Score}) vs {_player2} ({_team2Score})";
    }

    public override string ToSerializedString()
    {
        return $"SinglesGame||{_player1}||{_team1Score}||{_player2}||{_team2Score}";
    }
}
