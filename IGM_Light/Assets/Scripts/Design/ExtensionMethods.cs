using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ExtensionMethod
{
    public static void ForEach<T>(this IEnumerable<T> source, System.Action<T> action)
    {
        foreach (var e in source)
            action(e);
    }

    public static IEnumerable<T> SubArray<T>(this IEnumerable<T> source, int start, int count)
    {
        return source.Skip(start).Take(count);
    }


    public static T GetTop<T>(this T[] array)
    {
        return array[array.Length-1];
    }

    public static T Top<T>(this List<T> list)
    {
        return list[list.Count-1];
    }

    public static IEnumerator DoWaitForSeconds(float time, System.Action action) 
    {
        yield return new WaitForSeconds(time);
        action();
    }

    public static bool HasSameValue(this Vector2Int[] source, Vector2Int[] target)
    {
        if (source.Length != target.Length)
            return false;

        foreach(Vector2Int sourceEle in source)
        {
            bool flag = false;

            foreach(Vector2Int targetEle in target)
            {
                if (sourceEle == targetEle)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
                return false;
        
        }

        return true;
    }
}

