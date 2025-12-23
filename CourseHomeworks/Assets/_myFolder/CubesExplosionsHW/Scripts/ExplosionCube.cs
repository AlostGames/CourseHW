using UnityEngine;

public class ExplosionCube : MonoBehaviour
{
    [SerializeField] private CubeClickChecker _cubeClickChecker;
    [SerializeField] private CubesSpawner _cubeSpawner;
    [SerializeField] private ExplosionSpawner _explosionSpawner;

    private float _splitChance = 1;
    private float _scaleMultiplier = 0.5f;
    private float _splitChanceMultiplier = 0.5f;

    System.Random random = new();

    private void Start()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    private void OnEnable()
    {
        _cubeClickChecker.Click += Death;
    }

    private void OnDisable()
    {
        _cubeClickChecker.Click -= Death;
    }

    private void Death()
    {
        if (_splitChance >= random.NextDouble())
        {
            _cubeSpawner.SpawnCubes();
            _explosionSpawner.SpawnExplosion();
        }

        Destroy(gameObject);
    }

    public void ChangeStats()
    {
        _splitChance *= _splitChanceMultiplier;

        transform.localScale = new Vector3(
            transform.localScale.x * _scaleMultiplier,
            transform.localScale.y * _scaleMultiplier,
            transform.localScale.z * _scaleMultiplier);
    }
}
