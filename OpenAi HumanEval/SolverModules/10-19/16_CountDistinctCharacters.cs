namespace OpenAi_HumanEval.SolverModules;

public class CountDistinctCharacters : SolverBase<string, int>
{
    public override int TaskID { get; } = 16;

    public override (string input, int expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        ("xyzXYZ", 3),
        ("Jerry", 4),
        
        //Test cases
        ("", 0),
        ("abcde", 5),
        ("abcde" + "cade" + "CADE", 5),
        ("aaaaAAAAaaaa", 1),
        ("Jerry jERRY JeRRRY", 5),
    };

    public override int Solve(string input)
    {
        return input.ToLower().Distinct().Count();
    }
}
