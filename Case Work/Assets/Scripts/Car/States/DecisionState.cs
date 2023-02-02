using UnityEngine;

public class DecisionState : CarState
{

    public override void OnStateEnter(params object[] parameters)
    {
        //Oyun baþlayýnca arabalar direk seçtiði pathin ilk childýna ýþýnlandýðý için iç içe oluyorlar ve bug oluyor
        _carBehaviour.CurrentSelectedPath = null;


        ListHolder _listHolder = ListHolder.Instance;
        GameObject randomPath = _listHolder.Paths[Random.Range(0, _listHolder.PathsCount)];

        _carBehaviour.CurrentSelectedPath = randomPath;
        _carBehaviour.PathChildIndex = 0;
        

        Invoke(nameof(Decide), Random.Range(0f, 5f));
    }

    private void Decide()
    {
        _carBehaviour.transform.position = _carBehaviour.CurrentSelectedPath.transform.GetChild(_carBehaviour.PathChildIndex).position;

        MoveState _moveState = _carStateInitializer.States[typeof(MoveState)] as MoveState;

        MoveState.MoveStateVariables _moveStateVariables = new()
        {
            TargetPoint = _carBehaviour.CurrentSelectedPath.transform.GetChild(_carBehaviour.PathChildIndex).position,
            _MoveState = MoveStateEnum.Wander
        };

        _carBehaviour.SetState(_moveState, _moveStateVariables);

    }

    public override void OnStateExit(params object[] parameters)
    {

    }
    public override void OnStateUpdate(params object[] parameters)
    {

    }
}