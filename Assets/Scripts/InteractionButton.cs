using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Serialization;

public class InteractionButton : MonoBehaviour, IInteractable
{
    [SerializeField] protected MonoBehaviour interactionTarget;
    private Animator _buttonAnimator;
    
    private HDAdditionalLightData _light;
    private bool _canBeActivated;
    private bool _deactivateLight;
    private bool _interactionDone = false;

    [SerializeField] protected float colorLerpEnableSpeed;
    [SerializeField] protected float colorLerpDisableSpeed;
    private float _lerpValue = 0;
    private float _baseLightIntensity;
    
    [SerializeField] protected float timeToNextInteraction;
    private float _prevTime;
    void Start()
    {
        _prevTime = Time.time;
        _light = GetComponentInChildren<HDAdditionalLightData>();
        _baseLightIntensity = _light.intensity;
        _light.intensity = 0f;
        _buttonAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(_light.intensity.ToString());
        if (_canBeActivated)
            ActivateLight();
        else if (_deactivateLight)
            DeactivateLight();
    }
    
    public void Interact()
    {
        float currTime = Time.time;
        if (currTime - _prevTime > timeToNextInteraction)
        {
            _interactionDone = !_interactionDone;
            (interactionTarget as IInteractionTarget)?.HandleInteraction();
            _buttonAnimator.SetTrigger("ButtonPressed");
            _prevTime = currTime;
        }
    }

    public void ShowUsability()
    {
        _canBeActivated = true;
    }
    
    private void ActivateLight()
    {
        _light.intensity = Mathf.Lerp(_light.intensity, _baseLightIntensity, _lerpValue);
        _lerpValue += Time.deltaTime * colorLerpEnableSpeed;
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
        _lerpValue += Time.deltaTime * colorLerpDisableSpeed;
        if (_lerpValue >= 1.0f)
        {
            _deactivateLight = false;
            _lerpValue = 0.0f;
        }
    }
}
