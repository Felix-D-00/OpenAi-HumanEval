using System.Reflection.Metadata.Ecma335;

namespace OpenAi_HumanEval.SolverModules;

public class Factorise : SolverBase<int, int[]>
{
    public override int TaskID { get; } = 25;

    public override (int input, int[] expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        (8, new int[]{ 2, 2, 2 }),
        (25, new int[]{ 5, 5 }),
        (70, new int[]{ 2, 5, 7 }),

        //Test cases
        (2, new int[]{ 2 }),
        (4, new int[]{ 2, 2 }),
        (8, new int[]{ 2, 2, 2 }),
        (3 * 19, new int[]{ 3, 19 }),
        (3 * 19 * 3 * 19, new int[]{ 3, 3, 19, 19 }),
        (3 * 19 * 3 * 19 * 3 * 19, new int[]{ 3, 3, 3, 19, 19, 19 }),
        (3 * 19 * 19 * 19, new int[]{ 3, 19, 19, 19 }),
        (3 * 2 * 3, new int[]{ 2, 3, 3 }),
    };

    public override int[] Solve(int input)
    {
        List<int> factors = new List<int>();

        do
        {
            for (int i = 2; i <= input; i++)
            {
                if (input % i == 0)
                {
                    factors.Add(i);
                    input /= i;
                    break;
                }
            }
        } while (input != 1);

        return factors.ToArray();
    }
}
