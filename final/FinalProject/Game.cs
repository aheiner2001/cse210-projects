using System;
using System.Collections.Generic;

/// <summary>
/// Abstract base class for a recorded pickleball match.
/// Demonstrates OOP Principles:
/// - Abstraction: Models high-level match state (team scores, outcome calculation, string serialization).
/// - Polymorphism: Derived classes (SinglesGame, DoublesGame) provide their specific participant structure and serialization.
/// </summary>
public abstract class Game
{
    private readonly string _gameType;
    protected int _team1Score;
    protected int _team2Score;

    protected Game(string gameType, int team1Score, int team2Score)
    {
        _gameType = gameType;
        _team1Score = Math.Max(0, team1Score);
        _team2Score = Math.Max(0, team2Score);
    }

    public string GameType => _gameType;
    public int Team1Score => _team1Score;
    public int Team2Score => _team2Score;

    // Backward compatibility getters
    public int getScoreTeam1() => _team1Score;
    public int getScoreTeam2() => _team2Score;
    public string getName() => _gameType;

    /// <summary>
    /// Returns 1 if Team 1 won, 2 if Team 2 won, or 0 if a tie.
    /// </summary>
    public int GetWinner()
    {
        if (_team1Score > _team2Score) return 1;
        if (_team2Score > _team1Score) return 2;
        return 0; // Tie
    }

    /// <summary>
    /// Returns the roster of player names on Team 1.
    /// </summary>
    public abstract IReadOnlyList<string> GetTeam1Players();

    /// <summary>
    /// Returns the roster of player names on Team 2.
    /// </summary>
    public abstract IReadOnlyList<string> GetTeam2Players();

    /// <summary>
    /// Formats the game into a serialized string for storage.
    /// </summary>
    public abstract string ToSerializedString();
}
