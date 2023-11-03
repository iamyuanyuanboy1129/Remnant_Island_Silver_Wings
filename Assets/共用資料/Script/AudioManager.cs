using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("聲音來源")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("聲音片段")]
    public AudioClip background;
    public AudioClip buttonClick;
    public AudioClip attackSound;
    public AudioClip correct;
    public AudioClip mistake;
    public AudioClip openChest;
    public AudioClip BossBattle;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void StopBG() 
    {
        musicSource.clip = background;
        musicSource.Stop();
    }
}
