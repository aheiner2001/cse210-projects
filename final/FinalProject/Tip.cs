using System;

/// <summary>
/// Represents a coaching tip and video tutorial unlocked at specific player experience levels.
/// Demonstrates OOP Principle: Encapsulation.
/// </summary>
public class Tip
{
    private readonly int _requiredLevel;
    private readonly string _name;
    private readonly string _link;
    private readonly string _topic;

    public Tip(int requiredLevel, string name, string link, string topic = "Pickleball Fundamentals")
    {
        _requiredLevel = Math.Max(0, requiredLevel);
        _name = name;
        _link = link;
        _topic = topic;
    }

    public int RequiredLevel => _requiredLevel;
    public string Name => _name;
    public string Link => _link;
    public string Topic => _topic;

    // Backward compatibility getters
    public string getName() => _name;
    public int getRequiredLevel() => _requiredLevel;
    public string getLink() => _link;

    public override string ToString() => $"[Level {_requiredLevel}+] {_name} - {_topic}";
}
