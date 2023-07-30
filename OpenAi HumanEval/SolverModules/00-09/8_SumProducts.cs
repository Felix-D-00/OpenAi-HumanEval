namespace OpenAi_HumanEval.SolverModules;

public class SumProducts : SolverBase<int[], (int, int)>
{
    public override int TaskID { get; } = 8;

    public override (int[] input, (int, int) expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        (new int[]{ }, (0, 1)),
        (new int[]{ 1, 2, 3, 4 }, (10, 24)),

        //Test cases
        (new int[]{ }, (0, 1)),
        (new int[]{ 1, 1, 1 }, (3, 1)),
        (new int[]{ 100, 0 }, (100, 0)),
        (new int[]{ 3, 5, 7 }, (3 + 5 + 7, 3 * 5 * 7)),
        (new int[]{ 10 }, (10, 10)),
    };


    public override (int, int) Solve(int[] input)
    {
        int product = 1;

        foreach (int i in input)
            product *= i;

        return (input.Sum(), product);
    }
}
