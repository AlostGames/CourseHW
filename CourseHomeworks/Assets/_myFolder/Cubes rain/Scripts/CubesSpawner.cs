using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnZone;
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<Cube> _pool;
    private Coroutine _spawningCoroutine;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_repeatRate);

        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_cubePrefab),
            actionOnGet: OnGet,
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: Destroy,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        StartSpawning();
    }

    private void OnGet(Cube cube)
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
        float halfSizeX = zoneSizeX / 2;
        float halfSizeZ = zoneSizeZ / 2;
        float spawnpointX = _spawnZone.transform.position.x + 
            Random.Range(0, zoneSizeX) - halfSizeX;
        float spawnpointZ = _spawnZone.transform.position.z +
            Random.Range(0, zoneSizeZ) - halfSizeZ;

        return new Vector3
            (spawnpointX, 
            _spawnZone.transform.position.y, 
            spawnpointZ);
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
            yield return _waitForSeconds;
        }
    }
}
