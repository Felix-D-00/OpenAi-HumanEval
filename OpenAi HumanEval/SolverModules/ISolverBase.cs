namespace OpenAi_HumanEval.SolverModules;

public interface ISolverBase
{
    public int TaskID { get; }

    public string TaskName { get; }

    public void Execute();
}
