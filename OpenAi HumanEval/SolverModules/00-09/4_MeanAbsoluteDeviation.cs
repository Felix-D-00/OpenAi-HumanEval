namespace OpenAi_HumanEval.SolverModules;

public class MeanAbsoluteDeviation : SolverBase<double[], double>
{
    public override int TaskID { get; } = 4;

    public override (double[] input, double expectedOutcome)[] Cases { get; } =
    { 
        //Base case
        (new double[]{ 1.0, 2.0, 3.0, 4.0 }, 1.0),

        //Test cases
        (new double[]{ 1.0, 2.0, 3.0 }, 2.0/3.0),
        (new double[]{ 1.0, 2.0, 3.0, 4.0 }, 1.0),
        (new double[]{ 1.0, 2.0, 3.0, 4.0, 5.0 }, 6.0/5.0),
    };


    public override double Solve(double[] input)
    {
        double mean = Mean(input);

        return Mean(input.Select(i => Math.Abs(i - mean)).ToArray());
    }

    private double Mean(double[] input)
    {
        return input.Sum() / input.Length;
    }
}
