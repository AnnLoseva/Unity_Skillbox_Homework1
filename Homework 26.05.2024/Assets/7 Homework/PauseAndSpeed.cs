using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndSpeed : MonoBehaviour
{
    public float speed = 1;


    public void PausePlay()
    {
        if (Time.timeScale == 0)
        {
            speed = 1;
            Time.timeScale = speed;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void FastOrNormalSpeed()
    {
        if (speed == 1)
        {
            speed = 2;

            Time.timeScale = speed;
        }
        else
        {
            speed = 1;

            Time.timeScale = speed;
        }
    }
}
