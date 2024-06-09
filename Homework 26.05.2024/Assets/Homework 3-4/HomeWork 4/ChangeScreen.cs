using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour
{

    [SerializeField] private GameObject firstScreen;

    private GameObject currentScreen;
    void Start()
    {
        firstScreen.SetActive(true);
        currentScreen = firstScreen;
    }
    public void ChangeState(GameObject state)
    {
        if(state != null && currentScreen != null) 
        {
            currentScreen.SetActive(false);
            state.SetActive(true);
            currentScreen = state;
        }
    }

}
