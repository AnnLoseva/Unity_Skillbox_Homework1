using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessTheNumber : MonoBehaviour
{
    public int randomNumber;
    public int guessNumber;
    public Text answer;
    public InputField inputField;
    
    void Start()
    {
        randomNumber = Random.Range(1, 100);
    }

    public void guessFunction()
    {
        guessNumber = int.Parse(inputField.text);

        if (guessNumber < randomNumber)
        {
            answer.text = $"Number {guessNumber} is LOWER then needed";
        }
        else if (guessNumber > randomNumber)
        {
            answer.text = $"Number {guessNumber} is HIGHER then needed";

        }
        else if (guessNumber == randomNumber)
        {
            answer.text = $"Correct! The number is {guessNumber}!";
        }
    }

}
