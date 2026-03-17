using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnpoints;
    [SerializeField] private float _reload = 2f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_reload);

        while (true)
        {
            SpawnPoint spawnpoint = ChooseSpawnpoint();
            spawnpoint.Spawn();

            yield return wait;
        }
    }

    private SpawnPoint ChooseSpawnpoint()
    {
        System.Random random = new System.Random();
        int index = random.Next(0, _spawnpoints.Length);

        return _spawnpoints[index];
    }
}
