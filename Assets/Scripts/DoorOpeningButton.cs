using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DoorOpeningButton : MonoBehaviour, IInteractable
{
    [SerializeField] protected Animator doorAnimator;
    
    private Light _light;
    private bool _canBeActivated;
    private bool _deactivateLight;
    private bool _doorOpened = false;

    [SerializeField] protected float colorLerpSpeed;
    private float _lerpValue = 0;

    [SerializeField] protected float timeToNextDoorInteraction;
    private float _prevTime;
    void Start()
    {
        _prevTime = Time.time;
        _light = GetComponentInChildren<Light>();
    }

    private void Update()
    {
        if (_canBeActivated)
            ActivateLight();
        else if (_deactivateLight)
            DeactivateLight();
    }
    
    public void Interact()
    {
        float currTime = Time.time;
        if (currTime - _prevTime > timeToNextDoorInteraction)
        {
            _doorOpened = !_doorOpened;
            doorAnimator.SetBool("OpenDoor", _doorOpened);
            _prevTime = currTime;
        }
    }

    public void ShowUsability()
    {
        _canBeActivated = true;
    }
    
    private void ActivateLight()
    {
        _light.intensity = Mathf.Lerp(_light.intensity, 1.0f, _lerpValue);
        _lerpValue += Time.deltaTime * colorLerpSpeed;
        if (_lerpValue >= 1.0f)
        {
            _lerpValue = 0.0f;
            _canBeActivated = false;
            _deactivateLight = true;
        }
    }
    
    private void DeactivateLight()
    {
        _light.intensity = Mathf.Lerp(_light.intensity, 0.0f, _lerpValue);
        _lerpValue += Time.deltaTime * colorLerpSpeed;
        if (_lerpValue >= 1.0f)
        {
            _deactivateLight = false;
            _lerpValue = 0.0f;
        }
    }
}
