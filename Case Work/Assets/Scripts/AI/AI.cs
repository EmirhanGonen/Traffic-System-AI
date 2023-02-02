using UnityEngine;

public class AI : MonoBehaviour
{
    private AIState _currentState;

    public void SetState(AIState nextState, params object[] parameters)
    {
        _currentState.OnStateExit();

        _currentState = nextState;

        _currentState.OnStateEnter(parameters);
    }

    private void Start()
    {
        _currentState = GetComponentInChildren<AIState_Initializer>().States[typeof(AI_DecisionState)] as AI_DecisionState;
        _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState) _currentState.OnStateUpdate();
    }
}