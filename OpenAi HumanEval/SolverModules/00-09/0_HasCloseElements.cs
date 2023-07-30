namespace OpenAi_HumanEval.SolverModules;

public class HasCloseElements : SolverBase<(float[], float), bool>
{
    public override int TaskID { get; } = 0;

    public override ((float[], float) input, bool expectedOutcome)[] Cases { get; } =
    {
        //Base cases
        ((new float[] { 1.0f, 2.0f, 3.0f }, 0.5f), false),
        ((new float[] { 1.0f, 2.8f, 3.0f, 5.0f, 2.0f }, 0.3f), true),

        //Test cases
        ((new float[] { 1.0f, 2.0f, 3.9f, 4.0f, 5.0f, 2.2f }, 0.3f), true),
        ((new float[] { 1.0f, 2.0f, 3.9f, 4.0f, 5.0f, 2.2f }, 0.05f), false),
        ((new float[] { 1.0f, 2.0f, 5.9f, 4.0f, 5.0f }, 0.95f), true),
        ((new float[] { 1.0f, 2.0f, 5.9f, 4.0f, 5.0f }, 0.8f), false),
        ((new float[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 2.0f }, 0.1f), true),
        ((new float[] { 1.1f, 2.2f, 3.1f, 4.1f, 5.1f }, 1.0f), true),
        ((new float[] { 1.1f, 2.2f, 3.1f, 4.1f, 5.1f }, 0.5f), false)
    };


    public override bool Solve((float[], float) numbers)
    {
        float[] input = numbers.Item1;
        float threshold = numbers.Item2;

        Array.Sort(input);

        for (int i = 0; i < input.Length - 1; i++)
            if (input[i + 1] - input[i] < threshold)
                return true;

        return false;
    }
}
