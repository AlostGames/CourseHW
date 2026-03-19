using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private Transform _target;

    private void FixedUpdate()
    {
        Move();
    }

    public void SetTarget(TargetMover target)
    {
        _target = target.transform;
    }

    private void Move()
    {    
        transform.position = Vector3.MoveTowards(
            transform.position,
            _target.position,
            _speed * Time.deltaTime);
        transform.LookAt(_target);
    }  
}
