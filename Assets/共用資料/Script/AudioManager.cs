﻿using System;
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
    public AudioClip holyAttackSound;
    public AudioClip correct;
    public AudioClip mistake;
    public AudioClip openChest;
    public AudioClip BossBattle;
    public AudioClip mechineStart;
    public AudioClip jump;
    public AudioClip buttonStart;
    public AudioClip damage;
    public AudioClip death;

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
