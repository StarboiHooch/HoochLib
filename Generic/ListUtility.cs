using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListUtility
{
    public static List<T> ShuffleList<T>(List<T> list)
    {
        List<T> shuffledList = new();

        for (int i = list.Count - 1; i >= 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            shuffledList.Add(list[randomIndex]);
            list.RemoveAt(randomIndex);
        }

        return shuffledList;
    }
}
