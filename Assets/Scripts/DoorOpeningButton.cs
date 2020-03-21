using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DoorOpeningButton : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator doorAnimator;
    private Light _light;
    private bool _canBeActivated;
    private bool _deactivateLight;

    [SerializeField] private float colorLerpSpeed;
    private float _lerpValue = 0;

    void Start()
    {
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
