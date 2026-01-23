using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemy;
    [SerializeField] private Transform[] _spawnpoints;
    [SerializeField] private float _reload = 0.5f;

    private float _startTime = 0;
    private float _offset = 0.5f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _startTime, _reload);
    }

    private void Spawn()
    {
        Vector3 spawnpoint = ChooseSpawnpoint();

        EnemyMove enemy = Instantiate(_enemy, spawnpoint, Quaternion.identity);
        enemy.SetDirection(ChooseDirection());
    }

    private Vector3 ChooseSpawnpoint()
    {
        System.Random random = new System.Random();
        int index = random.Next(0, _spawnpoints.Length);

        return _spawnpoints[index].position;
    }

    private Vector3 ChooseDirection()
    {
        System.Random random = new System.Random();
        return new Vector3((float)random.NextDouble() - _offset,
                            0,
                           (float)random.NextDouble() - _offset);
    }
}
