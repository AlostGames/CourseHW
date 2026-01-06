using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1f;

    public float SplitChance => _splitChance;
    public Vector3 Scale => transform.localScale;
    public Vector3 Position => transform.position;

    public void Initialize(float splitChance, Vector3 scale)
    {
        _splitChance = splitChance;
        transform.localScale = scale;
    }
}
