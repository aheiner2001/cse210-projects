# Pickleball Coach - Revamp Design Specification

## Overview
This specification details the complete object-oriented refactor and modernization of the **Pickleball Coach** terminal application within `final/FinalProject/` in `cse210-projects`.

## Goals
1. **Modern C# & .NET**: Upgrade target framework from obsolete `net7.0` to `net8.0` LTS.
2. **Robust OOP Architecture**:
   - Decouple Domain models (`Player`, `Game`, `Drill`, `Shot`, `Tip`) from terminal console I/O (`Console.ReadLine()` removed from entity constructors).
   - Resolve shared-state bug in `Player`: remove `static` from `_shots` list so each player possesses independent shot stats.
   - Fix scoring & win counters: fix `DoublesWon` incrementing singles counter, fix XP calculation logic so winners gain XP and losers lose XP without dropping below zero.
   - Refactor `Game` hierarchy: cleanly differentiate `SinglesGame` (1v1) from `DoublesGame` (2v2 with team scores).
3. **Data Persistence**:
   - Centralize storage in `StorageService`.
   - Ensure 100% backward compatibility with `TennisProgram.txt` and existing test files (`||` delimiter), gracefully handling legacy 7-field formats and 9-field formats.
4. **Resilient Terminal UI**:
   - Add input validation (`InputHelper`) to guard against empty strings and `FormatException` on numeric inputs.
   - Keep interactive terminal animations for drills.
5. **Documentation**:
   - Add clear, educational comments explaining the OOP principles (encapsulation, polymorphism, inheritance, abstraction) and what was refactored.
   - Update `final/FinalProject/README.md` and root `README.md` showcasing the app and retaining cataloging of course folders.
6. **Git**:
   - Commit all work and push to `origin/main`.
