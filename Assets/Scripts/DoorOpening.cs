using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour, IInteractionTarget
{
    private Animator _animator;
    private bool _doorOpened = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void HandleInteraction()
    {
        _doorOpened = !_doorOpened;
        _animator.SetBool("OpenDoor", _doorOpened);
    }
}
