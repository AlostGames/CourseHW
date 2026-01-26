using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemy;
    [SerializeField] private Transform[] _spawnpoints;
    [SerializeField] private float _reload = 2f;

    private float _offset = 0.5f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_reload);

        while (true)
        {
            Vector3 spawnpoint = ChooseSpawnpoint();

            EnemyMover enemy = Instantiate(_enemy, spawnpoint, Quaternion.identity);
            enemy.SetDirection(ChooseDirection());

            yield return wait;
        }
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
