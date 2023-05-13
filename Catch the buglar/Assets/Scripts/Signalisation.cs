using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Signalisation : MonoBehaviour
{


    private AudioSource _audioSource;
    private AudioClip _audioClip;
    private float _fadeTime = 1.0f;

    private float _maxVolume = 1.0f;
    private float _currentVolume = 0f;
    private bool _isBuglarInside;

    public float MaxVolume { get { return _maxVolume;} }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
        _audioClip = GetComponent<AudioClip>();
    }

    private void Update()
    {

    }

    public void PlaySound(float maxVolume)
    {
        _currentVolume = Mathf.MoveTowards(_currentVolume, maxVolume, Time.deltaTime / _fadeTime);
        _audioSource.volume = _currentVolume;
    }

}
