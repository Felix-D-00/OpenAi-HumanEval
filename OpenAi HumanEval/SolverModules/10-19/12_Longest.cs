namespace OpenAi_HumanEval.SolverModules;

public class Longest : SolverBase<string[], string?>
{
    public override int TaskID { get; } = 12;

    public override (string[] input, string? expectedOutcome)[] Cases { get; } =
    { 
        //Base case
        (new string[]{ "a", "b", "c" }, "a"),
        (new string[]{ "a", "bb", "ccc" }, "ccc"),

        //Test cases
        (new string[]{ }, null),
        (new string[]{ "x", "y", "z" }, "x"),
        (new string[]{ "x", "yyy", "zzzz", "www", "kkkk", "abc" }, "zzzz"),
    };

    public override string? Solve(string[] input)
    {
        if (input.Length == 0)
            return null;

        int maxLength = input.Max(x => x.Length);

        return input.First(x => x.Length == maxLength);
    }
}
