using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    [SerializeField] private Vector3 _direction = Vector3.up;

    private void Update()
    {
        transform.Rotate(_direction * _speed * Time.deltaTime);
    }
}
