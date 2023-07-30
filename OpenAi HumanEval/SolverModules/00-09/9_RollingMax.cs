namespace OpenAi_HumanEval.SolverModules;

public class RollingMax : SolverBase<int[], int[]>
{
    public override int TaskID { get; } = 9;

    public override (int[] input, int[] expectedOutcome)[] Cases { get; } = 
    { 
        //Base case
        (new int[]{ 1, 2, 3, 2, 3, 4, 2 }, new int[]{ 1, 2, 3, 3, 3, 4, 4 }),

        //Test cases
        (new int[]{ }, new int[]{ }),
        (new int[]{ 1, 2, 3, 4 }, new int[]{ 1, 2, 3, 4 }),
        (new int[]{ 4, 3, 2, 1 }, new int[]{ 4, 4, 4, 4 }),
        (new int[]{ 3, 2, 3, 100, 3 }, new int[]{ 3, 3, 3, 100, 100 }),
    };


    public override int[] Solve(int[] input)
    {
        List<int> result = new List<int>();

        int max = 0;

        foreach (int i in input)
        { 
            if (i > max)
                max = i;

            result.Add(max);
        }

        return result.ToArray();
    }
}
