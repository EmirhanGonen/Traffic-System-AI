using UnityEngine;
using UnityEngine.AI;

public class CarBehaviour : MonoBehaviour
{
    [SerializeField] private State _currentState;

    public GameObject CurrentSelectedPath { get => _currentSelectedPath; set => _currentSelectedPath = value; }
    [SerializeField] private GameObject _currentSelectedPath;

    private CarStateInitializer _carStateInitializer;
    public CarStateInitializer GetCarStateInitializer() => _carStateInitializer;

    public int PathChildIndex
    {
        get => _pathChildIndex;
        set
        {
            _pathChildIndex = value;
            _pathChildIndex = Mathf.Clamp(_pathChildIndex, 0, _currentSelectedPath.transform.childCount);
        }
    }
    private int _pathChildIndex;


    private void Awake()
    {
        _carStateInitializer = GetComponentInChildren<CarStateInitializer>();
    }
    private void Start()
    {
        _currentState.OnStateEnter();
    }
    private void Update()
    {
        _currentState.OnStateUpdate();
    }

    public void SetState(State nextState, params object[] parameters)
    {
        _currentState.OnStateExit();

        _currentState = nextState;

        _currentState.OnStateEnter(parameters);
    }
}