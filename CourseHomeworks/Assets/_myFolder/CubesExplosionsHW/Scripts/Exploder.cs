using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _scatterForce = 500;
    private float _scatterRadius = 5;

    public void Scatter(Vector3 scatterPosition, List<Rigidbody> scatteredCubes)
    {
        foreach (Rigidbody scatteredObject in scatteredCubes)
        {
            scatteredObject.AddExplosionForce(_scatterForce, scatterPosition, _scatterRadius);
        }
    }

    public void Explode(Vector3 explosionPosition, float explosionRadius, float explosionForce)
    {
        foreach (Rigidbody explodableObject in FindExploadableObjects(explosionPosition, explosionRadius))
        {
            explodableObject.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
        }
    }

    private List<Rigidbody> FindExploadableObjects(Vector3 center, float radius)
    {
        List<Rigidbody> exploadableObjects = new List<Rigidbody>();

        Collider[] colliders = Physics.OverlapSphere(center, radius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                exploadableObjects.Add(rigidbody);
            }
        }

        return exploadableObjects;
    }
}