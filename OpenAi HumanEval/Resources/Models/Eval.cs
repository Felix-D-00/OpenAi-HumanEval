namespace OpenAi_HumanEval.Resources.Models;

public class Eval
{
    public string Task_ID { get; set; } = string.Empty;

    public string Prompt { get; set; } = string.Empty;

    public string Entry_Point { get; set; } = string.Empty;

    public string Canonical_Solution { get; set; } = string.Empty;

    public string Test { get; set; } = string.Empty;
}
