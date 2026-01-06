using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _force = 500;
    private float _radius = 5;

    public void Explode(Vector3 explodePosition, List<Rigidbody> explodableCubes)
    {
        foreach (Rigidbody explodableObject in explodableCubes)
        {
            explodableObject.AddExplosionForce(_force, explodePosition, _radius);
        }
    }
}
