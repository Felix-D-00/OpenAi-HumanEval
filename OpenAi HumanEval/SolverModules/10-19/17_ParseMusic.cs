namespace OpenAi_HumanEval.SolverModules;

public class ParseMusic : SolverBase<string, int[]>
{
    public override int TaskID { get; } = 17;

    public override (string input, int[] expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        ("o o| .| o| o| .| .| .| .| o o", new int[]{ 4, 2, 1, 2, 2, 1, 1, 1, 1, 4, 4 }),
        ("", new int[]{ }),

        //Test cases
        ("", new int[]{ }),
        ("o o o o", new int[]{ 4, 4, 4, 4 }),
        (".| .| .| .|", new int[]{ 1, 1, 1, 1 }),
        ("o| o| .| .| o o o o", new int[]{ 2, 2, 1, 1, 4, 4, 4, 4 }),
        ("o| .| o| .| o o| o o|", new int[]{ 2, 1, 2, 1, 4, 2, 4, 2 }),
    };

    public override int[] Solve(string input)
    {
        if (input.Trim(' ').Length == 0)
            return Array.Empty<int>();

        return input.Split(' ').Select(x => NoteLength[x]).ToArray();
    }

    private IDictionary<string, int> NoteLength = new Dictionary<string, int>() 
    {
        {"o", 4},
        {"o|", 2},
        {".|", 1},
    };
}
