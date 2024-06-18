using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBlink : MonoBehaviour
{
    [SerializeField] private float blinkBrightness = 2f;
    [SerializeField] private float normalBrightness = 0.5f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private bool audioOn;
    private Material material;

    private void Start()
    {
        Renderer render = GetComponent<Renderer>();
        material = render.material;
        material.EnableKeyword("_EMISSION");
        if (audioSource != null)
        {
            audioSource.clip = audioClip;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Color emissionColor = material.color * blinkBrightness;
        material.SetColor("_EmissionColor",emissionColor);
        if (audioSource != null)
        {
            if (!audioOn)
            {
                audioSource.Play();
                audioOn = true;
                
            }
        }

    }

    private void OnCollisionExit(Collision collision) 
    {
        Color emissionColor = material.color * normalBrightness;

        material.SetColor("_EmissionColor", emissionColor);
        audioOn = false;
    }
    }
