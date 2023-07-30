namespace OpenAi_HumanEval.SolverModules;

public class RemoveDuplicates : SolverBase<int[], int[]>
{
    public override int TaskID { get; } = 26;

    public override (int[] input, int[] expectedOutcome)[] Cases { get; } = 
    { 
        //Base case
        (new int[]{ 1, 2, 3, 2, 4 }, new int[]{ 1, 3, 4 }),

        //Test cases
        (new int[]{ }, new int[]{ }),
        (new int[]{ 1, 2, 3, 4 }, new int[]{ 1, 2, 3, 4 }),
        (new int[]{ 1, 2, 3, 2, 4, 3, 5 }, new int[]{ 1, 4, 5 }),
    };

    public override int[] Solve(int[] input)
    {
        Dictionary<int, int> count = input.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        return count.Where(x => x.Value == 1).Select(x => x.Key).ToArray();
    }
}
