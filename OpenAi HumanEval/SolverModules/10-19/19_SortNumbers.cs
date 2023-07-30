namespace OpenAi_HumanEval.SolverModules;

public class SortNumbers : SolverBase<string, string>
{
    public override int TaskID { get; } = 19;

    public override (string input, string expectedOutcome)[] Cases { get; } = 
    { 
        //Base case
        ("three one five", "one three five"),
        
        //Test cases
        ("", ""),
        ("three", "three"),
        ("three five nine", "three five nine"),
        ("five zero four seven nine eight", "zero four five seven eight nine"),
        ("six five four three two one zero", "zero one two three four five six"),
    };

    public override string Solve(string input)
    {
        if (input.Length == 0)
            return "";

        return string.Join(' ', input.Split(' ').OrderBy(x => NumberValues[x]));
    }

    private IDictionary<string, int> NumberValues { get; } = new Dictionary<string, int>() 
    {
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
    };
}
