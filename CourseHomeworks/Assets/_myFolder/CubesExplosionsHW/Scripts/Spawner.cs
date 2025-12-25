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

    private System.Random _random = new();

    public void SpawnCubes(float parentSplitChance, Vector3 parentScale)
    {
        int countCubes = _random.Next(_minCountCubes, _maxCountCubes + 1);

        for (int i = 0; i < countCubes; i++)
        {
            Vector3 spawnPosition = CountSpawnPosition();
            var explosionCube = Instantiate(_cube, spawnPosition, Quaternion.identity);

            explosionCube.Initialize(parentSplitChance * _splitChanceMultiplier, 
                parentScale * _scaleMultiplier);
        }
    }

    private Vector3 CountSpawnPosition()
    {
        float deltaX = (float)_random.NextDouble() - _offsetAlignment;
        float deltaZ = (float)_random.NextDouble() - _offsetAlignment;

        return new Vector3(transform.position.x + deltaX * _spreadMultiplier,
                transform.position.y + _deltaY,
                transform.position.z + deltaZ * _spreadMultiplier);
    }
}
