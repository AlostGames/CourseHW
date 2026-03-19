using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _cooldown = 2f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_cooldown);

        while (enabled)
        {
            SpawnPoint spawnPoint = ChooseSpawnPoint();
            spawnPoint.Spawn();

            yield return wait;
        }
    }

    private SpawnPoint ChooseSpawnPoint()
    {
        int index = Random.Range(0, _spawnPoints.Length);

        return _spawnPoints[index];
    }
}
