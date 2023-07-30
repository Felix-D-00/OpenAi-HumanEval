namespace OpenAi_HumanEval.SolverModules;

public class StringLength : SolverBase<string, int>
{
    public override int TaskID { get; } = 23;

    public override (string input, int expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        ("", 0),
        ("abc", 3),

        //Test cases
        ("", 0),
        ("x", 1),
        ("asdasnakj", 9),
    };

    public override int Solve(string input)
    {
        return input.Length;
    }
}
