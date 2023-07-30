namespace OpenAi_HumanEval.SolverModules;

public class TruncateNumber : SolverBase<decimal, decimal>
{
    public override int TaskID { get; } = 2;

    public override (decimal input, decimal expectedOutcome)[] Cases { get; } = 
    {
        //Base case
        (3.5M, 0.5M),

        //Test cases
        (1.33M, 0.33M),
        (123.456M, 0.456M),
    };

    public override decimal Solve(decimal input)
    {
        return input - Math.Truncate(input);
    }
}
