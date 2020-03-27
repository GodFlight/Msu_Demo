using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class InteractionButton : MonoBehaviour, IInteractable
{
    [SerializeField] protected MonoBehaviour interactionTarget;
    private Animator _buttonAnimator;

    [SerializeField] protected float lightEnableSpeed;
    [SerializeField] protected float lightDisableSpeed;

    [SerializeField] protected float timeToNextInteraction;
    private float _prevTime;
    void Start()
    {
        _prevTime = Time.time;
        _buttonAnimator = GetComponent<Animator>();
    }

    public void Interact()
    {
        float currTime = Time.time;
        
        if (currTime - _prevTime < timeToNextInteraction)
            return;
        (interactionTarget as IInteractionTarget)?.HandleInteraction();
        _buttonAnimator.SetTrigger("ButtonPressed");
        _prevTime = currTime;
    }

    public void ShowUsability()
    {
        _buttonAnimator.SetBool("Button Visiable", true);
    }

    public void HideUsability()
    {
        _buttonAnimator.SetBool("Button Visiable", false);
    }
}
