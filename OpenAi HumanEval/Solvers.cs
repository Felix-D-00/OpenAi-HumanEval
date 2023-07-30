using System.Reflection;
using OpenAi_HumanEval.SolverModules;

namespace OpenAi_HumanEval;

public static class Solvers
{
    private static IDictionary<int, ISolverBase> _solutionsDict = new Dictionary<int, ISolverBase>();

    public static IDictionary<int, ISolverBase> SolutionsDict
    {
        get 
        {
            if (_solutionsDict.Any() is false)
                _solutionsDict = Assembly.GetExecutingAssembly().GetTypes()
                                                                .Where(t => typeof(ISolverBase).IsAssignableFrom(t) && t.IsClass && (t.IsAbstract is false))
                                                                .Select(t => (ISolverBase)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetName().Name!, t.FullName!)!.Unwrap()!)
                                                                .ToDictionary(s => s.TaskID);

            return _solutionsDict;
        }
    }

    public static List<ISolverBase> Solutions
        => SolutionsDict.Values.ToList();
}
