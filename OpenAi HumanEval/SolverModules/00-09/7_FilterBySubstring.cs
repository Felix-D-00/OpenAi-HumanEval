namespace OpenAi_HumanEval.SolverModules;

public class FilterBySubstring : SolverBase<(string[], string), string[]>
{
    public override int TaskID { get; } = 7;

    public override ((string[], string) input, string[] expectedOutcome)[] Cases { get; } = 
    { 
        //Base case
        ((new string[]{ }, "a"), new string[]{ }),    
        ((new string[]{ "abc", "bacd", "cde", "array" }, "a"), new string[]{ "abc", "bacd", "array" }),    

        //Test cases
        ((new string[]{ }, "john"), new string[]{ }),
        ((new string[]{ "xxx", "asd", "xxy", "john doe", "xxxAAA", "xxx" }, "xxx"), new string[]{ "xxx", "xxxAAA", "xxx" }),
        ((new string[]{ "xxx", "asd", "aaaxxy", "john doe", "xxxAAA", "xxx" }, "xx"), new string[]{ "xxx", "aaaxxy", "xxxAAA", "xxx" }),
        ((new string[]{ "grunt", "trumpet", "prune", "gruesome" }, "run"), new string[]{ "grunt", "prune" }),
    };


    public override string[] Solve((string[], string) input)
    {
        return input.Item1.Where(x => x.Contains(input.Item2)).ToArray();
    }
}
