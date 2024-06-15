using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallsCounter : MonoBehaviour
{
    private int counter = 0;
    [SerializeField] private Text text;

    private void OnTriggerEnter(Collider other)
    {
        counter++;
        text.text = counter.ToString();
    }

    public void Reset()
    {
        counter = 0;
        text.text = counter.ToString();
    }
}
