using Newtonsoft.Json;
using OpenAi_HumanEval.Resources.Models;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace OpenAi_HumanEval.SolverModules;

public abstract class SolverBase<Tin, Tout> : ISolverBase
{
    public abstract int TaskID { get; }

    public string TaskName => $"HumanEval/{TaskID}/{this.GetType().Name}";

    public abstract (Tin input, Tout expectedOutcome)[] Cases { get; }

    public abstract Tout Solve(Tin input);
    
    public void Execute()
    {
        string taskName = TaskName;
        string prompt = FormatPrompt();

        (Tin input, Tout output, Tout expectedOutcome)[] results = Cases.Select(c => (c.input, Solve(c.input), c.expectedOutcome)).ToArray();

        (string input, string output, string expectedOutcome)[] formattedResults = results.Select(r => (JsonConvert.SerializeObject(r.input),
                                                                                                        JsonConvert.SerializeObject(r.output),
                                                                                                        JsonConvert.SerializeObject(r.expectedOutcome))).ToArray();

        Print(taskName, prompt, formattedResults);
    }

    protected string FormatPrompt()
    {
        Eval prompt = Prompts.EvalDict[TaskID];

        Regex promptStart = new("\"\"\"");
        Regex promptEnd = new(">>>");

        //Full prompt text including python prompts
        string promptText = prompt.Prompt;
        //Extracted prompt information from python stuff
        promptText = promptText[(promptStart.Matches(promptText)[^2].Index + 4)..(promptEnd.Match(promptText).Index)];
        //Removed whitespace & formatted
        promptText = string.Join(Environment.NewLine, promptText.Split('\n')                                //Split lines
                                                                .Select(x => x.Trim())                      //Trim whitespace
                                                                .Where(x => x.Length > 0));                  //Only grab lines with content
        
        //Add final '.' if one isn't present.
        if (promptText[^1] != '.')
            promptText += '.';

        return promptText;
    }

    protected void Print(string taskName, string propmt, (string input, string output, string expectedOutcome)[] results)
    {
        //Print task name
        string[] splitTaskName = taskName.Split('/');
        Console.Write(splitTaskName[0]); //HumanEval
        Console.Write('/'); 
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(splitTaskName[1]); //Task number
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write('/'); 
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(splitTaskName[2]); //Task name
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        //Print prompt
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(propmt);
        Console.ForegroundColor = ConsoleColor.Gray;

        //Print results
        bool hasFailures = results.Any(x => x.output != x.expectedOutcome);
        int maxInputLength = Math.Max("input".Length + 1, results.Max(x => x.input.Length + 1));
        int maxOutputLength = Math.Max("output".Length + 1, results.Max(x => x.output.Length + 1));
        int maxRelevantExpectedOutcomeLength = hasFailures ? Math.Max("expected outcome".Length + 1, results.Where(x => x.output != x.expectedOutcome).Max(x => x.expectedOutcome.Length + 1)) : 0;

        //Print table headers
        Console.Write("input".PadRight(maxInputLength) + "| ");
        if (hasFailures)
            Console.WriteLine("output".PadRight(maxOutputLength) + "| expected outcome");
        else
            Console.WriteLine("output");

        //Print table box
        Console.Write(string.Empty.PadRight(maxInputLength, '-') + "|" + string.Empty.PadRight(maxOutputLength + 1, '-'));
        if (hasFailures)
            Console.Write("|" + string.Empty.PadRight(maxRelevantExpectedOutcomeLength + 1, '-'));

        Console.WriteLine();

        //Print table contents
        foreach ((string input, string output, string expectedOutcome) in results)
        {
            Console.Write(input.PadRight(maxInputLength) + "| ");

            if (output == expectedOutcome)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(output);
                Console.ForegroundColor = ConsoleColor.Gray;
                if (hasFailures)
                    Console.Write(string.Empty.PadRight(maxOutputLength - output.Length) + "|");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.Write(output.PadRight(maxOutputLength));
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("| ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(expectedOutcome);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
