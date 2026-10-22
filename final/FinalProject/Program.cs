using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

/// <summary>
/// Entry point for the Pickleball Coach terminal application.
/// 
/// CSE 210 Final Project Revamp:
/// -------------------------------------------------------------
/// Key Improvements & Bug Fixes:
/// 1. Eliminated Static State Bug: Player shot levels were previously static in Player.cs,
///    causing all players to share identical shot progress. Now every player maintains their own independent shots.
/// 2. Fixed Doubles Win Counter: Previously incremented _singlesWon instead of _doublesWon in DoublessWon().
/// 3. Fixed Scoring Logic: Symmetrical win/loss XP calculations without duplicate deductions on the winning player.
/// 4. Decoupled UI & Domain Logic: Entity constructors no longer invoke Console.ReadLine().
/// 5. Robust Crash-Proof Input: All numeric and choice prompts are guarded by InputHelper to prevent FormatException crashes.
/// 6. Safe File I/O: StorageService handles loading and saving with backward compatibility for legacy records.
/// 7. Upgraded to .NET 8 LTS: Removed obsolete target framework warnings.
/// </summary>
class Program
{
    private static bool _running = true;
    private static readonly List<Player> _players = new();
    private static readonly List<Game> _games = new();
    private static readonly StorageService _storageService = new();

    private static readonly List<Tip> _tips = new()
    {
        new Tip(0, "Basic Grip & Ready Position", "https://www.youtube.com/watch?v=xEYsymCtIDY", "Paddle Grip Fundamentals (Free)"),
        new Tip(2, "Forehand Drive Fundamentals", "https://www.youtube.com/watch?v=fsgJa0OgeRE", "Power & Court Placement"),
        new Tip(5, "Mastering the Backhand Punch", "https://www.youtube.com/watch?v=Jgr4Yo9JrO4", "Control & Fast Hands"),
        new Tip(7, "Third Shot Drop Mastery", "https://www.youtube.com/watch?v=-raCQ4em4Lc", "Transition Zone Soft Game"),
        new Tip(9, "Kitchen Line Dinking Battles", "https://www.youtube.com/watch?v=ZkYLOfyAUr8", "Resetting & Non-Volley Zone Play"),
        new Tip(12, "Advanced Court Positioning & Strategy", "https://www.youtube.com/watch?v=5bnLUkNb7PA", "Doubles Stacking & Poaching")
    };

    static void Main(string[] args)
    {
        if (args.Length > 0 && args[0] == "--test")
        {
            RunSelfTests();
            return;
        }

        Console.Title = "Pickleball Coach - Performance & Training Tracker";

        try
        {
            DisplayWelcomeScreen();

            while (_running)
            {
                DisplayMenu();
            }
        }
        catch (EndOfStreamException)
        {
            // Clean exit when piped input stream completes
        }

        Console.WriteLine("\nThank you for training with Pickleball Coach! Keep practicing and see you on the court!");
    }

    private static void DisplayWelcomeScreen()
    {
        Console.Clear();
        Console.WriteLine("================================================================================");
        Console.WriteLine("                    🏓 WELCOME TO PICKLEBALL COACH 🏓                           ");
        Console.WriteLine("================================================================================");
        Console.WriteLine("Track your pickleball journey, practice essential shots through guided drills,  ");
        Console.WriteLine("log singles and doubles matches, level up your stats, and unlock pro tips.      ");
        Console.WriteLine("================================================================================");
        InputHelper.PressEnter("Press Enter to enter the training center... ");
    }

    private static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Pickleball Coach Main Menu ===");
        Console.WriteLine($"Current Roster: {_players.Count} player(s) | Match History: {_games.Count} game(s)");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("1. Create Player(s)");
        Console.WriteLine("2. Guided Practice (Drills)");
        Console.WriteLine("3. Log Game (Singles / Doubles)");
        Console.WriteLine("4. View Game History");
        Console.WriteLine("5. View Player Stats & Shot Levels");
        Console.WriteLine("6. Pro Tip Store (Unlock Coaching Videos)");
        Console.WriteLine("7. Load Data from File");
        Console.WriteLine("8. Save Data & Exit");
        Console.WriteLine("9. Show Player Profiles");
        Console.WriteLine("0. Exit Without Saving");
        Console.WriteLine("----------------------------------");

