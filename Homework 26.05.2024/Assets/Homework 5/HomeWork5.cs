using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.UI;

public class HomeWork5 : MonoBehaviour
{
    [SerializeField] private Text text;

    [Header("Task 1")]
    [SerializeField] private int minTask1 = 7;
    [SerializeField] private int maxTask1 = 21;

    [Header("Task 2")]
    [SerializeField] int[] array = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68};

    [Header("Task 3")]
    [SerializeField] private int numberTask3 = 34;



    void Start()
    {
        //Task1();
        //Task2();
        //Task3();
        
    }

    public void Task1()
    {
        int result = 0;
        for (int i = minTask1; i < maxTask1; i++)
        {
            if (i % 2 == 0)
            {
                result = result + i;
            }
        }

        text.text = ($"Task 1: {result}");
    }

    public void Task2()
    {
        int result = 0;
        foreach (int a in array)
        {
            
            if(a % 2 == 0)
            {
                result = result + a;
            }
        }
        text.text = ($"Task 2: {result}");
    }

    public void Task3()
    {
        int result = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == numberTask3)
            {
                result = i; break;
            }
        }
        text.text = ($"Task 3: {result}");

    }

    public void Task4()
    {
        int changableIndex = 0;

        for (int i = 0; i < array.Length; i++)
        {
            int minNumber = int.MaxValue;
            for (int j = i; j< array.Length; j++)
            {
                if (array[j] <= minNumber)
                {
                    minNumber = array[j];
                    changableIndex = j;
                }
            }
            array[changableIndex] = array[i];
            array[i] = minNumber;
        }
        text.text = ("Task 4: ") + string.Join(", ", array);
    }
 
}
