using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _force = 500;
    private float _radius = 5;

    public void Explode(Vector3 explodePosition, List<GameObject> _explodableCubes)
    {
        foreach (GameObject explodableObject in _explodableCubes)
        {
            explodableObject.GetComponent<Rigidbody>().
                AddExplosionForce(_force, explodePosition, _radius);
        }
    }
}
