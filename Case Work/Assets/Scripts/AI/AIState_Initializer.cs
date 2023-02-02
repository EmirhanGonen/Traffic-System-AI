using System.Collections.Generic;
using UnityEngine;

public class AIState_Initializer : MonoBehaviour
{
    private Dictionary<System.Type, AIState> _states;

    public Dictionary<System.Type, AIState> States { get => _states; }

    private void Awake() => Initialize();
    private void Initialize()
    {
        if (_states == null) _states = new(); else _states.Clear();

        foreach (AIState state in GetComponentsInChildren<AIState>())
        {
            if (_states.ContainsKey(state.GetType())) return;

            _states.Add(state.GetType() , state);
        }
    }
}