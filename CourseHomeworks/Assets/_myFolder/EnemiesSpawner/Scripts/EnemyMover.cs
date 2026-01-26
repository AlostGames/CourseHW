using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
        LookAtDirection(_direction);
    }

    private void Move()
    {
        _rigidbody.MovePosition(transform.position + 
        _direction.normalized * _speed * Time.fixedDeltaTime);
    }

    private void LookAtDirection(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = targetRotation;
    }
}
