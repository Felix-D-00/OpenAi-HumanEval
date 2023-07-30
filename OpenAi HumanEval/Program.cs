using OpenAi_HumanEval;
using OpenAi_HumanEval.SolverModules;

foreach (ISolverBase i in Solvers.Solutions)
    i.Execute();

Console.ReadLine();