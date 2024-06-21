using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;
using Unity.VisualScripting;
using UnityEditor.Rendering;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private Texture[] texture;
    private Animator animator;
    private bool isHitting;
    private Material[] material;

    void Start()
    {
        
        animator = GetComponent<Animator>();
        Renderer[] renderer = GetComponentsInChildren<Renderer>();
        material = new Material[renderer.Length];

        for (int i = 0; i < material.Length; i++)
        {
            material[i] = renderer[i].material;
        }

    }

    public void RandomEnd()
    {
        isHitting = GetRandomBool();


        Random rnd = new Random();
        int textureIndex = rnd.Next(0, material.Length);

        foreach (var material in material)
        {
            material.mainTexture = texture[textureIndex];
        }

        animator.SetBool("isHitting", isHitting);
        animator.SetBool("start", false);
    }

    public void StartAction()
    {
        animator.SetBool("start", true);
    }

    private bool GetRandomBool()
    {
        System.Random random = new System.Random();
        return random.Next(2) == 1; // ���������� ��������� ����� 0 ��� 1 � ���������� true, ���� ��� ����� 1, ����� false
    }

}
