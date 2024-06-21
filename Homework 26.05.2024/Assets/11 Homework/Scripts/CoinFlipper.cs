using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;
using Unity.VisualScripting;
using UnityEditor.Rendering;

public class CoinFlipper : MonoBehaviour
{
    [SerializeField] private Texture[] texture;
    [SerializeField] private AudioClip[] sounds;
    private Animator coinAnimator;
    private AudioSource audioSource;
    private bool skullCoin;
    private Material material;

    void Start()
    {
        coinAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;
       
    }

    public void FlipSound()
    {
        Random rnd = new Random();
        int clipIndex = rnd.Next(0, sounds.Length);
        audioSource.clip = sounds[clipIndex];
        audioSource.Play();
    }

    public void RandomEndOfFlip()
    {
        skullCoin = GetRandomBool();


        Random rnd = new Random();
        int textureIndex = rnd.Next(0, texture.Length);
        material.mainTexture = texture[textureIndex];

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
        return random.Next(2) == 1; // Генерируем случайное число 0 или 1 и возвращаем true, если оно равно 1, иначе false
    }

}
