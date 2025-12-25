using UnityEngine;

public class SplitManager : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private System.Random _random = new();

    private void OnEnable()
    {
        _cube.Activation += Split;
    }

    private void OnDisable()
    {
        _cube.Activation -= Split;
    }

    private void Split()
    {
        if (_cube.SplitChance >= _random.NextDouble())
        {
            _spawner.SpawnCubes(_cube.SplitChance, _cube.Scale);
            _exploder.Explode();
        }
    }
}
