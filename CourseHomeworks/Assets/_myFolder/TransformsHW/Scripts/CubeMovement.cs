using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float _speedMovement = 2f;
    [SerializeField] private float _speedRotation = 100f;
    [SerializeField] private float _speedScaling = 0.2f;
    [SerializeField] private Vector3 _directionRotation = Vector3.up;

    void Update()
    {
        transform.Rotate(_directionRotation * _speedRotation * Time.deltaTime);
        transform.position += transform.forward * _speedMovement * Time.deltaTime;
        transform.localScale += Vector3.one * _speedScaling * Time.deltaTime;
    }
}
