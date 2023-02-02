using UnityEngine;
using UnityEngine.AI;

public class AI_WalkState : AIState
{
    [System.Serializable]
    public class AIWalkVariables
    {
        public Vector3 _targetPoint;
    }

    protected override string _animationKey { get => ANIMATION_NAME; set => Debug.Log("Cannot Set This Value"); }

    private const string ANIMATION_NAME = "Walk";


    private NavMeshAgent _navMeshAgent;
    private Vector3 _targetPoint;

    public override void OnStateEnter(params object[] parameters)
    {
        _navMeshAgent = _ai.GetComponent<NavMeshAgent>();
        _navMeshAgent.enabled = true;

        base.OnStateEnter(parameters); // Start Animation



        _targetPoint = (parameters[0] as AIWalkVariables)._targetPoint;

        _navMeshAgent.SetDestination(_targetPoint);
    }

    public override void OnStateExit()
    {
        _navMeshAgent.Warp(_ai.transform.position);
        _navMeshAgent.enabled = false;
    }

    public override void OnStateUpdate()
    {
        if (!IsReach()) return;

        AI_IdleState idleState = _initializer.States[typeof(AI_IdleState)] as AI_IdleState; ;

        _ai.SetState(idleState);
    }
    private bool IsReach() => _navMeshAgent.remainingDistance < 0.20f;
}