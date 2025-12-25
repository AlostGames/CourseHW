using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _force = 500;
    private float _radius = 5;

    public void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_force, transform.position, _radius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
