using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _bulletPrefab;
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

                GameObject newBullet = Instantiate
                    (_bulletPrefab, 
                    transform.position + direction, 
                    Quaternion.identity);

                newBullet.transform.up = direction;

                Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();

                if (bulletRigidbody != null)
                    bulletRigidbody.velocity = direction * _bulletSpeed;
            }

            yield return new WaitForSeconds(_cooldown);
        }
    }
}