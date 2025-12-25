using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1f;

    public event Action Activation;

    public float SplitChance => _splitChance;
    public Vector3 Scale => transform.localScale;

    public void Activate()
    {
        Activation?.Invoke();

        Destroy(gameObject);
    }

    public void Initialize(float splitChance, Vector3 scale)
    {
        _splitChance = splitChance;
        transform.localScale = scale;
    }
}
