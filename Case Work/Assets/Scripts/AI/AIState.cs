using UnityEngine;

public abstract class AIState : MonoBehaviour
{
    protected AI _ai;
    protected AIState_Initializer _initializer;

    protected abstract string _animationKey { get; set; }
    protected Animator _animator;

    private void Awake()
    {
        _animator = transform.parent.GetComponentInParent<Animator>();
        _ai = transform.parent.GetComponentInParent<AI>();  
        _initializer = GetComponentInParent<AIState_Initializer>();
    }

    public virtual void OnStateEnter(params object[] parameters)
    {
        int _animationHash = Animator.StringToHash(_animationKey);
        _animator.Play(_animationHash);
    }

    public abstract void OnStateUpdate();

    public abstract void OnStateExit();
}