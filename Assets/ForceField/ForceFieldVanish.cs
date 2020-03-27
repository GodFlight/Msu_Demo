using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldVanish : MonoBehaviour, IInteractable
{
    [SerializeField] protected float vanishSpeed;

    private bool _isVanishing;
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Vanish Speed", vanishSpeed);
    }
    
    void Update()
    {
        if (_isVanishing)
        {
            _animator.SetTrigger("Vanish");
            _isVanishing = false;
        }
    }

    public void ShowUsability()
    {
        // TODO [rkeli] GUI message 
    }

    public void HideUsability() { }

    public void Interact()
    {
        _isVanishing = true;
    }
}
