using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1f;
    private float _explosionRadius = 1f;
    private float _explosionForce = 100f;

    public float SplitChance => _splitChance;
    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;
    public Vector3 Scale => transform.localScale;
    public Vector3 Position => transform.position;

    public void Initialize(float splitChance, float explosionRadius, float explosionForce, Vector3 scale)
    {
        _splitChance = splitChance;
        transform.localScale = scale;
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
    }
}
