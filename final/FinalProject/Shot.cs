using System;

/// <summary>
/// Represents an abstract base class for a specific pickleball shot technique.
/// Demonstrates OOP Principles:
/// - Abstraction: Captures general shot characteristics (name, skill level) while leaving specialized shots to derived classes.
/// - Encapsulation: Protects internal shot level from direct modification, enforcing growth through UpgradeLevel.
/// </summary>
public abstract class Shot
{
    private readonly string _name;
    private decimal _level;

    protected Shot(string name, decimal initialLevel = 0.0m)
    {
        _name = name;
        _level = Math.Max(0, initialLevel);
    }

    public string Name => _name;
    public decimal Level => _level;

    // Backward compatibility helpers
    public string getName() => _name;
    public decimal getShotLevel() => _level;

    /// <summary>
    /// Upgrades the shot level based on practice drill points.
    /// Formula: points * 0.025 (matching original design).
    /// </summary>
    public virtual void UpgradeLevel(decimal points)
    {
        if (points > 0)
        {
            _level += points * 0.025m;
        }
    }

    // Backward compatibility method
    public void upDateShotLevel(decimal num) => UpgradeLevel(num);

    public override string ToString() => $"{_name} (Level: {_level:F2})";
}
