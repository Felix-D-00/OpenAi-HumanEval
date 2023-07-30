using System.Numerics;

namespace OpenAi_HumanEval.Resources.Extentions;

public static class ArrayExtentions
{
    public static T[] Sort<T>(this T[] source) where T : INumber<T>
    {
        List<T> sortedList = source.ToList();
        sortedList.Sort();
        return sortedList.ToArray();
    }
}
