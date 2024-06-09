using UnityEngine;
using System;
using Random = System.Random;

public class Loops : MonoBehaviour
{
    [SerializeField] private int number;
    void Start()
    {
        int[] array = SetArray(100);
        BubbleSort(array);
        SimpleNumber(array);
    }

    private int[] SetArray(int length)
    {
        int[] arr = new int[length];
        Random rnd = new Random();

        for(int i = 0; i < length; i++)
        {
            arr[i] = rnd.Next(-100,101);
        }

        return arr;
    }

    private void BubbleSort(int[] arr)
    {
        for(int i = 0;i < arr.Length;i++) 
        { 
        for (int j = 0; j < arr.Length - 1 - i; j++ )
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    private void SimpleNumber(int[] arr)
    {
        bool notSimple = false;
        foreach (int a in arr)
        {
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                {
                    Debug.Log($"Number {a} is not simple");
                    notSimple = true;
                }
            }
            if (notSimple == false)
            {
                Debug.Log($"Number {a} is simple");
            }
        }
    }
    
}
