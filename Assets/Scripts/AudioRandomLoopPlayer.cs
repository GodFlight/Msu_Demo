using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class AudioRandomLoopPlayer : MonoBehaviour
{
    [SerializeField] protected float minDelay;
    [SerializeField] protected float maxDelay;

    private float _waitTime;
    
    private AudioSource _audioSource;
    private float _soundDuration;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(nameof(PlaySound));
        _soundDuration = _audioSource.clip.length;
    }

    void RandomTime()
    {
        _waitTime = Random.Range(minDelay, maxDelay);
        StartCoroutine(nameof(PlaySound));
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(_waitTime);
        if (!_audioSource.isPlaying)
        {
            _audioSource.volume = 1;
            _audioSource.Play();
        }
        RandomTime();
    }

    private void Update()
    {
        if (_audioSource.isPlaying)
            _audioSource.volume -= Time.deltaTime / _soundDuration;
    }
}
