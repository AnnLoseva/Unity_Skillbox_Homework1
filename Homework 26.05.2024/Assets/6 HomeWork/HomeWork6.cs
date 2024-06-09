using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeWork6 : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Text timerText;
    [SerializeField] Text[] pinText = new Text[3];
    [SerializeField] GameObject endGameWinow;
    [SerializeField] GameObject victoryWindow;
    [SerializeField] GameObject playWindow;

    [Header("Pins and Answers")]

    [SerializeField] private int[] startPinVariable = {4, 4, 0};
    [SerializeField] private int[] pinAnswer = {4, 4, 4};
    private int[] pinVariable = { 0, 0, 0 };

    [Header("Pin Openers")]
    [SerializeField] private int[] pinOpener1 = { 0, +2, +6 };
    [SerializeField] private int[] pinOpener2 = { +1, -3, -4 };
    [SerializeField] private int[] pinOpener3 = { -2, +4, +6 };

    private float currentTime;
    private int mistake;


    private void Start()
    {
        Play();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = ($"Timer: {Mathf.Round(currentTime).ToString()}");

        if (currentTime >= 30)
        {
            EndGame();
        }
    }

    public void PinOpenerButton1()
    {
        for (int i = 0; i < pinVariable.Length; i++) 
        {
            pinVariable[i] += pinOpener1[i];
        }
        Check();
    }

    public void PinOpenerButton2()
    {
        for (int i = 0; i < pinVariable.Length; i++)
        {
            pinVariable[i] += pinOpener2[i];
        }
        Check();
    }

    public void PinOpenerButton3()
    {
        for (int i = 0; i < pinVariable.Length; i++)
        {
            pinVariable[i] += pinOpener3[i];
        }
        Check();
    }

    public void Check()
    {
        mistake = 0;
        for (int i = 0; i < pinText.Length; i++)
        {
            pinText[i].text = pinVariable[i].ToString();

            if (pinAnswer[i] == pinVariable[i])
            {
                pinText[i].color = Color.green;

            }
            else
            {
                pinText[i].color = Color.white;
                mistake++;
            }
        }
        if(mistake == 0)
        {
            Victory();
        }
    }

    public void EndGame()
    {
        playWindow.SetActive(false);
        victoryWindow.SetActive(false);
        endGameWinow.SetActive(true);
    }

    public void Victory()
    {
        playWindow.SetActive(false);
        victoryWindow.SetActive(true);
        endGameWinow.SetActive(false);
    }

    public void Play()
    {

        for (int i = 0; i < pinVariable.Length; i++)
        {
            pinVariable[i] = startPinVariable[i];
        }

        currentTime = 0;

        playWindow.SetActive(true);
        victoryWindow.SetActive(false);
        endGameWinow.SetActive(false);

        
        Check();

    }


}
