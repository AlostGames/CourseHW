using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private EnemyMover _enemy;
    [SerializeField] private TargetMover _target;

    public void Spawn()
    {
        EnemyMover enemy = Instantiate(
            _enemy,
            _spawnPosition.position,
            Quaternion.identity);
        enemy.SetTarget(_target);
    }
}
