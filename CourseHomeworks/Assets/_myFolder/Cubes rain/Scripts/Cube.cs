using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer; 
    [SerializeField] private Color32 _defaultColor = Color.white;
    [SerializeField] private Color32 _activatedColor = Color.red;
    [SerializeField] private float _minDeathTime = 2f;
    [SerializeField] private float _maxDeathTime = 5f;

    private bool _isActivated = false;

    private System.Random _random = new System.Random();

    public Action<Cube> Died;

    public void Activate()
    {
        if (_isActivated)
        {
            return;
        }
        else
        {
            _isActivated = true;
            _renderer.material.color = _activatedColor;
            Invoke("Death", (float)(_random.NextDouble() * (_maxDeathTime - _minDeathTime) 
                + _minDeathTime));
        }
    }

    public void SetDefaultStats()
    {
        _isActivated = false;
        _renderer.material.color = _defaultColor;
    }

    private void Death()
    {
        Died?.Invoke(this);
    }
}
