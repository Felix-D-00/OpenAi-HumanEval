namespace OpenAi_HumanEval.SolverModules;

public class StringSequence : SolverBase<int, string>
{
    public override int TaskID { get; } = 15;

    public override (int input, string expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        (0, "0"),
        (5, "0 1 2 3 4 5"),

        //Test cases
        (0, "0"),
        (3, "0 1 2 3"),
        (10, "0 1 2 3 4 5 6 7 8 9 10"),
    };

    public override string Solve(int input)
    {
        return string.Join(' ', Enumerable.Range(0, input + 1).Select(x => x.ToString()));
    }
}
