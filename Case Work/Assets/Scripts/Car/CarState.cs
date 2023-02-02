using UnityEngine;
using UnityEngine.AI;

public abstract class CarState : State
{
    protected CarBehaviour _carBehaviour;
    protected CarStateInitializer _carStateInitializer;
 
    private void Awake()
    {
        _carBehaviour = transform.parent.GetComponentInParent<CarBehaviour>();
        _carStateInitializer = GetComponentInParent<CarStateInitializer>();
    }
}