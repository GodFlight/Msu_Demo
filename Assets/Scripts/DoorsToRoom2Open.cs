using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsToRoom2Open : MonoBehaviour, IInteractionTarget
{
    [SerializeField] protected float secondsBeforeDoorsOpen;
    private Animator _animator;
    private bool _doorsOpened;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void HandleInteraction()
    {
        if (!_doorsOpened)
            StartCoroutine(nameof(OpenDoorsAfterSeconds));
    }

    public IEnumerator OpenDoorsAfterSeconds()
    {
        yield return new WaitForSeconds(secondsBeforeDoorsOpen);
        _animator.SetBool("DoorsOpened", true);
    }
}
