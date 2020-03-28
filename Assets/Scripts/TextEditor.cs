
using UnityEngine;
using TMPro;

public class TextEditor : MonoBehaviour, IInteractable
{
    [SerializeField] protected float timeToNextInteraction;
    [SerializeField] private GameObject _textObj;
    private TextMeshProUGUI text;

    private bool _interactVisisble;
    private float _prevTime;

    public void Interact()
    {
        float currTime = Time.time;
        
        if (currTime - _prevTime < timeToNextInteraction)
            return;
        _prevTime = currTime;
    }

    public void ShowUsability()
    {
        _interactVisisble = true;
    }

    public void HideUsability()
    {
        _interactVisisble = false;
    }
    void Start()
    {
        _interactVisisble = false;
        _prevTime = Time.time; 
        text = _textObj.GetComponent<TextMeshProUGUI>();
        text.alpha = 0f;
    }

    void Update()
    {
        //text.text = "Hello";
        if (_interactVisisble && text.alpha < 1f)
            text.alpha += 0.05f;
        else if (!_interactVisisble && text.alpha > 0f)
            text.alpha -= 0.05f;
    }
}
