using System;
using System.Collections.Generic;

/// <summary>
/// Represents a pickleball player, tracking their profile, shot proficiencies, 
/// accumulated experience level, and game win history.
/// 
/// Demonstrates OOP Principles:
/// - Encapsulation: Protects player state (experience, win counts, shot list) with controlled methods and validation.
/// - Composition: A Player "has-a" collection of specialized Shots (Forehand, Backhand, DropShot).
/// - Bug Fix: Removed static keyword from the shot list so each player possesses independent shot skill levels.
/// - Bug Fix: Corrected DoublessWon() to increment doubles win count instead of singles.
/// </summary>
public class Player
{
    private string _name;
    private string _age;
    private decimal _experience;
    private int _singlesWon;
    private int _doublesWon;

    // Instance collection of shots (previously declared static, which caused all players to share identical shots)
    private readonly List<Shot> _shots;
    private readonly ForehandShot _forehand;
    private readonly BackhandShot _backhand;
    private readonly DropShot _dropShot;

    /// <summary>
    /// Constructs a brand new player profile with base level shots (0.0).
    /// </summary>
    public Player(string name, string age)
        : this(name, age, 0m, 0m, 0m, 0m, 0, 0)
    {
    }

    /// <summary>
    /// Constructs a player with specified statistics (used when loading saved data).
    /// </summary>
    public Player(
        string name, 
        string age, 
        decimal experience, 
        decimal forehandLevel, 
        decimal backhandLevel, 
        decimal dropShotLevel, 
        int singlesWon, 
        int doublesWon)
    {
        _name = string.IsNullOrWhiteSpace(name) ? "Unknown Player" : name.Trim();
        _age = string.IsNullOrWhiteSpace(age) ? "N/A" : age.Trim();
        _experience = Math.Max(0m, experience);
        _singlesWon = Math.Max(0, singlesWon);
        _doublesWon = Math.Max(0, doublesWon);

        _forehand = new ForehandShot(forehandLevel);
        _backhand = new BackhandShot(backhandLevel);
        _dropShot = new DropShot(dropShotLevel);

        _shots = new List<Shot> { _forehand, _backhand, _dropShot };
    }

    // Properties
    public string Name => _name;
    public string Age => _age;
    public decimal Experience => _experience;
    public int SinglesWonCount => _singlesWon;
    public int DoublesWonCount => _doublesWon;
    public IReadOnlyList<Shot> Shots => _shots;
    public ForehandShot Forehand => _forehand;
    public BackhandShot Backhand => _backhand;
    public DropShot DropShot => _dropShot;

    // Backward-compatible getters
    public string getName() => _name;
    public string getAge() => _age;
    public decimal getExperience() => _experience;
    public int getGamesWonSingles() => _singlesWon;
    public int getGamesWonDoubles() => _doublesWon;
    public List<Shot> getShots() => _shots;

    /// <summary>
    /// Increments the count of singles games won.
    /// </summary>
    public void RecordSinglesWin()
    {
        _singlesWon++;
    }

    // Backward-compatible method
    public void SinglesWon() => RecordSinglesWin();

    /// <summary>
    /// Increments the count of doubles games won.
    /// Bug Fix: Previously incremented _singlesWon. Now correctly increments _doublesWon.
    /// </summary>
    public void RecordDoublesWin()
    {
        _doublesWon++;
    }

    // Backward-compatible method
    public void DoublessWon() => RecordDoublesWin();

    /// <summary>
    /// Modifies the player's overall experience level.
    /// Prevents experience from ever dropping below 0.0.
    /// Formula: adjusts by points * 0.050m (matching original scale).
    /// </summary>
    public void AddExperience(decimal points)
    {
        _experience += points * 0.050m;
        if (_experience < 0m)
        {
            _experience = 0m;
        }
    }

    // Backward-compatible method
    public void setExperience(decimal num) => AddExperience(num);

    /// <summary>
    /// Returns a multi-line formatted summary of the player's profile and progress.
    /// </summary>
    public string DisplayInfo()
    {
        return $"Player: {_name}\n" +
               $"   Age: {_age}\n" +
               $"   Level (Experience): {_experience:F2}\n" +
               $"   Record: {_singlesWon} Singles Win(s), {_doublesWon} Doubles Win(s)";
    }

    public string displayInfo() => DisplayInfo();

    /// <summary>
    /// Formats the player record into the delimiter-separated representation for saving to file.
    /// Format: Player||Name||Age||Exp||Forehand||Backhand||DropShot||SinglesWon||DoublesWon
    /// </summary>
    public string ToSerializedString()
    {
        return $"Player||{_name}||{_age}||{_experience}||{_forehand.Level}||{_backhand.Level}||{_dropShot.Level}||{_singlesWon}||{_doublesWon}";
    }

    public override string ToString() => $"{_name} (Level: {_experience:F2})";
}
