using UnityEngine;
using System.Collections.Generic;

public class RedState : LambState
{
    private float _beginX, _beginZ;
    [SerializeField] private float distanceX, distanceZ;

    private Transform _firstPoint;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawCube(new(_beginX, 0, _beginZ), Vector3.one);
    }
    public override void OnStateEnter(params object[] parameters)
    {
        //ranndom f timeDuration

        //beginX = transform.position.x - (-2.5f);
        _firstPoint = transform.GetChild(1).transform;
        _beginX = _firstPoint.position.x;
        _beginZ = _firstPoint.position.z;

        //_beginX = transform.parent.parent.position.x > 0 ? transform.parent.parent.position.x + -2.5f : transform.parent.parent.position.x - (-2.5f);
        //_beginZ = transform.parent.position.z;

        base.OnStateEnter(parameters);
    }
    public override void OnStateUpdate(params object[] parameters)
    {
        base.OnStateUpdate(parameters);
    }
    public override void OnStateExit(params object[] parameters)
    {
        base.OnStateExit(parameters);
    }


    [ContextMenu("Deneme")]
    public override void OnLambChanged()
    {
        List<CarBehaviour> cars = _trafficLamb.InRangeCars;

        if (cars.Count == 0) return;

        float x = 0, z = 0;

        for (int i = 0; i < cars.Count; i++)
        {
            MoveState _moveState = cars[i].GetCarStateInitializer().States[typeof(MoveState)] as MoveState;

            /*mod = i % 2;
            z += i > 1 & mod == 0 ? distanceZ : 0;
            x = mod * distanceX;*/

            x += transform.rotation.y == 180 ? (i > 0 ? -5 : 0) : 0;
            z += transform.rotation.y == 90 ? (i > 0 ? -5 : 0) : 0;

            Vector3 movePoint = new(_beginX + x, cars[i].transform.position.y, _beginZ + z);

            MoveState.MoveStateVariables _tempMoveStateVariables = new()
            {
                TargetPoint = movePoint,
                _MoveState = MoveStateEnum.MoveLamb
            };

            cars[i].SetState(_moveState, _tempMoveStateVariables);
        }
    }
}