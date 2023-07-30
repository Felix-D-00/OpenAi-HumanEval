namespace OpenAi_HumanEval.SolverModules;

public class Concatenate : SolverBase<List<string>, string>
{
    public override int TaskID { get; } = 28;

    public override (List<string> input, string expectedOutcome)[] Cases { get; } = 
    { 
        //Base case
        (new List<string>(){ "a", "b", "c" }, "abc"),

        //Test cases
        (new List<string>(){ }, ""),
        (new List<string>(){ "x", "y", "z" }, "xyz"),
        (new List<string>(){ "x", "y", "z", "w", "k" }, "xyzwk"),
    };

    public override string Solve(List<string> input)
    {
        return string.Concat(input);
    }
}
