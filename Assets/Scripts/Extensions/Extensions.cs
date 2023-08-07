using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{
    public static bool IsLetter(this string input)
    {
        return !string.IsNullOrEmpty(input) && char.IsLetter(input[0]);
    }

    public static T GetRandomItem<T>(this IEnumerable<T> enumerable)
    {
        var myEnumerable = enumerable as T[] ?? enumerable.ToArray();
        return myEnumerable[Random.Range(0, myEnumerable.Length)];
    }
}