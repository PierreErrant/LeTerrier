using UnityEngine;

public class SetBoolEvent : MonoBehaviour
{
    [SerializeField] private string _boolName;
    [SerializeField] private bool _boolEvent;
    private bool _boolToToggle;
    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void sendBoolEvent()
    {
        _animator.SetBool(_boolName, _boolEvent);
    }

    public void toogleBoolEvent()
    {
        _boolToToggle = _animator.GetBool(_boolName);
        _animator.SetBool(_boolName, !_boolToToggle);
    }
    
}

