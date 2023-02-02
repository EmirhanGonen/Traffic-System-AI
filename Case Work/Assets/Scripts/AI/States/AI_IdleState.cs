using UnityEngine;

public class AI_IdleState : AIState
{
    protected override string AnimationKey { get => ANIMATION_KEY; set => Debug.Log("Cannot Set This Value"); }

    private const string ANIMATION_KEY = "Idle";

    private float _timeDuration;
    private float _elapsedTime = 0.00f;

    public override void OnStateEnter(params object[] parameters)
    {
        base.OnStateEnter(parameters); //Starting Animation;
        _timeDuration = GetRandomTimeDuration(3, 6);
    }
    public override void OnStateExit()
    {
        _elapsedTime = 0.00f;
    }
    public override void OnStateUpdate()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime < _timeDuration) return;

        AI_DecisionState _decisionState = _initializer.States[typeof(AI_DecisionState)] as AI_DecisionState;
        _ai.SetState(_decisionState);
    }

    private float GetRandomTimeDuration(float minInclusive, float maxInclusive) => Random.Range(minInclusive, maxInclusive);
}