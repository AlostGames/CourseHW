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

    private void OnEnable()
    {
        foreach (Platform platform in FindObjectsOfType<Platform>())
        {
            platform.TouchingCube += ActivateCube;
        }
    }

    private void OnDisable()
    {
        foreach (Platform platform in FindObjectsOfType<Platform>())
        {
            platform.TouchingCube -= ActivateCube;
        }
    }

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
        InvokeRepeating(nameof(GetCube), 0.0f, _repeatRate);
    }

    private void ActionOnGet(Cube cube)
    {
        cube.transform.position = ChooseSpawnPoint();
        cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cube.SetDefaultStats();
        cube.gameObject.SetActive(true);
    }

    private void GetCube()
    {
        _pool.Get();
    }

    private void ActivateCube(Cube cube)
    {
        cube.Activate();
        cube.Died -= DeactivateCube;
        cube.Died += DeactivateCube;
    }

    private void DeactivateCube(Cube cube)
    {
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
}
