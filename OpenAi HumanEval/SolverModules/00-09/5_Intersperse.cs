namespace OpenAi_HumanEval.SolverModules;

public class Intersperse : SolverBase<(int[], int), int[]>
{
    public override int TaskID { get; } = 5;

    public override ((int[], int) input, int[] expectedOutcome)[] Cases { get; } =
    { 
        //Base cases
        ((new int[]{ }, 4), new int[]{ }),
        ((new int[]{ 1, 2, 3 }, 4), new int[]{ 1, 4, 2, 4, 3 }),

        //Test cases
        ((new int[]{ }, 7), new int[]{ }),
        ((new int[]{ 5, 6, 3, 2 }, 8), new int[]{ 5, 8, 6, 8, 3, 8, 2 }),
        ((new int[]{ 2, 2, 2 }, 2), new int[]{ 2, 2, 2, 2, 2 }),
    };

    public override int[] Solve((int[], int) input)
    {
        if (input.Item1.Length == 0)
            return new int[] { };

        int total = input.Item1.Length * 2 - 1;

        int[] result = new int[total];

        for (int i = 0; i < total; i++)
        {
            if (i % 2 == 1)
                result[i] = input.Item2;
            else
                result[i] = input.Item1[i/2];
        }

        return result;
    }
}
