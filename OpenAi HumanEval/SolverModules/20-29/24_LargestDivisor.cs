namespace OpenAi_HumanEval.SolverModules;

public class LargestDivisor : SolverBase<int, int>
{
    public override int TaskID { get; } = 24;

    public override (int input, int expectedOutcome)[] Cases { get; } = 
    { 
        //Base case
        (15, 5),

        //Test cases
        (3, 1),
        (7, 1),
        (10, 5),
        (100, 50),
        (49, 7),
    };

    public override int Solve(int input)
    {
        for (int i = input/2; i > 0; i--)
            if (input % i == 0)
                return i;

        return 1;
    }
}
