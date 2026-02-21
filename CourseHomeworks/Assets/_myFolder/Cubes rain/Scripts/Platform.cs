using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Action<Cube> TouchingCube;

    private void OnCollisionEnter(Collision collision)
    {
        Cube cube = collision.gameObject.GetComponent<Cube>();

        if (cube != null)
            TouchingCube?.Invoke(cube);
    }
}
