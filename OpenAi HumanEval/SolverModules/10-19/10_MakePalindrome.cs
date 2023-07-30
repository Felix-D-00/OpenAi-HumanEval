namespace OpenAi_HumanEval.SolverModules;

public class MakePalindrome : SolverBase<string, string>
{
    public override int TaskID { get; } = 10;

    public override (string input, string expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        ("", ""),
        ("cat", "catac"),
        ("cata", "catac"),

        //Test cases
        ("", ""),
        ("x", "x"),
        ("xyz", "xyzyx"),
        ("xyx", "xyx"),
        ("jerry", "jerryrrej"),
    };

    public override string Solve(string input)
    {
        int length = input.Length;

        if (length <= 1)
            return input;

        string reversedInput = new(input.Reverse().ToArray());

        for (int i = 0; i < length; i++)
            if (input[i..] == reversedInput[..(length - i)])
                return string.Concat(input, reversedInput[(length - i)..]);

        return "";
    }
}
