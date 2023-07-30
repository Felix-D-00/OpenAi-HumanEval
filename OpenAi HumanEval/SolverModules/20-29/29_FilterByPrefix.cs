namespace OpenAi_HumanEval.SolverModules;

public class FilterByPrefix : SolverBase<(List<string>, string), List<string>>
{
    public override int TaskID { get; } = 29;

    public override ((List<string>, string) input, List<string> expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        ((new List<string>(){ }, "a"), new List<string>(){ }),
        ((new List<string>(){ "abc", "bcd", "cde", "array" }, "a"), new List<string>(){ "abc", "array" }),

        //Test cases
        ((new List<string>(){ }, "john"), new List<string>(){ }),
        ((new List<string>(){ "xxx", "asd", "xxy", "john doe", "xxxAAA", "xxx" }, "xxx"), new List<string>(){ "xxx", "xxxAAA", "xxx" }),
    };

    public override List<string> Solve((List<string>, string) input)
    {
        List<string> toFilter = input.Item1;
        string prefix = input.Item2;

        return toFilter.Where(x => (x.Length >= prefix.Length) && (x[0..prefix.Length] == prefix)).ToList();
    }
}
