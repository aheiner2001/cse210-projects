using System;
using System.Threading;

/// <summary>
/// Abstract base class representing a structured pickleball practice drill.
/// Demonstrates OOP Principles:
/// - Abstraction: Encapsulates drill details (metadata, instructions, reward points) and execution logic.
/// - Polymorphism: Derived drill classes supply specialized content and rewards while reusing shared drill execution flow.
/// </summary>
public abstract class Drill
{
    private readonly string _name;
    private readonly string _description;
    private readonly decimal _points;
    private readonly string _setup;
    private readonly string _objective;
    private readonly string _execution;

    protected Drill(string name, string description, decimal points, string setup, string objective, string execution)
    {
        _name = name;
        _description = description;
        _points = points;
        _setup = setup;
        _objective = objective;
        _execution = execution;
    }

    public string Name => _name;
    public string Description => _description;
    public decimal Points => _points;
    public string Setup => _setup;
    public string Objective => _objective;
    public string Execution => _execution;

    // Backward compatibility helper
    public decimal getPoints() => _points;

    /// <summary>
    /// Executes the interactive drill flow with informative terminal prompts and animations.
    /// </summary>
    public virtual void RunDrill()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===");
        Console.WriteLine(_description);
        Console.WriteLine($"\nReward: +{_points} Experience Points upon completion.");
        Console.WriteLine();
        EnterContinue("Press Enter to begin the drill...");

        Console.Clear();
        PlaySpinnerAnimation(3);
        Console.WriteLine($"=== {_name} ===");
        Console.WriteLine($"\n[Objective]\n{_objective}");
        EnterContinue();

        Console.WriteLine($"\n[Setup]\n{_setup}");
        Console.WriteLine($"\n[Execution Steps]\n{_execution}");
        PlaySpinnerAnimation(4);

        Console.WriteLine();
        Console.WriteLine($"🎉 Drill Complete! You earned +{_points} experience points.");
        EnterContinue();
    }

    // Backward compatibility method
    public void runDrill() => RunDrill();

    /// <summary>
    /// Renders a smooth console spinner animation.
    /// </summary>
    protected void PlaySpinnerAnimation(int cycles = 3, int stepDelayMs = 120)
    {
        char[] spinner = new[] { '|', '/', '-', '\\' };
        for (int i = 0; i < cycles * spinner.Length; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(stepDelayMs);
            Console.Write("\b \b");
        }
    }

    public void enterContinue() => EnterContinue();

    protected void EnterContinue(string prompt = "Press Enter to continue...")
    {
        Console.WriteLine(prompt);
        Console.ReadLine();
    }
}
