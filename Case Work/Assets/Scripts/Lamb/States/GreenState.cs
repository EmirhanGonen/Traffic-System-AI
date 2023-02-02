using UnityEngine;
using System.Collections.Generic;

public class GreenState : LambState
{
    public override void OnLambChanged()
    {
        List<CarBehaviour> cars = _trafficLamb.InRangeCars;

        if (cars.Count == 0) return;

        for (int i = 0; i < cars.Count; i++)
        {
            MoveState _moveState = cars[i].GetCarStateInitializer().States[typeof(MoveState)] as MoveState;

            MoveState.MoveStateVariables _tempMoveVariables = new()
            {
                TargetPoint = cars[i].CurrentSelectedPath.transform.GetChild(cars[i].PathChildIndex).position,
                _MoveState = MoveStateEnum.Wander
            };

            cars[i].SetState(_moveState, _tempMoveVariables);
        }
    }   

    public override void OnStateEnter(params object[] parameters)
    {
        base.OnStateEnter(parameters);
    }

    public override void OnStateExit(params object[] parameters)
    {
        base.OnStateExit(parameters);
    }

    public override void OnStateUpdate(params object[] parameters)
    {
        base.OnStateUpdate(parameters);
    }
}