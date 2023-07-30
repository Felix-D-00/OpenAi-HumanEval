namespace OpenAi_HumanEval.SolverModules;

public class GreatestCommonDivisor : SolverBase<(int, int), int>
{
    public override int TaskID { get; } = 13;

    public override ((int, int) input, int expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        ((3, 5), 1),
        ((25, 15), 5),

        //Test cases
        ((3, 7), 1),
        ((10, 15), 5),
        ((49, 14), 7),
        ((144, 60), 12),
    };

    public override int Solve((int, int) input)
    {
        int a = input.Item1;
        int b = input.Item2;

        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}
