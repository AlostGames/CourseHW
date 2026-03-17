using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private int _currentWayPoint = 0;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == _wayPoints[_currentWayPoint].position)
        {
            _currentWayPoint = (_currentWayPoint + 1) % _wayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            _wayPoints[_currentWayPoint].position,
            _speed * Time.deltaTime);
    }
}