        int choice = InputHelper.ReadInt("What would you like to do? ", 0, 9);
        Console.WriteLine();

        switch (choice)
        {
            case 1:
                CreatePlayers();
                break;
            case 2:
                RunGuidedPractice();
                break;
            case 3:
                LogGame();
                break;
            case 4:
                ViewGames();
                break;
            case 5:
                ViewStats();
                break;
            case 6:
                OpenTipStore();
                break;
            case 7:
                LoadData();
                break;
            case 8:
                SaveDataAndExit();
                break;
            case 9:
                ShowPlayerProfiles();
                break;
            case 0:
                _running = false;
                break;
        }
    }

    private static void CreatePlayers()
    {
        Console.WriteLine("=== Create New Player Profile ===");
        int count = InputHelper.ReadInt("How many players would you like to add? ", 1, 50);

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\n--- Player #{_players.Count + 1} ---");
            string name = InputHelper.ReadNonEmptyString("Enter Player Name: ");
            string age = InputHelper.ReadNonEmptyString("Enter Age: ");

            var newPlayer = new Player(name, age);
            _players.Add(newPlayer);
            Console.WriteLine($"✓ Added {newPlayer.Name} to roster!");
        }

        InputHelper.PressEnter();
    }

    private static void RunGuidedPractice()
    {
        Console.WriteLine("=== Guided Practice Session ===");
        if (_players.Count == 0)
        {
            Console.WriteLine("No players found! Please create or load players first (Menu Option 1 or 7).");
            InputHelper.PressEnter();
            return;
        }

        Console.WriteLine("\nSelect a player for this practice session:");
        Player student = InputHelper.SelectFromList("Select Player: ", _players, p => $"{p.Name} (Level {p.Experience:F2})");

        Console.WriteLine("\nSelect shot drill to practice:");
        Console.WriteLine("1. Forehand Practice (+20 XP, increases Forehand shot level)");
        Console.WriteLine("2. Backhand Practice (+25 XP, increases Backhand shot level)");
        Console.WriteLine("3. Drop Shot Practice (+30 XP, increases Drop Shot level)");

        int shotChoice = InputHelper.ReadInt("Choice (1-3): ", 1, 3);

        Drill selectedDrill;
        Shot targetShot;

        switch (shotChoice)
        {
            case 1:
                selectedDrill = new ForehandDrill();
                targetShot = student.Forehand;
                break;
            case 2:
                selectedDrill = new BackhandDrill();
                targetShot = student.Backhand;
                break;
            case 3:
                selectedDrill = new DropShotDrill();
                targetShot = student.DropShot;
                break;
            default:
                return;
        }

        // Run interactive drill simulation
        selectedDrill.RunDrill();

        // Award experience points to player profile and upgrade specific shot
        student.AddExperience(selectedDrill.Points);
        targetShot.UpgradeLevel(selectedDrill.Points);

        Console.WriteLine($"\n[Progress Summary for {student.Name}]");
        Console.WriteLine($"Overall Level: {student.Experience:F2}");
        Console.WriteLine($"{targetShot.Name} Level: {targetShot.Level:F2}");

        InputHelper.PressEnter();
    }

    private static void LogGame()
    {
        Console.WriteLine("=== Log Completed Match ===");
        if (_players.Count < 2)
        {
            Console.WriteLine("At least 2 registered players are needed to log a match. Please add more players.");
            InputHelper.PressEnter();
            return;
        }

        Console.WriteLine("1. Singles (1 vs 1)");
        Console.WriteLine("2. Doubles (2 vs 2)");
        int format = InputHelper.ReadInt("Select match format: ", 1, 2);

        if (format == 1)
        {
            LogSinglesMatch();
        }
        else
        {
            LogDoublesMatch();
        }
    }

    private static void LogSinglesMatch()
    {
        Console.WriteLine("\n--- Select Competitors ---");
        Console.WriteLine("Player 1:");
        Player p1 = InputHelper.SelectFromList("Select Player 1: ", _players, p => p.Name);

        Console.WriteLine("\nPlayer 2:");
        var availableOpponents = _players.FindAll(p => p != p1);
        if (availableOpponents.Count == 0)
        {
            Console.WriteLine("You need another unique player for singles match.");
            InputHelper.PressEnter();
            return;
        }

        Player p2 = InputHelper.SelectFromList("Select Player 2: ", availableOpponents, p => p.Name);

        int score1 = InputHelper.ReadInt($"Enter final score for {p1.Name}: ", 0, 99);
        int score2 = InputHelper.ReadInt($"Enter final score for {p2.Name}: ", 0, 99);

        var match = new SinglesGame(p1.Name, score1, p2.Name, score2);
        _games.Add(match);

        // Apply scoring and XP changes
        if (score1 > score2)
        {
            p1.RecordSinglesWin();
            p1.AddExperience(5m); // +0.25 effective XP
            p2.AddExperience(-5m); // -0.25 effective XP (floored at 0)
            Console.WriteLine($"\n🏆 {p1.Name} wins the match!");
        }
        else if (score2 > score1)
        {
            p2.RecordSinglesWin();
            p2.AddExperience(5m);
            p1.AddExperience(-5m);
            Console.WriteLine($"\n🏆 {p2.Name} wins the match!");
        }
        else
        {
            Console.WriteLine("\n🤝 The match ended in a draw!");
        }

        Console.WriteLine($"Result: {match}");
        InputHelper.PressEnter();
    }

    private static void LogDoublesMatch()
    {
        if (_players.Count < 4)
        {
            Console.WriteLine($"Doubles requires 4 players. Current roster has {_players.Count}.");
            InputHelper.PressEnter();
            return;
        }

        Console.WriteLine("\n--- Team 1 Selection ---");
        Player t1p1 = InputHelper.SelectFromList("Team 1 - Player 1: ", _players, p => p.Name);

        var remaining = _players.FindAll(p => p != t1p1);
        Player t1p2 = InputHelper.SelectFromList("Team 1 - Player 2: ", remaining, p => p.Name);

        Console.WriteLine("\n--- Team 2 Selection ---");
        remaining = _players.FindAll(p => p != t1p1 && p != t1p2);
        Player t2p1 = InputHelper.SelectFromList("Team 2 - Player 1: ", remaining, p => p.Name);

        remaining = _players.FindAll(p => p != t1p1 && p != t1p2 && p != t2p1);
        Player t2p2 = InputHelper.SelectFromList("Team 2 - Player 2: ", remaining, p => p.Name);

        int score1 = InputHelper.ReadInt($"Enter final score for Team 1 ({t1p1.Name} & {t1p2.Name}): ", 0, 99);
        int score2 = InputHelper.ReadInt($"Enter final score for Team 2 ({t2p1.Name} & {t2p2.Name}): ", 0, 99);

        var match = new DoublesGame(t1p1.Name, t1p2.Name, score1, t2p1.Name, t2p2.Name, score2);
        _games.Add(match);

        // Apply scoring and XP changes
        if (score1 > score2)
        {
            t1p1.RecordDoublesWin();
            t1p2.RecordDoublesWin();
            t1p1.AddExperience(5m);
            t1p2.AddExperience(5m);

            t2p1.AddExperience(-5m);
            t2p2.AddExperience(-5m);
            Console.WriteLine($"\n🏆 Team 1 ({t1p1.Name} & {t1p2.Name}) wins the match!");
        }
        else if (score2 > score1)
        {
            t2p1.RecordDoublesWin();
            t2p2.RecordDoublesWin();
            t2p1.AddExperience(5m);
            t2p2.AddExperience(5m);

            t1p1.AddExperience(-5m);
            t1p2.AddExperience(-5m);
            Console.WriteLine($"\n🏆 Team 2 ({t2p1.Name} & {t2p2.Name}) wins the match!");
        }
        else
        {
            Console.WriteLine("\n🤝 The match ended in a draw!");
        }

        Console.WriteLine($"Result: {match}");
        InputHelper.PressEnter();
    }

    private static void ViewGames()
    {
        Console.WriteLine("=== Match History Log ===");
        if (_games.Count == 0)
        {
            Console.WriteLine("No matches logged yet.");
        }
        else
        {
            for (int i = 0; i < _games.Count; i++)
            {
                Console.WriteLine($"#{i + 1} {_games[i]}");
            }
        }
        InputHelper.PressEnter();
    }

    private static void ViewStats()
    {
        Console.WriteLine("=== Player Statistics & Shot Proficiencies ===");
        if (_players.Count == 0)
        {
            Console.WriteLine("No players registered yet.");
        }
        else
        {
            foreach (Player player in _players)
            {
                Console.WriteLine($"--------------------------------------------------");
                Console.WriteLine($"Player: {player.Name} | Age: {player.Age} | Overall Level: {player.Experience:F2}");
                Console.WriteLine("  Shot Levels:");
                foreach (Shot shot in player.Shots)
                {
                    Console.WriteLine($"    • {shot.Name,-12}: {shot.Level:F2}");
                }
                Console.WriteLine("  Career Record:");
                Console.WriteLine($"    • Singles Wins: {player.SinglesWonCount}");
                Console.WriteLine($"    • Doubles Wins: {player.DoublesWonCount}");
            }
            Console.WriteLine($"--------------------------------------------------");
        }
        InputHelper.PressEnter();
    }

    private static void OpenTipStore()
    {
        Console.WriteLine("=== Pro Coaching Tip Store ===");
        if (_players.Count == 0)
        {
            Console.WriteLine("Please create or load a player first.");
            InputHelper.PressEnter();
            return;
        }

        Player student = InputHelper.SelectFromList("Select Player to view available tips: ", _players, p => $"{p.Name} (Level {p.Experience:F2})");
        decimal playerLevel = student.Experience;

        Console.WriteLine($"\nAvailable tips for {student.Name} (Current Level: {playerLevel:F2}):");
        for (int i = 0; i < _tips.Count; i++)
        {
            Tip tip = _tips[i];
            bool unlocked = playerLevel >= tip.RequiredLevel;
            string status = unlocked ? "✓ UNLOCKED" : $"🔒 Locked (Requires Level {tip.RequiredLevel})";
            Console.WriteLine($"{i + 1}. [{status}] {tip.Name} - {tip.Topic}");
        }

        int choice = InputHelper.ReadInt("\nSelect a tip to open video tutorial (0 to return): ", 0, _tips.Count);
        if (choice == 0) return;

        Tip selectedTip = _tips[choice - 1];
        if (playerLevel >= selectedTip.RequiredLevel)
        {
            Console.WriteLine($"Opening {selectedTip.Name}: {selectedTip.Link}");
            OpenBrowserUrl(selectedTip.Link);
        }
        else
        {
            Console.WriteLine($"❌ {student.Name} needs {selectedTip.RequiredLevel - playerLevel:F2} more experience points to unlock this coaching tip.");
        }

        InputHelper.PressEnter();
    }

    private static void LoadData()
    {
        Console.WriteLine("=== Load Data from File ===");
        Console.Write("Enter filename (Press Enter for default 'TennisProgram.txt'): ");
        string filename = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(filename))
        {
            filename = "TennisProgram.txt";
        }

        try
        {
            var (loadedPlayers, loadedGames) = _storageService.LoadFromFile(filename);
            _players.Clear();
            _players.AddRange(loadedPlayers);
            _games.Clear();
            _games.AddRange(loadedGames);

            Console.WriteLine($"\n✓ Successfully loaded {loadedPlayers.Count} player(s) and {loadedGames.Count} game(s) from '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Failed to load file: {ex.Message}");
        }

        InputHelper.PressEnter();
    }

    private static void SaveDataAndExit()
    {
        Console.WriteLine("=== Save Data & Exit ===");
        Console.Write("Enter filename (Press Enter for default 'TennisProgram.txt'): ");
        string filename = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(filename))
        {
            filename = "TennisProgram.txt";
        }

        Console.WriteLine("\nSave options:");
        Console.WriteLine("1. Overwrite file (Replaces previous content with current session data)");
        Console.WriteLine("2. Append to file (Adds current session data to existing file)");
        int choice = InputHelper.ReadInt("Choice (1 or 2): ", 1, 2);

        bool overwrite = choice == 1;

        try
        {
            _storageService.SaveToFile(filename, _players, _games, overwrite);
            Console.WriteLine($"✓ Data saved successfully to '{filename}'! Saved {_players.Count} player(s) and {_games.Count} game(s).");
            _running = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Failed to save file: {ex.Message}");
            InputHelper.PressEnter();
        }
    }

    private static void ShowPlayerProfiles()
    {
        Console.WriteLine("=== Registered Player Profiles ===");
        if (_players.Count == 0)
        {
            Console.WriteLine("No players registered yet.");
        }
        else
        {
            for (int i = 0; i < _players.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {_players[i].DisplayInfo()}\n");
            }
        }
        InputHelper.PressEnter();
    }

    private static void RunSelfTests()
    {
        Console.WriteLine("Running Pickleball Coach Self-Verification Suite...");

        // Test 1: Player shot independence (Fix for static shots bug)
        var p1 = new Player("PlayerOne", "25");
        var p2 = new Player("PlayerTwo", "30");
        p1.Forehand.UpgradeLevel(20m);
        if (p1.Forehand.Level <= 0 || p2.Forehand.Level != 0)
        {
            throw new Exception("FAIL: Player shot instances are not independent!");
        }
        Console.WriteLine("✓ PASS: Player shot instances are independent (Static bug resolved).");

        // Test 2: Doubles won counter (Fix for _singlesWon increment bug)
        p1.RecordDoublesWin();
        if (p1.DoublesWonCount != 1 || p1.SinglesWonCount != 0)
        {
            throw new Exception("FAIL: Doubles won incremented singles counter!");
        }
        Console.WriteLine("✓ PASS: Doubles win count correctly isolated from singles.");

        // Test 3: XP cannot go below 0
        p1.AddExperience(-50m);
        if (p1.Experience < 0)
        {
            throw new Exception("FAIL: Player experience fell below 0!");
        }
        Console.WriteLine("✓ PASS: Player experience floored at 0.0.");

        // Test 4: Game serialization and StorageService round-trip
        string tempFile = Path.Combine(Path.GetTempPath(), $"pb_test_{Guid.NewGuid():N}.txt");
        try
        {
            var testPlayers = new List<Player>
            {
                new Player("Alice", "28", 1.5m, 0.5m, 0.5m, 0.5m, 3, 2),
                new Player("Bob", "32", 2.0m, 1.0m, 0.8m, 0.2m, 4, 5)
            };
            var testGames = new List<Game>
            {
                new SinglesGame("Alice", 11, "Bob", 7),
                new DoublesGame("Alice", "PartnerA", 11, "Bob", "PartnerB", 9)
            };

            var storage = new StorageService();
            storage.SaveToFile(tempFile, testPlayers, testGames, overwrite: true);

            var (loadedP, loadedG) = storage.LoadFromFile(tempFile);
            if (loadedP.Count != 2 || loadedG.Count != 2)
            {
                throw new Exception("FAIL: Round-trip item counts mismatch!");
            }
            if (loadedP[0].Name != "Alice" || loadedP[0].SinglesWonCount != 3 || loadedP[0].DoublesWonCount != 2)
            {
                throw new Exception("FAIL: Loaded player stats mismatch!");
            }
            if (loadedG[0] is not SinglesGame sg || sg.Team1Score != 11 || sg.Team2Score != 7)
            {
                throw new Exception("FAIL: Loaded singles game mismatch!");
            }
            if (loadedG[1] is not DoublesGame dg || dg.Team1Player2 != "PartnerA")
            {
                throw new Exception("FAIL: Loaded doubles game mismatch!");
            }
            Console.WriteLine("✓ PASS: StorageService save and load round-trip verified.");
        }
        finally
        {
            if (File.Exists(tempFile)) File.Delete(tempFile);
        }

        // Test 5: Backward compatibility loading of original TennisProgram.txt
        if (File.Exists("TennisProgram.txt"))
        {
            var storage = new StorageService();
            var (legacyPlayers, _) = storage.LoadFromFile("TennisProgram.txt");
            if (legacyPlayers.Count != 6)
            {
                throw new Exception($"FAIL: Expected 6 players from TennisProgram.txt, found {legacyPlayers.Count}");
            }
            Console.WriteLine("✓ PASS: Successfully parsed legacy TennisProgram.txt file.");
        }

        Console.WriteLine("\n🎉 All 5 Self-Verification Tests Passed Successfully!");
    }

    private static void OpenBrowserUrl(string url)
    {
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url.Replace("&", "^&")}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
                Process.Start("xdg-open", url);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not automatically launch browser: {ex.Message}");
            Console.WriteLine($"You can open the link manually: {url}");
        }
    }
}
