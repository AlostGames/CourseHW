using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    [SerializeField] private Vector3 _direction = Vector3.up;

    void Update()
    {
        transform.Rotate(_direction * _speed * Time.deltaTime);
    }
}
