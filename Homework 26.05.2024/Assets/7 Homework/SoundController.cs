using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioSource speechSource;
    [SerializeField] private AudioSource ambienceSource;

    [Header("Sliders")]
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider effectsVolume;
    [SerializeField] private Slider speechVolume;
    [SerializeField] private Slider ambienceVolume;

    private bool musicOn = true;
    private bool effectsOn = true;
    private bool speechOn = true;
    private bool ambienceOn = true;
    private bool muteOn = false;

    public void MusicMute()
    {
        if (musicSource.mute)
        {
            musicSource.mute = false;
            musicOn = true;
        }
        else
        {
            musicSource.mute = true;
            musicOn = false;
        }
    }

    public void EffectMute()
    {
        if (effectsSource.mute)
        {
            effectsSource.mute = false;
            effectsOn = true;
        }
        else
        {
            effectsSource.mute = true;
            effectsOn = false;
        }
    }

    public void SpeechMute()
    {
        if (speechSource.mute)
        {
            speechSource.mute = false;
            speechOn = true;
        }
        else
        {
            speechSource.mute = true;
            speechOn = false;
        }
    }

    public void AmbienceMute()
    {
        if (ambienceSource.mute)
        {
            ambienceSource.mute = false;
            ambienceOn = true;
        }
        else
        {
            ambienceSource.mute = true;
            ambienceOn = false;
        }
    }

    public void MuteAll()
    {
        if (!muteOn) 
        {
            speechSource.mute = true;
            musicSource.mute = true;
            effectsSource.mute = true;
            ambienceSource.mute = true;
            muteOn = true;
        }
        else 
        {
            speechSource.mute = !speechOn;
            effectsSource.mute = !effectsOn;
            musicSource.mute = !musicOn;
            ambienceSource.mute = !ambienceOn;
            muteOn = false;
        }
    }

    public void Volume()
    {
        musicSource.volume = musicVolume.value;
        effectsSource.volume = musicVolume.value;
        speechSource.volume = speechVolume.value;
        ambienceSource.volume = ambienceVolume.value;
    }
}