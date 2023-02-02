using UnityEngine;

public class ReachState : CarState
{

    public override void OnStateEnter(params object[] parameters)
    {
        //Path Secme burda olabilir yada decisionstate
        bool canIncreaseIndex = true;

        if (parameters.Length > 0) canIncreaseIndex = (bool)parameters[0];

        _carBehaviour.PathChildIndex += canIncreaseIndex ? 1 : 0;

        //Stateye girdiði zaman direk çýkýcak çünkü þuanlýk hedefine varýnca bi amacý olmuyacak direk diðer hedefe hareket edicek;
        if (_carBehaviour.PathChildIndex == _carBehaviour.CurrentSelectedPath.transform.childCount)
        {
            DecisionState _decisionState = _carBehaviour.GetCarStateInitializer().States[typeof(DecisionState)] as DecisionState;

            _carBehaviour.SetState(_decisionState);

            return;
        }

        MoveStateEnum _tempEnum = canIncreaseIndex ? MoveStateEnum.Wander : MoveStateEnum.CarDetected;


        MoveState.MoveStateVariables _moveStateVariables = new()
        {
            TargetPoint = _carBehaviour.CurrentSelectedPath.transform.GetChild(_carBehaviour.PathChildIndex).position,
            _MoveState = _tempEnum
        };

        MoveState _moveState = _carStateInitializer.States[typeof(MoveState)] as MoveState;

        _carBehaviour.SetState(_moveState, _moveStateVariables);
    }

    public override void OnStateUpdate(params object[] parameters)
    {

    }

    public override void OnStateExit(params object[] parameters)
    {

    }
}