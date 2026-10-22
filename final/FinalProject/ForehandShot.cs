/// <summary>
/// Derived class representing a Forehand shot in pickleball.
/// Demonstrates OOP Principle: Inheritance (inherits common shot properties and behavior from Shot).
/// </summary>
public class ForehandShot : Shot
{
    public ForehandShot(decimal level = 0.0m) : base("Forehand", level)
    {
    }
}
