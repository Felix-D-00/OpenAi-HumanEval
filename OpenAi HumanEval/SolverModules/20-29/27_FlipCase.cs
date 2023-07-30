namespace OpenAi_HumanEval.SolverModules;

public class FlipCase : SolverBase<string, string>
{
    public override int TaskID { get; } = 27;

    public override (string input, string expectedOutcome)[] Cases { get; } = 
    { 
        //Base case
        ("Hello", "hELLO"),

        //Test cases
        ("", ""),
        ("Hello!", "hELLO!"),
        ("These violent delights have violent ends", "tHESE VIOLENT DELIGHTS HAVE VIOLENT ENDS"),
    };

    public override string Solve(string input)
    {
        string result = string.Empty;

        foreach (char i in input)
        {
            string j = i.ToString();
            result += j == j.ToUpper() ? j.ToLower() : j.ToUpper();
        }

        return result;
    }
}
