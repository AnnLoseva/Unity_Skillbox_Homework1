using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challange6 : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] Text circleTimeText;
    [SerializeField] Text lastCircleTimeText;
    [SerializeField] Text differenceText;
    private float currentTime;
    private float currentCircleTime = 0f;
    private float lastCircleTime = 0f;
    private float difference;
    private bool start;

    void Update()
    {
        currentTime = Mathf.Round(Time.time);
        timerText.text = currentTime.ToString();

        if (start)
        {
            currentCircleTime += Time.deltaTime;
        }

    }

    public void LapsFinifhedButton()
    {
        Calculations();
        WriteResult();
        lastCircleTime = currentCircleTime;
        currentCircleTime = 0;


    }

    public void Calculations()
    {
        start = false;
        difference = currentCircleTime - lastCircleTime;
    }

    public void WriteResult()
    {
        lastCircleTimeText.text = ($"Прошлый: = {lastCircleTime.ToString()}");
        circleTimeText.text = ($"Нынешний: = {currentCircleTime.ToString()}");
        differenceText.text = ($"Разница: = {difference.ToString()}");
    }

    public void StartRun()
    {
        start = true;
    }



}


