using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _speed = 0.2f;
    [SerializeField] private Vector3 _direction = Vector3.one;

    private void Update()
    {
        transform.localScale += _direction * _speed * Time.deltaTime;
    }
}
