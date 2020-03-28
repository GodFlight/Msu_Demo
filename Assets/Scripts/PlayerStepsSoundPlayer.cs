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
        _audioSource = GetComponentInChildren<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Debug.Log(_rigidbody.velocity.ToString());
        // Debug.Log(_audioSource.isPlaying.ToString());
        if (_rigidbody.velocity != Vector3.zero && !_audioSource.isPlaying)
        {
            _audioSource.Play();
            // Debug.Log("playing steps sound!");
        }
        else if (_rigidbody.velocity != Vector3.zero && _audioSource.isPlaying)
            _audioSource.Stop();
    }
}
