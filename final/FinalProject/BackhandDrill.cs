/// <summary>
/// Practice drill focused on backhand control, reset, and placement.
/// Demonstrates OOP Principle: Inheritance.
/// </summary>
public class BackhandDrill : Drill
{
    public BackhandDrill() : base(
        name: "Backhand Practice",
        description: "Backhand shots are essential in pickleball, requiring precision and control to effectively return balls from your opponent. Here's a drill to help you improve your backhand technique.",
        points: 25m,
        setup: "Find a practice partner and a pickleball court. Position yourselves on opposite sides of the net, with one player serving and the other player receiving.",
        objective: "The goal of this drill is to practice executing effective backhand shots, focusing on consistency and placement.",
        execution: "- Start by having the serving player initiate the rally with a serve to the receiving player's backhand side.\n" +
                   "- After the receive, the receiving player should respond with a controlled backhand shot. Focus on using proper footwork and paddle preparation.\n" +
                   "- Aim to hit the ball cleanly with your backhand, directing it to different areas of the court with accuracy.\n" +
                   "- Pay attention to your body positioning and weight transfer, ensuring balance and stability throughout the shot.\n" +
                   "- The serving player should then attempt to return the backhand shot with a soft volley or an aggressive shot, depending on the situation.\n" +
                   "- Continue rallying back and forth, alternating between serving and receiving, with both players focusing on executing quality backhand shots."
    )
    {
    }
}
