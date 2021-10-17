using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFreqTest : MonoBehaviour
{
    public int[] values;
    public int[] freqs;


    public int runTime;

    private void OnValidate()
    {
        int[] counters = new int[values.Length];

        for (int i = 0; i < runTime; i++)
        {
            //Random.InitState((int)(Random.value * 10000));
            int chosen = UMath.UMath.ChooseRandomlyWithFrequency(values, freqs, values.Length);

            int index = findIndex(values, chosen);
            counters[index] += 1;
        }

        for(int i = 0;i < counters.Length; i++)
        {
            Debug.Log($"Value {values[i]} is chosen {counters[i]} times.");
        }
    }

    int findIndex(int[] arr, int val)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == val)
                return i;
        }

        Debug.LogError(" `findIndex` Not exist in arr");
        return -1;
    }
}
