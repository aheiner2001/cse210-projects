# 🏓 Pickleball Coach

> A performance tracking and training terminal application built in C# demonstrating Object-Oriented Programming (OOP) principles.

---

## 🌟 Overview
**Pickleball Coach** is a terminal-based training and match-logging application designed for competitive and recreational pickleball players. The app helps players track their career stats, practice specific shot techniques (Forehand, Backhand, Drop Shot) via interactive drills, log singles and doubles match results, and unlock curated coaching tutorials as their experience grows.

Originally created as the Capstone project for BYU-Idaho's **CSE 210 (Programming with Classes)**, this codebase has been refactored and modernized to follow clean architecture principles, robust error handling, and modern .NET standards.

---

## 🚀 Key Features

* **Player Profiles & Independent Skill Progression**: Track individual player levels, shot proficiencies, and win/loss records.
* **Guided Practice Drills**:
  * **Forehand Practice**: Drill power, consistency, and court depth (+20 XP).
  * **Backhand Practice**: Practice resets, directional control, and fast hands (+25 XP).
  * **Drop Shot Practice**: Master third-shot drops and soft kitchen-line play (+30 XP).
* **Match Logging**:
  * **Singles (1v1)**: Log scores with automatic winner calculation and symmetrical XP adjustments.
  * **Doubles (2v2)**: Support for 4 distinct players across two teams.
* **Pro Tip Store**: Unlock pro coaching videos as your player reaches higher skill tiers (e.g., Level 0, Level 2, Level 5, Level 7, Level 9, Level 12).
* **Flat-File Persistence**: Save and load player rosters and match histories using backward-compatible delimited files (`TennisProgram.txt`).
* **Crash-Proof Input Validation**: Safe number and string input handling to eliminate `FormatException` and index out-of-bounds crashes.

---

## 🧱 OOP Architecture & Principles

| OOP Principle | Implementation in Pickleball Coach |
|---|---|
| **Abstraction** | Abstract base classes [`Game`](Game.cs), [`Shot`](Shot.cs), and [`Drill`](Drill.cs) define universal contracts and shared behavior while hiding low-level details. |
| **Inheritance** | Derived classes like [`SinglesGame`](SinglesGame.cs), [`DoublesGame`](DoublesGame.cs), [`ForehandShot`](ForehandShot.cs), [`BackhandShot`](BackhandShot.cs), and [`DropShotDrill`](DropShotDrill.cs) reuse and specialize base logic. |
| **Encapsulation** | [`Player`](Player.cs) protects its internal experience and shot collection. State changes occur exclusively through controlled domain methods like `AddExperience()`, `RecordSinglesWin()`, and `RecordDoublesWin()`. |
| **Polymorphism** | Match logging and serialization handle `Game` instances polymorphically (`SinglesGame` vs `DoublesGame`), and drills execute their specialized routines through base references. |
| **Single Responsibility** | [`StorageService`](StorageService.cs) is solely responsible for file persistence, decoupling I/O from domain entities. |

---

## 🛠️ Getting Started

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/) (.NET 8.0 or later / .NET 10)

### Run the Application
From the `final/FinalProject` directory:
```bash
dotnet run
```

### Run Automated Verification Suite
Run the built-in self-test suite to verify player isolation, win tracking, and storage round-trips:
```bash
dotnet run -- --test
```

---

## 💾 File Format Compatibility
Player and game records are saved using pipe delimiters (`||`):
* **Player Record**: `Player||Name||Age||Experience||ForehandLevel||BackhandLevel||DropShotLevel||SinglesWins||DoublesWins`
* **Singles Record**: `SinglesGame||Player1||Score1||Player2||Score2`
* **Doubles Record**: `DoublesGame||Team1P1||Team1P2||Score1||Team2P1||Team2P2||Score2`

Legacy 7-field records (without win counters) are automatically detected and loaded safely.
