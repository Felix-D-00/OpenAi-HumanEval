namespace OpenAi_HumanEval.SolverModules;

public class ParseNestedParentheses : SolverBase<string, int[]>
{
    public override int TaskID { get; } = 6;

    public override (string input, int[] expectedOutcome)[] Cases { get; } =
    {
        //Base case
        ("(()()) ((())) () ((())()())", new int[]{ 2, 3, 1, 3 }),

        //Test cases
        ("(()()) ((())) () ((())()())", new int[]{ 2, 3, 1, 3 }),
        ("() (()) ((())) (((())))", new int[]{ 1, 2, 3, 4 }),
        ("(()(())((())))", new int[]{ 4 }),
    };


    public override int[] Solve(string input)
    {
        List<int> depths = new List<int>();

        int maxdepth = 0;
        int depth = 0;

        foreach (char i in input)
        {
            switch (i)
            {
                case '(':
                    depth++;
                    break;
                case ')':
                    depth--;
                    break;
                
                default:
                    continue;
            };

            if (depth > maxdepth)
                maxdepth = depth;

            if (depth == 0)
            {
                depths.Add(maxdepth);
                maxdepth = 0;
            }
        }

        return depths.ToArray();
    }
}
