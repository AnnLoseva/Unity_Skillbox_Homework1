using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{

    [SerializeField] private InputField firstInput;
    [SerializeField] private InputField secondInput;
    [SerializeField] private Text answer;
    private float result;
    private float a;
    private float b;
    public void Plus()
    {
        a = float.Parse(firstInput.text);
        b = float.Parse(secondInput.text);
        result = a + b;
        answer.text = ("" + result);
    }

    public void Minus()
    {
        a = float.Parse(firstInput.text);
        b = float.Parse(secondInput.text);
        result = a - b;
        answer.text = ("" + result);
    }

    public void Multiply()
    {
        a = float.Parse(firstInput.text);
        b = float.Parse(secondInput.text);
        result = a * b;
        answer.text = ("" + result);
    }

    public void Divide()
    {
        a = float.Parse(firstInput.text);
        b = float.Parse(secondInput.text);
        result = a / b;
        answer.text = ("" + result);
    }

}