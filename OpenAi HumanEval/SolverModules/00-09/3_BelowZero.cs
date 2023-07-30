namespace OpenAi_HumanEval.SolverModules;

public class BelowZero : SolverBase<int[], bool>
{
    public override int TaskID { get; } = 3;

    public override (int[] input, bool expectedOutcome)[] Cases { get; } =
    {
        //Base cases
        (new int[] { 1, 2, 3 }, false),
        (new int[] { 1, 2, -4, 3 }, true),

        //Test cases
        (new int[] { 1, 2, -3, 1, 2, -3 }, false),
        (new int[] { 1, 2, -4, 5, 6 }, true),
        (new int[] { 1, -1, 2, -2, 5, -5, 4, -4 }, false),
        (new int[] { 1, -1, 2, -2, 5, -5, 4, -5 }, true),
        (new int[] { 1, -2, 2, -2, 5, -5, 4, -4 }, true),
    };

    public override bool Solve(int[] input)
    {
        int total = 0;

        foreach (int i in input)
        {
            total += i;

            if (total < 0)
                return true;
        }

        return false;
    }
}
