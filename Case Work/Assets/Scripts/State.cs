using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void OnStateEnter(params object[] parameters);
    public abstract void OnStateUpdate(params object[] parameters);
    public abstract void OnStateExit(params object[] parameters);

}