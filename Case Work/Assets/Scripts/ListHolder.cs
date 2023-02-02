using UnityEngine;
using System.Collections.Generic;

public class ListHolder : MonoBehaviour
{
    #region Singleton
    public static ListHolder Instance { get; private set; }
    private void Awake() => Instance = this;

    #endregion
    #region Lists

    public List<GameObject> Paths;
    public int PathsCount => Paths.Count;

    #endregion
}