using System;
using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Color32 _defaultColor = Color.white;
    [SerializeField] private Color32 _activatedColor = Color.red;
    [SerializeField] private float _minDeathTime = 2f;
    [SerializeField] private float _maxDeathTime = 5f;

    private bool _isActivated;

    public Action<Cube> Died;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Platform>(out _))
        {
            Activate();
        }
    }

    public void SetDefaultStats()
    {
        _renderer.material.color = _defaultColor;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _isActivated = false;
    }
    
    private void Activate()
    {
        if (_isActivated == false)
        {
            _isActivated = true;
            _renderer.material.color = _activatedColor;
            StartCoroutine(DeathRoutine());
        }
    }

    private IEnumerator DeathRoutine()
    {
        float randomDelay = UnityEngine.Random.Range
            (_minDeathTime, _maxDeathTime);
        yield return new WaitForSeconds(randomDelay);
        Death();
    }

    private void Death()
    {
        Died?.Invoke(this);
    }
}
