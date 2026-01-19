using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private System.Random _random = new();

    private void OnEnable()
    {
        _raycaster.CubeClick += Split;
    }

    private void OnDisable()
    {
        _raycaster.CubeClick -= Split;
    }

    private void Split(Cube cube)
    {
        if (cube.SplitChance >= _random.NextDouble())
        {
            List<Rigidbody> spawnedCubes = _spawner.SpawnCubes(cube);
            _exploder.Scatter(cube.Position, spawnedCubes);
        }
        else
        {
            _exploder.Explode(cube.Position, cube.ExplosionRadius, cube.ExplosionForce);
        }

        _spawner.DestroyCube(cube);
    }
}
