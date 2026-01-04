using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1f;

    public event Action<Cube> Death;

    public float SplitChance => _splitChance;
    public Vector3 Scale => transform.localScale;
    public Vector3 Position => transform.position;

    public void Destroy()
    {
        Death?.Invoke(this);
    }

    public void Initialize(float splitChance, Vector3 scale)
    {
        _splitChance = splitChance;
        transform.localScale = scale;
    }
}
