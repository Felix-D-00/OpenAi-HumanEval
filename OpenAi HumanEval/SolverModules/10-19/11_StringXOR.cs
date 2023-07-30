namespace OpenAi_HumanEval.SolverModules;

public class StringXOR : SolverBase<(string, string), string>
{
    public override int TaskID { get; } = 11;

    public override ((string, string) input, string expectedOutcome)[] Cases { get; } = 
    { 
        //Base case
        (("010", "110"), "100"),

        //Test cases
        (("111000", "101010"), "010010"),
        (("1", "1"), "0"),
        (("0101", "0000"), "0101"),
    };

    public override string Solve((string, string) input)
    {
        string result = "";

        for (int i = 0; i < input.Item1.Length; i++)
            result += XOR(input.Item1[i], input.Item2[i]);

        return result;
    }

    private static char XOR(char a, char b)
    {
        return ((a == '1') ^ (b == '1')) ? '1' : '0';
    }
}
