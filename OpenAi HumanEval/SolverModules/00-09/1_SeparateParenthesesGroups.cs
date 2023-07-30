namespace OpenAi_HumanEval.SolverModules;

public class SeparateParenthesesGroups : SolverBase<string, string[]>
{
    public override int TaskID { get; } = 1;

    public override (string, string[])[] Cases { get; } = 
    { 
        //Base case
        ("( ) (( )) (( )( ))", new string[] { "()", "(())", "(()())" }),

        //Test cases
        ("(()()) ((())) () ((())()())", new string[]{ "(()())", "((()))", "()", "((())()())" }),        
        ("() (()) ((())) (((())))", new string[]{ "()", "(())", "((()))", "(((())))" }),        
        ("(()(())((())))", new string[]{ "(()(())((())))" }),
        ("( ) (( )) (( )( ))", new string[]{ "()", "(())", "(()())" })
    };

    public override string[] Solve(string input)
    {
        List<string> result = new();

        int depth = 0;
        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i]) 
            {
                case '(':
                    if (depth == 0)
                        result.Add("");
                    depth++;
                    result[^1] += '(';
                    break;

                case ')':
                    depth--;
                    result[^1] += ')';
                    break;

                default:
                    break;
            };
        }

        return result.ToArray();
    }
}
