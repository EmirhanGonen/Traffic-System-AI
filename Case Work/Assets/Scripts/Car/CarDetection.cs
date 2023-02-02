using UnityEngine;

public class CarDetection : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    private readonly float _raycastDistance = 3f;
    private CarBehaviour _carBehaviour;

    private void Awake()
    {
        _carBehaviour = GetComponentInParent<CarBehaviour>();
    }

    private void Update()
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit _raycastHit, _raycastDistance, _layerMask);

        Debug.DrawRay(transform.position, transform.forward * _raycastDistance, Color.red);

        if (!_raycastHit.collider) return;


        CarDetectedState _carDetectedState = _carBehaviour.GetCarStateInitializer().States[typeof(CarDetectedState)] as CarDetectedState;

        _carBehaviour.SetState(_carDetectedState);
    }
}