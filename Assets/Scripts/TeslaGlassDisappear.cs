using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Timers;
using UnityEngine;

public class TeslaGlassDisappear : MonoBehaviour, IInteractionTarget
{
    [Range(0.1f, 10f)] [SerializeField]
    protected float enlightDuration;
    [Range(0.1f, 10f)] [SerializeField]
    protected float disappearDuration;

    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Enlight Duration", 1 / enlightDuration);
        _animator.SetFloat("Disappear Duration", 1 / disappearDuration);
        // use (1 / n) because in animator it is playback speed, so bigger value -> smaller duration
    }
    public void HandleInteraction()
    {
        _animator.SetTrigger("Start Animation");
    }
}
