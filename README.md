# CSE 210: Programming with Classes - Projects & Capstone

Welcome to my coursework repository for **CSE 210 (Programming with Classes in C#)** at BYU-Idaho.

---

## 🏆 Featured Project: Pickleball Coach (`final/FinalProject`)

The centerpiece of this repository is **Pickleball Coach**, a comprehensive C# terminal application designed to track player progress, execute guided practice drills, log singles and doubles matches, and unlock coaching tutorials.

### Highlights:
* **Object-Oriented Design**: Utilizes abstraction, inheritance, polymorphism, encapsulation, and composition across Shots, Drills, Games, and Player entities.
* **Practice Drills**: Interactive training sessions for Forehand, Backhand, and Drop Shots.
* **Match Logging**: Complete match tracking for both 1v1 Singles and 2v2 Doubles with automated score calculation and skill level progression.
* **Coaching Tip Store**: Progressive unlock system linking directly to pro video tutorials as players level up.
* **Storage Persistence**: File storage with backward compatibility for legacy saved data.
* **Robust Error Handling**: Crash-proof input handling for all user choices.

### Quick Start
To launch the Pickleball Coach terminal app:
```bash
cd final/FinalProject
dotnet run
```

To run the built-in automated test suite:
```bash
cd final/FinalProject
dotnet run -- --test
```

For full documentation and architecture details, see [FinalProject/README.md](final/FinalProject/README.md).

---

## 📁 Repository Overview

This repository also contains all learning activities, preparation exercises, and development projects completed throughout the semester:

| Directory | Description |
|---|---|
| [`final/FinalProject`](final/FinalProject) | **Featured Capstone**: Pickleball Coach terminal application. |
| [`final/Foundation1` - `Foundation4`](final/) | Final foundation milestone exercises exploring class interactions, inheritance, and polymorphism. |
| [`csharp-prep`](csharp-prep) | Intro preparation exercises covering fundamental C# syntax, loops, lists, and functions. |
| [`prepare`](prepare) | Preparation learning activities for object-oriented principles. |
| [`prove`](prove) | Weekly developer projects implementing real-world console applications. |
| [`sandbox`](sandbox) | Experimental scratch project for prototyping concepts. |
| [`plantuml`](plantuml) | UML diagrams visualizing class structures and hierarchies. |
