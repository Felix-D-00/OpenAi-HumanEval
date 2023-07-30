namespace OpenAi_HumanEval.SolverModules;

public class AllPrefixes : SolverBase<string, string[]>
{
    public override int TaskID { get; } = 14;

    public override (string input, string[] expectedOutcome)[] Cases { get; } = 
    { 
        //Base case
        ("abc", new string[]{ "a", "ab", "abc" }),

        //Test cases
        ("", new string[]{ }),
        ("asdfgh", new string[]{ "a", "as", "asd", "asdf", "asdfg", "asdfgh" }),
        ("WWW", new string[]{ "W", "WW", "WWW" }),
    };

    public override string[] Solve(string input)
    {
        List<string> result = new();

        for (int i = 0; i < input.Length; i++)
            result.Add(input[..(i+1)]);

        return result.ToArray();
    }
}
