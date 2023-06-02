using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Signalisation : MonoBehaviour
{
    [SerializeField] private Floor _floor;
    private AudioSource _signalSource;
    private float _speedChageSound = 0.2f;
    private Coroutine _coroutine;

    private readonly float _maxVolume = 1;
    private readonly float _minVolume = 0;

    private void Awake()
    {
        _signalSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _floor.StateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        _floor.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged(bool isIndide)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(VolumeChange(isIndide? _maxVolume: _minVolume));
    }

    private IEnumerator VolumeChange(float targetValue)
    {
        while(_signalSource.volume != targetValue)
        {
            _signalSource.volume = Mathf.MoveTowards(_signalSource.volume, targetValue, _speedChageSound * Time.deltaTime);
            yield return null;
        }
    }
}
