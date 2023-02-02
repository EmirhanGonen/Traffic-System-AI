using UnityEngine;
using System.Collections.Generic;

public class CarStateInitializer : MonoBehaviour
{
    public Dictionary<System.Type, State> States { get; private set; }

    private void Awake() => Initialize();

    private void Initialize()
    {
        if (States == null) States = new(); else States.Clear();

        foreach (CarState state in GetComponentsInChildren<CarState>())
        {
            if (States.ContainsKey(state.GetType())) continue;

            States.Add(state.GetType(), state);
        }
    }
}