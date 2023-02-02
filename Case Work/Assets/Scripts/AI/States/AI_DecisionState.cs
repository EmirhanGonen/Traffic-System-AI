using UnityEngine;
using UnityEngine.AI;

public class AI_DecisionState : AIState
{
    protected override string _animationKey { get => ANIMATION_KEY; set => Debug.Log("Cannot Set This Value"); }

    private const string ANIMATION_KEY = "Idle";

    [SerializeField] private float _randomMoveRadius = 40f;

    public override void OnStateEnter(params object[] parameters)
    {
        base.OnStateEnter(parameters); //Start Animation

        //Set Random Position

        Vector3 _tempTargetPoint = GetRandomPoint(_ai.transform.position , _randomMoveRadius);

        AI_WalkState walkState = _initializer.States[typeof(AI_WalkState)] as AI_WalkState;

        AI_WalkState.AIWalkVariables _tempVariables = new()
        {
            _targetPoint = _tempTargetPoint
        };

        _ai.SetState(walkState , _tempVariables);
    }


    public Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;

        NavMesh.SamplePosition(randomPos, out NavMeshHit hit, maxDistance, NavMesh.AllAreas);

        return hit.position;
    }

    public override void OnStateUpdate()
    {
    }
    public override void OnStateExit()
    {
    }
}