using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private int _buttonCode = 0;
    private Cube _clickedCube = null;

    public event Action<Cube> CubeClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttonCode))
        {
            Raycast();
        }
    }

    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _clickedCube = hit.collider.GetComponent<Cube>();
        }

        if (_clickedCube != null)
        {
            CubeClick?.Invoke(_clickedCube);
        }
    }
}
