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
            _spawner.SpawnCubes(cube);
            _exploder.Explode(cube.Position, _spawner.SpawnedCubes);
        }

        _spawner.DestroyCube(cube);
    }
}
