using UnityEngine;
using System.Collections;

public class MoveState : CarState
{
    [System.Serializable]
    public class MoveStateVariables
    {
        public Vector3 TargetPoint;

        public MoveStateEnum _MoveState = MoveStateEnum.Wander;
    }

    private MoveStateVariables _currentVariables;


    [SerializeField] private float _moveSpeed = 10f;
    private bool _canLookAtMovePoint = true;

    public override void OnStateEnter(params object[] parameters)
    {
        _currentVariables = parameters[0] as MoveStateVariables;

        switch (_currentVariables._MoveState)
        {
            case MoveStateEnum.Wander: _canLookAtMovePoint = true; break;
            case MoveStateEnum.MoveLamb: _canLookAtMovePoint = false; break;
            case MoveStateEnum.CarDetected: _canLookAtMovePoint = false; break;
        }

    }
    public override void OnStateUpdate(params object[] parameters)
    {
        if (Vector3.Distance(_carBehaviour.transform.position, _currentVariables.TargetPoint) >= 0.10f)
        {
            _carBehaviour.transform.position = Vector3.MoveTowards(_carBehaviour.transform.position, _currentVariables.TargetPoint, _moveSpeed * Time.deltaTime);
            if (_canLookAtMovePoint) _carBehaviour.transform.LookAt(_currentVariables.TargetPoint);

            return;
        }

        if (_currentVariables._MoveState == MoveStateEnum.CarDetected)
        {
            CarDetectedState _carDetectedState = _carStateInitializer.States[typeof(CarDetectedState)] as CarDetectedState;
            _carBehaviour.SetState(_carDetectedState);
            return;
        } 
        //Car Detectiondaysak ve geri gittiysek tekrardan cardetected statesine atýyorumki kontrol etsin

        if (_currentVariables._MoveState == MoveStateEnum.MoveLamb) return;
        //Lamba için bekliyorsa beklediði konuma varýr varmaz hareket etmicek yeþil ýþýk yanýnca hareket edicek

        ReachState _reachState = _carStateInitializer.States[typeof(ReachState)] as ReachState;

        MoveStateEnum _tempEnum = _currentVariables._MoveState;

        bool increasePathIndex = _tempEnum == MoveStateEnum.Wander;

        _carBehaviour.SetState(_reachState, increasePathIndex);
    }
    public override void OnStateExit(params object[] parameters)
    {
        StopAllCoroutines();
        _currentVariables = null;
    }
}
public enum MoveStateEnum
{
    Wander,
    MoveLamb,
    CarDetected
}