using OpenAi_HumanEval.Resources.Extentions;

namespace OpenAi_HumanEval.SolverModules;

public class FilterIntegers : SolverBase<object[], int[]>
{
    public override int TaskID { get; } = 22;

    public override (object[] input, int[] expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        (new object[]{ 'a', 3.14, 5 }, new int[]{ 5 }),
        (new object[]{ 1, 2, 3, "abc", new { }, new object[] { } }, new int[]{ 1, 2, 3 }),

        //Test cases
        (new object[]{ }, new int[]{ }),
        (new object[]{ 4, new { }, new object[] { }, 23.2, 9, "adasd" }, new int[]{ 4, 9 }),
        (new object[]{ 3, 'c', 3, 3, 'a', 'b' }, new int[]{ 3, 3, 3 }),
    };

    public override int[] Solve(object[] input)
    {
        return input.Where(x => x.GetType() == typeof(int)).Select(x => (int)x).ToArray().Sort().ToArray();
    }
}
