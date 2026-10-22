/// <summary>
/// Derived class representing a Drop Shot (dink / soft reset) in pickleball.
/// Demonstrates OOP Principle: Inheritance.
/// </summary>
public class DropShot : Shot
{
    public DropShot(decimal level = 0.0m) : base("DropShot", level)
    {
    }
}
