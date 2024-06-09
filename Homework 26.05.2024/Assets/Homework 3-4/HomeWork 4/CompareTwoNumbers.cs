using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompareTwoNumbers : MonoBehaviour
{

    [SerializeField] private InputField firstInput;
    [SerializeField] private InputField secondInput;
    [SerializeField] private Text answer;
    private float a;
    private float b;
    public void CompareNumbers()
    {
        a = float.Parse(firstInput.text);
        b = float.Parse(secondInput.text);
        if (a > b) 
        {
            answer.text = (">");
        }
        else if(a < b)
        {
            answer.text = ("<");
        }
        else if (a == b)
        {
            answer.text = ("=");
        }
    }
}
