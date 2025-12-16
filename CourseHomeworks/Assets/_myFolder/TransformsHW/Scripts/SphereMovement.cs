using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Vector3 _direction = Vector3.forward;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
