using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

/// <summary>
/// Service responsible for persisting and loading application state to and from flat files.
/// 
/// Demonstrates OOP Principles:
/// - Single Responsibility Principle (SRP): Isolates file I/O operations away from domain models.
/// - Robustness & Backward Compatibility: Tolerates missing fields, empty lines, and format variations (7-part legacy vs 9-part player records).
/// </summary>
public class StorageService
{
    private const string Delimiter = "||";

    /// <summary>
    /// Loads player profiles and match logs from the designated file.
    /// </summary>
    public (List<Player> players, List<Game> games) LoadFromFile(string filePath)
    {
        var loadedPlayers = new List<Player>();
        var loadedGames = new List<Game>();

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file '{filePath}' could not be found.");
        }

        string[] lines = File.ReadAllLines(filePath);
        int lineNumber = 0;

        foreach (string rawLine in lines)
        {
            lineNumber++;
            string line = rawLine.Trim();
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] parts = line.Split(Delimiter);
            if (parts.Length < 2)
            {
                continue;
            }

            string recordType = parts[0].Trim();

            switch (recordType)
            {
                case "Player":
                    if (TryParsePlayer(parts, out Player player))
                    {
                        loadedPlayers.Add(player);
                    }
                    else
                    {
                        Console.WriteLine($"[Warning] Skipping malformed player record at line {lineNumber}.");
                    }
                    break;

                case "SinglesGame":
                    if (TryParseSinglesGame(parts, out SinglesGame singlesGame))
                    {
                        loadedGames.Add(singlesGame);
                    }
                    else
                    {
                        Console.WriteLine($"[Warning] Skipping malformed singles record at line {lineNumber}.");
                    }
                    break;

                case "DoublesGame":
                    if (TryParseDoublesGame(parts, out DoublesGame doublesGame))
                    {
                        loadedGames.Add(doublesGame);
                    }
                    else
                    {
                        Console.WriteLine($"[Warning] Skipping malformed doubles record at line {lineNumber}.");
                    }
                    break;

                default:
                    Console.WriteLine($"[Warning] Unknown record type '{recordType}' at line {lineNumber}.");
                    break;
            }
        }

        return (loadedPlayers, loadedGames);
    }

    /// <summary>
    /// Saves players and match history to the specified file.
    /// </summary>
    public void SaveToFile(string filePath, IEnumerable<Player> players, IEnumerable<Game> games, bool overwrite)
    {
        using (var writer = new StreamWriter(filePath, append: !overwrite))
        {
            foreach (Player player in players)
            {
                writer.WriteLine(player.ToSerializedString());
            }

            foreach (Game game in games)
            {
                writer.WriteLine(game.ToSerializedString());
            }
        }
    }

    private bool TryParsePlayer(string[] parts, out Player player)
    {
        player = null;
        // Format: Player||name||age||experience||forehand||backhand||dropshot[||singlesWon||doublesWon]
        if (parts.Length < 7) return false;

        string name = parts[1];
        string age = parts[2];

        if (!decimal.TryParse(parts[3], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal experience))
            decimal.TryParse(parts[3], out experience);

        if (!decimal.TryParse(parts[4], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal forehand))
            decimal.TryParse(parts[4], out forehand);

        if (!decimal.TryParse(parts[5], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal backhand))
            decimal.TryParse(parts[5], out backhand);

        if (!decimal.TryParse(parts[6], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal dropshot))
            decimal.TryParse(parts[6], out dropshot);

        int singlesWon = 0;
        int doublesWon = 0;

        if (parts.Length >= 9)
        {
            int.TryParse(parts[7], out singlesWon);
            int.TryParse(parts[8], out doublesWon);
        }

        player = new Player(name, age, experience, forehand, backhand, dropshot, singlesWon, doublesWon);
        return true;
    }

    private bool TryParseSinglesGame(string[] parts, out SinglesGame game)
    {
        game = null;
        // Format: SinglesGame||player1||player1score||player2||player2score
        if (parts.Length < 5) return false;

        string p1 = parts[1];
        if (!int.TryParse(parts[2], out int score1)) return false;
        string p2 = parts[3];
        if (!int.TryParse(parts[4], out int score2)) return false;

        game = new SinglesGame(p1, score1, p2, score2);
        return true;
    }

    private bool TryParseDoublesGame(string[] parts, out DoublesGame game)
    {
        game = null;
        // Format: DoublesGame||player1||player2||score1||player3||player4||score2
        if (parts.Length < 7) return false;

        string t1p1 = parts[1];
        string t1p2 = parts[2];
        if (!int.TryParse(parts[3], out int score1)) return false;
        string t2p1 = parts[4];
        string t2p2 = parts[5];
        if (!int.TryParse(parts[6], out int score2)) return false;

        game = new DoublesGame(t1p1, t1p2, score1, t2p1, t2p2, score2);
        return true;
    }
}
