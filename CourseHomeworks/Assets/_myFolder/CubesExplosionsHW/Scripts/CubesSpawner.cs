using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    private int minCountCubes = 2;
    private int maxCountCubes = 6;
    private float deltaY = 1f;
    private float spreadMultiplier = 2;

    System.Random random = new();

    public void SpawnCubes()
    {
        int countCubes = random.Next(minCountCubes, maxCountCubes + 1);
        for (int i = 0; i < countCubes; i++)
        {
            float deltaX = (float)random.NextDouble() - 0.5f;
            float deltaZ = (float)random.NextDouble() - 0.5f;

            var explosionCube = Instantiate(gameObject, new Vector3
                (transform.position.x + deltaX * spreadMultiplier, 
                transform.position.y + deltaY, 
                transform.position.z + deltaZ * spreadMultiplier), 
                Quaternion.identity);

            explosionCube.GetComponent<ExplosionCube>().ChangeStats();
        }
    }
}
