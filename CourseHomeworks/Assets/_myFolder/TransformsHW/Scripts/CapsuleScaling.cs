using UnityEngine;

public class CapsuleScaling : MonoBehaviour
{
    [SerializeField] private float _speed = 0.2f;

    void Update()
    {
        transform.localScale += Vector3.one * _speed * Time.deltaTime;
    }
}
