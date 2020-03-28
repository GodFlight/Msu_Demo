using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerStepsSoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponentInParent<Rigidbody>();
        _audioSource.Play();
        _audioSource.Pause();
    }

    private void Update()
    {
        if (_rigidbody.velocity != Vector3.zero && !_audioSource.isPlaying)
            _audioSource.UnPause();
        else if (_rigidbody.velocity == Vector3.zero && _audioSource.isPlaying)
            _audioSource.Pause();
    }
}
