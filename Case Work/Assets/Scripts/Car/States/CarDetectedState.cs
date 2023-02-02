using UnityEngine;

public class CarDetectedState : CarState
{
    [SerializeField] private LayerMask _layerMask;

    private readonly float _raycastDistance = 3f;

    private MoveState _moveState;

    public override void OnStateEnter(params object[] parameters)
    {
        _moveState = _carStateInitializer.States[typeof(MoveState)] as MoveState;
    }

    public override void OnStateUpdate(params object[] parameters)
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit _raycastHit, _raycastDistance, _layerMask);

        Debug.DrawRay(transform.position, transform.forward * _raycastDistance, Color.black);

        //arabalar cok olunca 3 lü kitlenmede herkes arkaya gitmektense bi kontrol ederler arkalarýnda boþluk varmý varsa arkaya giderler
        if (_raycastHit.collider)
        {
            float multiply = Random.Range(1f, 3f);


            MoveState.MoveStateVariables _tempMoveStateVariables = new()
            {
                TargetPoint = _carBehaviour.transform.position + (-transform.forward * multiply),
                _MoveState = MoveStateEnum.CarDetected
            };

            _carBehaviour.SetState(_moveState, _tempMoveStateVariables);

            return;
        }

        //Araba ile temastan çýktýysa

        MoveState.MoveStateVariables _tempMoveStateVariabless = new()
        {
            TargetPoint = _carBehaviour.CurrentSelectedPath.transform.GetChild(_carBehaviour.PathChildIndex).position,
            _MoveState = MoveStateEnum.Wander
        };

        _carBehaviour.SetState(_moveState, _tempMoveStateVariabless);
    }

    public override void OnStateExit(params object[] parameters)
    {

    }
}