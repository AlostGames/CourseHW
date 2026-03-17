using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnZone;
    [SerializeField] private Cube _cube;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private System.Random _random = new System.Random();

    private ObjectPool<Cube> _pool;
    private Coroutine _spawningCoroutine;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_cube),
            actionOnGet: (cube) => ActionOnGet(cube),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        StartSpawning();
    }

    private void ActionOnGet(Cube cube)
    {
        cube.Died += DeactivateCube;
        cube.transform.position = ChooseSpawnPoint();       
        cube.SetDefaultStats();
        cube.gameObject.SetActive(true);
    }

    private void GetCube()
    {
        _pool.Get();
    }

    private void DeactivateCube(Cube cube)
    {
        cube.Died -= DeactivateCube;
        _pool.Release(cube);
    }

    private Vector3 ChooseSpawnPoint()
    {
        float zoneSizeX = _spawnZone.transform.localScale.x;
        float zoneSizeZ = _spawnZone.transform.localScale.z;
        float spawnpointX = _spawnZone.transform.position.x + 
            (float)_random.NextDouble() * zoneSizeX - zoneSizeX / 2;
        float spawnpointZ = _spawnZone.transform.position.z +
            (float)_random.NextDouble() * zoneSizeZ - zoneSizeZ / 2;

        return new Vector3(spawnpointX, _spawnZone.transform.position.y, spawnpointZ);
    }

    private void StartSpawning()
    {
        if (_spawningCoroutine != null)
            StopCoroutine(_spawningCoroutine);

        _spawningCoroutine = StartCoroutine(SpawningRoutine());
    }

    private IEnumerator SpawningRoutine()
    {
        while (true)
        {
            GetCube();
            yield return new WaitForSeconds(_repeatRate);
        }
    }
}
