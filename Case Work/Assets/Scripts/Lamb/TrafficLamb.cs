using UnityEngine;
using System.Collections.Generic;

public class TrafficLamb : MonoBehaviour
{
    [SerializeField] private LambState _currentState;

    //public List<>
    public List<CarBehaviour> InRangeCars = new();


    private void Start() => _currentState.OnStateEnter();
    private void Update() => _currentState.OnStateUpdate();

    public void SetState(LambState nextState)
    {
        _currentState.OnStateExit();

        _currentState = nextState;

        _currentState.OnStateEnter();
    }
}