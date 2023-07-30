using System.Text.Json;
using OpenAi_HumanEval.Resources.Models;

namespace OpenAi_HumanEval;

public static class Prompts
{
    private static IDictionary<int, Eval> _evalDict = new Dictionary<int, Eval>();

    public static IDictionary<int, Eval> EvalDict 
    {
        get 
        {
            //Try load prompts
            if (_evalDict.Any() is false)
                _evalDict = (JsonSerializer.Deserialize<List<Eval>>(File.OpenRead("human-eval.json"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new()).ToDictionary(e => int.Parse(e.Task_ID.Split('/')[^1]));

            return _evalDict;
        } 
    }
    
    public static List<Eval> Evals 
        => EvalDict.Values.ToList();
}
