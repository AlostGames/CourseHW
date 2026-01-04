using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private float _scaleMultiplier = 0.5f;
    private float _splitChanceMultiplier = 0.5f;
    private int _minCountCubes = 2;
    private int _maxCountCubes = 6;
    private float _deltaY = 1;
    private float _spreadMultiplier = 2;
    private float _offsetAlignment = 0.5f;
    private List<GameObject> _spawnedCubes = new List<GameObject>();

    private System.Random _random = new();

    public List<GameObject> SpawnedCubes => _spawnedCubes;

    private void Start()
    {
        foreach (Cube cube in FindObjectsOfType<Cube>())
        {
            cube.Death += DestroyCube;
        }
    }

    public void SpawnCubes(float parentSplitChance, Vector3 parentScale, Vector3 parentPosition)
    {
        _spawnedCubes.Clear();
        int countCubes = _random.Next(_minCountCubes, _maxCountCubes + 1);

        for (int i = 0; i < countCubes; i++)
        {
            Vector3 spawnPosition = CalculateSpawnPosition(parentPosition);
            Cube explosionCube = Instantiate(_cube, spawnPosition, Quaternion.identity);

            explosionCube.Initialize(parentSplitChance * _splitChanceMultiplier,
                parentScale * _scaleMultiplier);

            explosionCube.Death += DestroyCube;

            _spawnedCubes.Add(explosionCube.gameObject);
        }
    }

    private Vector3 CalculateSpawnPosition(Vector3 zeroPosition)
    {
        float deltaX = (float)_random.NextDouble() - _offsetAlignment;
        float deltaZ = (float)_random.NextDouble() - _offsetAlignment;

        return new Vector3(zeroPosition.x + deltaX * _spreadMultiplier,
                zeroPosition.y + _deltaY,
                zeroPosition.z + deltaZ * _spreadMultiplier);
    }

    private void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
