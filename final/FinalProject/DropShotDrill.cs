/// <summary>
/// Practice drill focused on kitchen line drop shots, dinking, and soft resets.
/// Demonstrates OOP Principle: Inheritance.
/// </summary>
public class DropShotDrill : Drill
{
    public DropShotDrill() : base(
        name: "Drop Shot Practice",
        description: "The drop shot is a finesse shot in pickleball requiring delicate touch and placement to softly land the ball just over the net into the non-volley zone (kitchen).",
        points: 30m,
        setup: "Find a practice partner and a pickleball court. Position yourselves across the net at the kitchen line.",
        objective: "The goal of this drill is to practice executing delicate drop shots with your paddle, focusing on placement and control.",
        execution: "- Start by having the serving partner initiate the rally with a soft feed.\n" +
                   "- Respond with a controlled drop shot landing softly in the opponent's kitchen.\n" +
                   "- Focus on using a gentle, controlled upward lift with a relaxed wrist.\n" +
                   "- Aim to land the ball within 1-2 feet of the net, keeping it unattackable.\n" +
                   "- Rally softly back and forth, emphasizing reset touch and depth control."
    )
    {
    }
}
