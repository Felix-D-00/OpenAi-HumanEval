using OpenAi_HumanEval.Resources.Extentions;

namespace OpenAi_HumanEval.SolverModules;

public class RescaleToUnit : SolverBase<double[], double[]>
{
    public override int TaskID { get; } = 21;

    public override (double[] input, double[] expectedOutcome)[] Cases { get; } = 
    { 
        //Base case
        (new double[]{ 1.0, 2.0, 3.0, 4.0, 5.0 }, new double[]{ 0.0, 0.25, 0.5, 0.75, 1.0 }),

        //Test cases
        (new double[]{ 2.0, 49.9 }, new double[]{ 0.0, 1.0 }),
        (new double[]{ 100.0, 49.9 }, new double[]{ 1.0, 0.0 }),
        (new double[]{ 1.0, 2.0, 3.0, 4.0, 5.0 }, new double[]{ 0.0, 0.25, 0.5, 0.75, 1.0 }),
        (new double[]{ 2.0, 1.0, 5.0, 3.0, 4.0 }, new double[]{ 0.25, 0.0, 1.0, 0.5, 0.75 }),
        (new double[]{ 12.0, 11.0, 15.0, 13.0, 14.0 }, new double[]{ 0.25, 0.0, 1.0, 0.5, 0.75 }),
    };

    public override double[] Solve(double[] input)
    {
        Dictionary<double, int> inputSortedOrder = new();

        double[] sortedInput = input.Sort();
        for (int i = 0; i < sortedInput.Length; i++)
            inputSortedOrder.Add(sortedInput[i], i);

        return input.Select(x => (Convert.ToDouble(inputSortedOrder[x])/(input.Length - 1))).ToArray();
    }
}
