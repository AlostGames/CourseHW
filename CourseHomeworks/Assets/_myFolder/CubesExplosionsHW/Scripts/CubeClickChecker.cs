using System;
using UnityEngine;

public class CubeClickChecker : MonoBehaviour
{
    public event Action Click;

    private void OnMouseDown()
    {
        Click?.Invoke();
    }
}
