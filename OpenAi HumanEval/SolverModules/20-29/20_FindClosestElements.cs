using OpenAi_HumanEval.Resources.Extentions;

namespace OpenAi_HumanEval.SolverModules;

public class FindClosestElements : SolverBase<double[], (double, double)>
{
    public override int TaskID { get; } = 20;

    public override (double[] input, (double, double) expectedOutcome)[] Cases { get; } = 
    { 
        //Base cases
        (new double[]{ 1.0, 2.0, 3.0, 4.0, 5.0, 2.2 }, (2.0, 2.2)),
        (new double[]{ 1.0, 2.0, 3.0, 4.0, 5.0, 2.0 }, (2.0, 2.0)),

        //Test cases
        (new double[]{ 1.0, 2.0, 3.9, 4.0, 5.0, 2.2 }, (3.9, 4.0)),
        (new double[]{ 1.0, 2.0, 5.9, 4.0, 5.0 }, (5.0, 5.9)),
        (new double[]{ 1.0, 2.0, 3.0, 4.0, 5.0, 2.2 }, (2.0, 2.2)),
        (new double[]{ 1.0, 2.0, 3.0, 4.0, 5.0, 2.0 }, (2.0, 2.0)),
        (new double[]{ 1.1, 2.2, 3.1, 4.1, 5.1 }, (2.2, 3.1))
    };

    public override (double, double) Solve(double[] input)
    {
        double minDifference = double.MaxValue;
        (double, double) result = (0.0, 0.0);
        input = input.Sort();

        for (int i = 0; i < input.Length; i++)
        {
            double a = input[i];

            for (int j = i + 1; j < input.Length; j++)
            {
                double b = input[j];

                double absDifference = Math.Abs(a - b);
                if (absDifference == 0.0)
                    return (a, b);
                if (absDifference < minDifference)
                {
                    result = (a, b);
                    minDifference = absDifference;
                }
            }
        }

        return result;
    }
}
