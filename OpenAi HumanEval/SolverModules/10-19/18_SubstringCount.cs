namespace OpenAi_HumanEval.SolverModules;

public class SubstringCount : SolverBase<(string, string), int>
{
    public override int TaskID { get; } = 18;

    public override ((string, string) input, int expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        (("", "a"), 0),
        (("aaa", "a"), 3),
        (("aaaa", "aa"), 3),
        
        //Test cases
        (("", "x"), 0),
        (("xyxyxyx", "x"), 4),
        (("cacacacac", "cac"), 4),
        (("john doe", "john"), 1),
    };

    public override int Solve((string, string) input)
    {
        string a = input.Item1;
        string b = input.Item2;

        if (a.Length == 0)
            return 0;

        int count = 0;

        for (int i = 0; i < a.Length - b.Length + 1; i++)
            if (a.Substring(i, b.Length) == b)
                count++;

        return count;
    }
}
