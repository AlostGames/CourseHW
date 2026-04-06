using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 1f;
    [SerializeField] private float _cooldown = 1f;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            if (_target != null && _bulletPrefab != null)
            {
                Vector3 direction = 
                    (_target.position - transform.position).normalized;

                Rigidbody newBullet = Instantiate
                    (_bulletPrefab, 
                    transform.position + direction, 
                    Quaternion.identity);

                newBullet.transform.up = direction;
                newBullet.velocity = direction * _bulletSpeed;
            }

            yield return new WaitForSeconds(_cooldown);
        }
    }
}