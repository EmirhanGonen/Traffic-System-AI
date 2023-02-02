using UnityEngine;

public abstract class LambState : MonoBehaviour
{
    [SerializeField] protected LambState _nextState;

    [SerializeField] protected float _timeDuration;
    protected float _timer;

    protected GameObject _lamb;
    protected TrafficLamb _trafficLamb;

    private void Awake()
    {
        _trafficLamb = transform.parent.GetComponentInParent<TrafficLamb>();
        _lamb = transform.GetChild(0).gameObject;
    }
    public virtual void OnStateEnter(params object[] parameters)
    {
        _lamb.SetActive(true);
        OnLambChanged();
    }
    public virtual void OnStateUpdate(params object[] parameters)
    {
        _timer += Time.deltaTime;

        if (_timer < _timeDuration) return;

        _trafficLamb.SetState(_nextState);
    }
    public virtual void OnStateExit(params object[] parameters)
    {
        _timer = 0.00f;
        _lamb.SetActive(false);
    }

    public abstract void OnLambChanged();
}