using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class CoinFlipper : MonoBehaviour
{
    private Animator coinAnimator;
    private bool skullCoin;

    void Start()
    {
        coinAnimator = GetComponent<Animator>();
    }

    public void RandomEndOfFlip()
    {
        skullCoin = GetRandomBool();

        coinAnimator.SetBool("skull" ,skullCoin);
        coinAnimator.SetBool("start", false);
    }

    public void StartFlip() 
    {
        coinAnimator.SetBool("start", true);
    }

    private bool GetRandomBool()
    {
        System.Random random = new System.Random();
        return random.Next(2) == 1; // ���������� ��������� ����� 0 ��� 1 � ���������� true, ���� ��� ����� 1, ����� false
    }

}
